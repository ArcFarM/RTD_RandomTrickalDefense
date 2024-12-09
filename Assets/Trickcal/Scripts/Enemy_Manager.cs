using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enemy_Class { Normal, Special, Boss };
public enum Sp_Enemy_Spell { SpeedUp, HPRegen, DmgOne };

public class Enemy_Manager : MonoBehaviour
{

    //고유 번호, 체력, 클래스, 특수 적의 스펠, 이동 속도, 방어력
    public string id;
    public double hp;
    public Enemy_Class ec;
    public Sp_Enemy_Spell? es = null;
    public float spd;
    public int armor;

    //웨이브 수에 곱할 상수와 특수 적, 보스 용 계수
    public int n_hp = 10, n_armor = 2;
    public int s_hp = 1, s_armor = 1;
    public int b_hp = 1, b_armor = 1;

    //wav : 현재 웨이브 번호 flag : 특수 적 소환 여부
    public GameObject Enemy_Setting(int wav, bool flag, GameObject result)
    {
        result.AddComponent<Enemy_Manager>();
        Enemy_Manager em = result.GetComponent<Enemy_Manager>();

        //보스 적 id
        if (wav % 5 == 0 && !flag)
        {
            if (wav < 10) em.id = "B100" + wav.ToString();
            else em.id = "B10" + wav.ToString();

            b_hp = 120; b_armor = 2;
        }
        else if (!flag)
        {
            //일반 적 id
            if (wav < 10) em.id = "N000" + wav.ToString();
            else em.id = "B00" + wav.ToString();
        }
        else
        {
            //특수 적 id
            if (wav < 10) em.id = "S9999";
            s_hp = 30; s_armor = 2;
        }
        //TODO : 해당 id를 갖는 스프라이트를 가져와서 할당하기

        //체력과 방어력은 클래스에 따라 정해진 값을 웨이브 수에 곱하고, 이동속도 고정
        em.hp = n_hp * wav * b_hp * s_hp;
        em.armor = n_armor * wav * b_armor * s_armor;
        //순서대로 특수, 보스, 일반 적 이동속도 설정
        if (em.id[0] == 'S') em.spd = 2.5f;
        else if (em.id[0] == 'B') em.spd = 1.5f;
        else em.spd = 2f;
        
        //특수 적인 경우 스펠은 무작위로 고른다
        if (em.id[0] == 'S')
        {
            int rnd = UnityEngine.Random.Range(0, 3);
            em.es = (Sp_Enemy_Spell)rnd;
        }

        return result;
    }
}
