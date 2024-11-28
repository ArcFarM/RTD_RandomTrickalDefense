using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    //적의 스탯을 관리
    public GameObject enemy;

    //---------------------------적 스탯----------------------------
    //id
    int id;
    //체력
    double hp;
    //클래스(일반/특수/보스)
    enum Enemy_Class { Normal, Special, Boss };
    Enemy_Class ec;
    //특수 적 한정) 사용할 스펠
    enum Sp_Enemy_Spell { SpeedUp, HPRegen, DmgOne };
    Sp_Enemy_Spell? es = null;
    //이동 속도
    float spd;
    //방어력
    int armor;

    private void Set_Values()
    {

    }

    private void Start()
    {
       //싱글톤에 있는 적 생성 메서드 사용
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //wav : 현재 웨이브 번호 flag : 특수 적 소환 여부
    public GameObject Enemy_Setting(int wav, bool flag)
    {
        GameObject result = new GameObject();
        result.GetComponent<Enemy_Manager>();
        //보스 소환
        if(wav %5 == 0)
        {
            
        }
        //특수 미션 소환
        else if (flag)
        {

        }
        //일반 적 소환
        else
        {

        }
        return result;
    }

    
}
