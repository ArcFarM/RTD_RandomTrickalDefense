using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    //설치 가능 지역들을 담을 리스트 
    public List<GameObject> tiles = new List<GameObject>();

    //전체 행과 열의 수
    int row = 6;
    int col = 6;

    public int get_row() { return row; }
    public int get_col() { return col; }
    /*
     * 구현할 기능 : 키보드 입력에 반응하여 변하는 기능 넣기
     */
    private void Start() {
    }

    //합성 가능한 타워 표시
    public void React_up() {
        //2개 이상 존재하되 5단계가 아닌 타워에 해당하는 id를 가진 타일을 전부 밝게 빛나게 실시
        for(int i = 0; i < tiles.Count; i++) {
            Tower_Tile tt = tiles[i].GetComponent<Tower_Tile>();
            if (tt.Get_Tower() != null) {
                TowerStats ts = tt.Get_Tower().GetComponent<TowerStats>();
                string tower_id = ts.id;
                //타일이 타워가 있고, 해당 타워가 2개 이상 존재한다면
                if (GameManager.Instance.Get_dict(tower_id) > 1 && ts.level < 5) {
                    tt.Show_UpArrow();
                }
            }
        }
    }

    public void React_end() {
        for (int i = 0; i < tiles.Count; i++) {
            Tower_Tile tt = tiles[i].GetComponent<Tower_Tile>();
            tt.Hide_UpArrow();
        }
    }
    
}
