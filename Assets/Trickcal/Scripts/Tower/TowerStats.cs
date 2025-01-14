using System.Collections.Generic;
using UnityEngine;
using static EnumDict;

public class TowerStats : MonoBehaviour
{
    //자료형이 다르므로 public으로 하는 것이 관리가 더 편하다
    public string id;
    public int level;

    //공격력
    public int dmg;
    //공격속도 (초당 횟수)
    public double atk_spd;
    //사거리
    public float range;
    //스킬 쿨타임
    public double skill_cd;
    //스킬 계수
    public double skill_dmg;

    
    public double Stat_Calc(int val, int flat, double perc) {
        return val + flat * perc;
    }
    public double Stat_Calc(float val, float flat, double perc) {
        return val + flat * perc;
    }
    public double Stat_Calc(double val, double flat, double perc) {
        return val + flat * perc;
    }
}
