using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Tile : MonoBehaviour
{
    /*
     * 구현할 기능 : 설치할 타워와, 빛나기에 필요한 마테리얼 추가
     */

    Material glow;
    GameObject tower;

    //타워가 설치되어 있다면 true를 반환
    public bool Tower_Check() {
        if (tower == null) return false;
        else return true;
    }

    //타워를 통째로 반환 (설치된 타워 수정용)
    public GameObject Get_Tower() {
        GameObject copy = tower;
        return copy;
    }

    //설치된 타워를 수정
    public void Set_Tower(GameObject? t) { tower = t; }


    
    //특정 조건에서 빛나서 상호작용 가능한 상태임을 알림
    public void Glow_Tile() {
        //코루틴을 사용하여 0.5초에 걸쳐서 밝게 빛나고, 0.5초에 걸쳐서 다시 불이 꺼짐
        //이것을 2회 반복
    }
}
