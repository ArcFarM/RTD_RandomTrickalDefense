using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumDict;


public class Enemy_Manager : MonoBehaviour
{
    //적이 생성되어야 할 지점
    public GameObject start_Position;


    //적의 스탯 : 고유 번호, 체력, 클래스, 특수 적의 스펠, 이동 속도, 방어력

    //웨이브 수에 곱할 상수와 특수 적, 보스 용 계수
    public int n_hp = 10, n_armor = 1;
    public int s_hp = 1, s_armor = 1;
    public int b_hp = 1, b_armor = 1;

    //생성해서 내보낼 게임 오브젝트
    //최초 inspector에서 할당해놓으면 여기에 살을 덧붙여서 내보낸다
    public GameObject prefab;
    //싱글톤
    GameManager gm;

    void Start()
    {
        //싱글톤 인스턴스 초기화
        gm = GameManager.Instance;
        if (gm == null) Debug.LogError("Singleton Instance Initiation Error\n");


        // 코루틴 사용하여 지연 초기화
        StartCoroutine(Delayed_Spawn_Enemy());
    }

    IEnumerator Delayed_Spawn_Enemy()
    {
        for(int i = 1; i <= 1; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Enemy_Setting(i, false);
        }
    }

    //wav : 현재 웨이브 번호 flag : 특수 적 소환 여부
    public void Enemy_Setting(int wav, bool flag)
    {
        GameObject result = Instantiate(prefab);
        Enemy_Stat es = result.GetComponent<Enemy_Stat>();

        //id와 Type, 이동속도 설정 
        string id = "";
        //보스 적 id
        if (wav % 5 == 0 && !flag)
        {
            id = "B10";
            if (wav == 5)
            {
                id += "05";
            } else id += wav.ToString();
            es.Set_List(Stats.id, id);
            es.Set_List(Stats.type, Enemy_Type.boss);

            b_hp = 120; b_armor = 5;
        }
        else if (!flag)
        {
            //일반 적 id
            id = "N10";
            if(wav < 10)
            {
                id += "0" + wav.ToString();
            } else id += wav.ToString();

            es.Set_List(Stats.id, id);
            es.Set_List(Stats.type, Enemy_Type.normal);
        }
        else
        {
            //특수 적 id
            id = "S1001";

            s_hp = 30; s_armor = 3;

            es.Set_List(Stats.id, id);
            es.Set_List(Stats.type, Enemy_Type.special);
        }
        es.Set_List(Stats.speed, 5.0f);
        //TODO : 해당 id를 갖는 스프라이트를 가져와서 할당하기

        //체력과 방어력은 클래스에 따라 정해진 값을 웨이브 수에 곱하고, 이동속도 고정
        es.Set_List(Stats.hp, n_hp * b_hp * s_hp * wav);

        //방어력은 소숫점 내림
        float armor = (n_armor * b_armor * s_armor * (wav / 5));
        armor = (float)Math.Floor(armor);
        es.Set_List(Stats.armor, armor);

        //특수 적인 경우 스펠은 무작위로 고른다
        if ((string)es.Get_List(Stats.id) == "special")
        {
            int rnd = UnityEngine.Random.Range(1, 4);
            es.Set_List(Stats.spell, rnd);
        }

        //이동을 위해 시작 지점으로 위치를 이동
        result.transform.position = start_Position.transform.position;

        //생성된 GameObject result를 전역 리스트에 배치한다
        List<GameObject> list = gm.Get_Enemy();
        list.Add(result);
        gm.Set_Enemy(list);

        //디버그
        //Debug.Log("wav : " + wav + " id : " + id + " type : " + es.Get_List(Stats.type)
        //    + " hp : " + es.Get_List(Stats.hp) + " armor : " + es.Get_List(Stats.armor));
    }
}
