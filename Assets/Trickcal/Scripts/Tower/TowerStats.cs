using System.Collections.Generic;
using UnityEngine;
using static EnumDict;

public class TowerStats : MonoBehaviour
{
    public List<object> stats = new List<object>();

    TowerStats()
    {
        //타워 스탯 초기화
        stats.Add("");
        stats.Add(0);
        for(int i = 2; i < sizeof(T_stats); i++)
        {
            stats.Add(0.0f);
        }   
    }

    public object Get_Stat(T_stats idx)
    {
        return stats[(int)idx];
    }

    //스탯 수정
    public void Set_Stat(T_stats idx, object val)
    {
        stats[(int)idx] = val;
    }

   

}
