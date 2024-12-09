using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumDict;

public class Enemy_Stat : MonoBehaviour
{
    List<object> stats = new List<object>();

    public Enemy_Stat()
    {
        //고유 번호, 체력, 클래스, 특수 적의 스펠, 이동 속도, 방어력
        string tmp_str = null;
        float tmp_flt = -1f;

        stats.Add(tmp_str);
        stats.Add(tmp_flt);
        stats.Add(Enemy_Type.tbd);
        stats.Add(Enemy_Spell.tbd);
        stats.Add(tmp_flt);
        stats.Add(tmp_flt);
    }

    public object Get_List(Stats st)
    {
        int index = (int)st;
        return stats[index];
    }

    //리스트 내 원소 수정
    public void Set_List(Stats st, object val)
    {
        stats[(int)st] = val;
    }
}
