using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enum을 관리할 전역 클래스
public static class EnumDict
{
    public enum Enemy_Type
    {
        normal, special, boss, tbd
    }

    public enum Enemy_Spell
    {
        /*적 이동 속도 증가, 체력이 매우 낮은 대신 모든 피해를 1로 받음
         * 일정 시간 마다 체력을 일정량 회복
         */
        spdup, flatdmg, healer, tbd
    }

    public enum Stats
    {
        id, hp, type, spell, speed, armor
    }
}
