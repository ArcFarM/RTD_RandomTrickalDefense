using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Placement : MonoBehaviour
{
    //설치 칸 위에 마우스를 올리고 q버튼을 누르면 타워 설치
    //칸 위에 마우스를 올리고 w버튼을 누르면 그 칸을 기준으로 동일한 타워를 하나 합성하여 더 높은 등급의 타워를 그 자리에 무작위 생성
    //e버튼을 누르면 돈을 제작비의 반값을 주고 판매
    //선택타워 건설 버튼을 누르면 타워 선택 목록이 나오고, 그걸 클릭하고 칸을 클릭하면 선택 타워 설치
    // Start is called before the first frame update

    //타워 상호작용과 마우스 올라가 있는 것을 감지하기 위한 플래그
    bool tower_build_flag = false;
    bool tower_upgrade_flag = false;
    bool tower_sell_flag = false;
    bool mouse_over_flag = false;
    bool is_tower_built = false;

    GameObject tower;

    // Update is called once per frame
    void Update()
    {
        //q,w,e를 누르면 타워 설치 가능/타워 합성 가능/타워 판매 가능 지역이 빛나기
        //그리고 가능한 지역에 클릭을 하면 역할을 수행하고, 그렇지 않으면 취소
        if (Input.GetKey(KeyCode.Q))
        {
            if (!is_tower_built)
            {
                //타워 설치 가능 지역 빛나기
                tower_build_flag = true;
            }
            //타워를 설치할 수 있는 지역에 마우스를 올리고 있고
            if(tower_build_flag && mouse_over_flag)
            {
                //그 지역에서 바로 마우스를 누르면
                if (Input.GetMouseButton(0))
                {
                    //타워 건설 수행
                    //건설 수행 후 플래그 끄기
                    tower_build_flag = false;
                    is_tower_built=true;
                }

            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            //타워가 존재하고, 같은 타워가 있다면 활성화 조건
            {
                //타워 합성 가능 지역 빛나기
                tower_upgrade_flag = true;
            }
            //타워를 합성할 수 있는 지역에 마우스를 올리고 있고
            if (tower_upgrade_flag && mouse_over_flag)
            {
                //그 지역에서 바로 마우스를 누르면
                if (Input.GetMouseButton(0))
                {
                    //타워 합성 수행
                    //플래그 끄기
                    tower_upgrade_flag=false;
                }
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (is_tower_built)
            {
                //타워 판매 가능 지역 빛나기
                tower_sell_flag = true;
            }
            //타워를 판매할 수 있는 지역에 마우스를 올리고 있고
            if (tower_sell_flag && mouse_over_flag)
            {
                //그 지역에서 바로 마우스를 누르면
                if (Input.GetMouseButton(0))
                {
                    //타워 판매 수행
                    //플래그 끄기
                    tower_sell_flag = false;
                    is_tower_built = false;
                }
            }
        }
    }

    //오브젝트에 마우스를 올리고 있어야 설치가 가능
    //마우스를 올리고 있는 지 없는 지 판단하는 용도
    void OnMouseOver()
    {
        mouse_over_flag = true;
    }
    private void OnMouseExit()
    {
        mouse_over_flag = false;
    }
}
