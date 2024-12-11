using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumDict;

public class Enemy_Stat : MonoBehaviour
{
    //능력치를 저장할 리스트
    List<object> stats = new List<object>();
    //사용 여부 미정 - 이 몬스터가 생성될 당시 몇 번째에 위치하였는가
    int index = -1;

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
