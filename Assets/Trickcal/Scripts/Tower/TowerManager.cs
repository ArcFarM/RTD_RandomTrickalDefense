using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {
    /*
     * 구현할 기능 1 : 타워 설치
     * 충분한 자원이 있을 경우 q버튼을 누르고
     * 빈자리를 클릭하면 무작위 1단계 타워가 설치됨 (이 부분은 싱글톤에 있는 1단계 타워 리스트를 받아와서 이용)
     * 
     * 기능 2 : 선택 타워 설치
     * 충분한 자원이 있을 경우 선택타워 설치 버튼을 누르면
     * UI 측면에서 원하는 타워를 고를 수 있고,
     * 타워 선택 후 빈 자리를 클릭하면 해당 타워가 설치됨
     * 
     * 기능 3 : 타워 합성
     * W 키를 누르면 합성 가능한 타워 (동일한 타워가 2개 이상 존재할 경우)
     * 들이 빛나고, 빛나는 타워를 클릭하면 index 순으로 가장 먼저 있는 타워 2개가 합성되어 (2개 타워를 각각 false -> destroy)
     * 1단계 더 높은 타워가 무작위로 클릭한 위치에 설치됨
     * 
     * 기능 4 : 타워 판매
     * E키를 누르고 타워가 잇는 곳을 클릭하면 해당 타워를 삭제하고 등급에 비례하여 자원을 지급함
     */

    public GameObject go;
    GroundManager go_gm;
    GameManager gm;
    private void Start() {
        go_gm = go.GetComponent<GroundManager>();
        gm = GameManager.Instance;
    }

    bool flag_build = false, flag_up = false, flag_sell = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            //타워 건설 모드로 전환
            //Debug.Log("Q Pressed");
            if (!flag_up && !flag_sell) flag_build = true;
            //우클릭으로 해제
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            //타워 합성 모드로 전환
            if (!flag_build && !flag_sell) {
                flag_up = true;
                go_gm.React_up();
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            //타워 판매 모드로 전환
            if (!flag_build && !flag_up) flag_sell = true;
        }

        if (flag_build || flag_up || flag_sell) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Click Method run");
                Click();
            }
            else if (Input.GetMouseButtonDown(1)) {
                Debug.Log("Button Press Cancled.");
                go_gm.React_end();
                Flag_Off();
            }
        }
    }

    void Flag_Off() {
        flag_build = flag_up = flag_sell = false;
    }

    void Click() {

        //클릭한 순간의 좌표
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //클릭이 감지된 오브젝트
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        Debug.Log(hit.transform.position);

        //클릭이 감지되어 hit이 할당되었다면 우선 타워 설치 가능 지역인 지 확인
        if (hit.collider != null) {

            Debug.Log("collision detected");
            if (hit.collider.gameObject.tag == "Tower_Deploy") {
                //Debug.Log("Tower Build Started at" + hit.collider.gameObject.transform.position);
                Tower_Tile hit_tt = hit.collider.gameObject.GetComponent<Tower_Tile>();
                //타워 합성 및 판매에 사용될 타워 id를 미리 깡통만 선언
                string tower_id = "";

                //해당 지역의 타일에 타워가 없다면 설치
                if (hit_tt.Tower_Check() == false && flag_build) {
                    Flag_Off();
                    //TODO : 타워 설치 분량 만큼의 자원 감소
                    GameObject rnd_tower = gm.Get_RandomTower(0);
                    rnd_tower = Instantiate(rnd_tower);
                    hit_tt.Set_Tower(rnd_tower);

                    tower_id = rnd_tower.GetComponent<TowerStats>().id;
                    gm.Set_dict(tower_id, gm.Get_dict(tower_id) + 1);
                }
                //타워 합성
                if (hit_tt.Tower_Check() && flag_up) {
                    //클릭한 타워가 합성 가능한 지 확인
                    Flag_Off();

                    //더 높은 단계의 타워로 합성
                    tower_id = hit_tt.Get_Tower().GetComponent<TowerStats>().id;
                    int level = hit_tt.Get_Tower().GetComponent<TowerStats>().level;
                    // 동일 id와 같은 레벨의 타워가 2개 이상 존재하는지 확인
                    if (gm.Get_dict(tower_id) >= 2) {
                        int towersDeleted = 0;
                        // 설치된 타워들 중 같은 id와 레벨의 타워 2개 삭제
                        for (int i = 0; i < go_gm.tiles.Count; i++) {
                            Tower_Tile tt = go_gm.tiles[i].GetComponent<Tower_Tile>();
                            if (tt.Get_Tower() != null
                                && tt.Get_Tower().GetComponent<TowerStats>().id == tower_id
                                && tt.Get_Tower().GetComponent<TowerStats>().level == level) {
                                Destroy(tt.Get_Tower());
                                gm.Set_dict(tower_id, gm.Get_dict(tower_id) - 1);
                                tt.Set_Tower(null);
                                towersDeleted++;
                            }
                            if (towersDeleted >= 2) { break; }
                        }
                        // 새로운 타워 생성 및 배치
                        GameObject newTower = gm.Get_RandomTower(level + 1);
                        newTower = Instantiate(newTower);
                        hit_tt.Set_Tower(newTower);
                        string nt_id = newTower.GetComponent<TowerStats>().id;
                        gm.Set_dict(nt_id, gm.Get_dict(nt_id) + 1);

                        go_gm.React_end();
                    }
                    //타워 판매
                    if(hit_tt.Tower_Check() && flag_sell) {
                        Flag_Off();
                        tower_id = hit_tt.Get_Tower().GetComponent<TowerStats>().id;
                        Destroy(hit_tt.Get_Tower());
                        gm.Set_dict(tower_id, gm.Get_dict(tower_id) - 1);
                        //TODO : 재화 환급
                        
                        }
                }
                else return;
            }
        }
    }
}

