using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    // Start is called before the first frame update

    //타워가 보유할 능력치
    //공격력, 공격 속도(초당 공격 속도), 사거리, 스킬 쿨타임, 스킬 계수
    //스탯은 +와 %로 구분할 것

    //열거형

    static int stats_size = 15;
    public enum Stats
    {
        //순서대로 공격력, 공격속도, 사거리, 쿨타임, 스킬 계수
        //순서대로 현재 기본수치, +증가량, %증가량(배수), 최종 수치
        dmg, dmg_plus, dmg_pcnt, dmg_total,
        spd, spd_plus, spd_pcnt, spd_total,
        rng, rng_plus, rng_pcnt, rng_total,
        cd, cd_plus, cd_pcnt, cd_total,
        skl, skl_plus, skl_pcnt, skl_total,
    }

    public List<object> stats = new List<object>();

    void Start()
    {
        //타워 스탯 초기화
        for(int i = 0; i < stats_size; i++)
        {
            stats.Add(0.0);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    object get_stat(int num)
    {
        return stats[num];
    }

    //배율 조정을 할 것인지 여부, 조정할 스탯, 증가할 고정 수치, 증가할 배율
    void set_stat(bool flag, int index, object fir, object sec)
    {
        //flag = false면 배율 계산을 무시한다
        if (!flag) sec = 0;
        //0 공격 1 공속 2 사거리 3 쿨타임 4 스킬 계수
        if (index != 0) index = index * 4;
        //고정 수치 증가
        stats[index + 1] = (double)stats[index + 1] + (double)fir;
        //배율 증가
        stats[index + 2] = (double)stats[index + 2] + (double)sec;
        //최종 수치 재계산
        stats[index + 3] = ((double)stats[index] + (double)stats[index + 1]) * (double)stats[index];
    }

   

}
