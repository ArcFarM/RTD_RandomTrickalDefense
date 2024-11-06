using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    // Start is called before the first frame update

    //타워가 보유할 능력치
    //공격력, 공격 속도(초당 공격 속도), 사거리, 스킬 쿨타임, 스킬 계수
    //스탯은 +와 %로 구분할 것

    //공격력, 공격력 + 증가량, 최종 공격력 
    public int dmg_fir = 0; public double dmg_sec = 1.0, total_dmg = 0;
    //공격 속도, 공격 속도 증가량, 최종 공격 속도
    public double spd_fir = 0, spd_sec = 1.0, total_spd = 0;
    //사거리, 사거리 증가량, 최종 사거리
    public double range_fir = 0, range_sec = 1.0, total_range = 0;
    //스킬 쿨타임, 스킬 쿨타임 증가/감소량, 최종 스킬 쿨타임
    public double cd_fir = 0, cd_sec = 1.0, total_cd = 0;
    //스킬 계수, 스킬 계수 증가/감소량, 최종 스킬 계수
    public double skill_fir = 0, skill_sec = 1.0, total_skill = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //공격력 증감
    void set_dmg(int flag, int fir, double sec)
    {
        switch (flag)
        {
            //데미지 수치 증가
            case 0:
                dmg_fir += fir;
                total_dmg = dmg_fir * dmg_sec;
                break;
            //데미지 배수 증가
            case 1:
                dmg_sec+= sec;
                total_dmg = dmg_fir * dmg_sec;
                break;
        }
    }
    //공격 속도 증감
    void set_spd(int flag, int fir, double sec)
    {
        switch (flag)
        {
            //데미지 수치 증가
            case 0:
                spd_fir += fir;
                total_spd = spd_fir * spd_sec;
                break;
            //데미지 배수 증가
            case 1:
                spd_sec += sec;
                total_spd = spd_fir * spd_sec;
                break;
        }
    }
    //사거리 증감
    void set_range(int flag, int fir, double sec)
    {
        switch (flag)
        {
            //데미지 수치 증가
            case 0:
                range_fir += fir;
                total_range = range_fir * range_sec;
                break;
            //데미지 배수 증가
            case 1:
                range_sec += sec;
                total_range = range_fir * range_sec;
                break;
        }
    }
    //쿨타임 증감
    void set_cd(int flag, int fir, double sec)
    {
        switch (flag)
        {
            //데미지 수치 증가
            case 0:
                cd_fir += fir;
                total_cd = cd_fir * cd_sec;
                break;
            //데미지 배수 증가
            case 1:
                cd_sec += sec;
                total_cd = cd_fir * cd_sec;
                break;
        }
    }
    //계수 증감
    void set_skill(int flag, int fir, double sec)
    {
        switch (flag)
        {
            //데미지 수치 증가
            case 0:
                skill_fir += fir;
                total_skill = skill_fir * skill_sec;
                break;
            //데미지 배수 증가
            case 1:
                skill_sec += sec;
                total_skill = skill_fir * skill_sec;
                break;
        }
    }


}
