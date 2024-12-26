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
            flag_build = true;
            //우클릭으로 해제

        }
        if (Input.GetKeyDown(KeyCode.W)) {
            //타워 합성 모드로 전환
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            //타워 판매 모드로 전환
            
        }
    }

    void Click() {
        //오브젝트와 충돌하여 클릭 감지
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        //클릭이 감지된 오브젝트
        RaycastHit hit;

        //클릭이 감지되어 hit이 할당되었다면 우선 타워 설치 가능 지역인 지 확인
        if(Physics.Raycast(ray, out hit)) {
            if (hit.collider.gameObject.tag == "Tower_Deploy") {
                Tower_Tile hit_tt = hit.collider.gameObject.GetComponent<Tower_Tile>();
                //클릭된 타일의 좌표
                int row = hit_tt.get_row();
                int col = hit_tt.get_col();
                int idx = row * go_gm.get_row() + col;

                //해당 지역의 타일에 타워가 없다면 설치
                if (hit_tt.Tower_Check() == false && flag_build) {
                    flag_build = false;
                    //TODO : 싱글톤의 타워 리스트에서 랜덤 타워 꺼내서 해당 towertile의 go에 할당
                }
                //타워 합성
                //if (hit_tt.Tower_Check() && )
                //타워 판매
            }
            else return;
        }
    }
}
