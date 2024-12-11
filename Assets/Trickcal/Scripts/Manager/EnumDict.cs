using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enum을 관리할 전역 클래스
public static class EnumDict
{
    //적의 유형
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

    //적의 능력치
    public enum Stats
    {
        id, hp, type, spell, speed, armor
    }
    
    //타워의 능력치
    public enum T_stats
    {
        //타워 id와 타워 등급
        //공격력, 공격 속도, 사정 거리
        //스킬 쿨타임, 스킬 계수, 치명타 확률
    }
    //플레이어가 보유 가능한 스펠 목록
    public enum P_spell
    {
        //공속 증가, 평타 공격력 증가, 스킬 공격력 증가
        atkspdup, atkup, skillup,
        //모든 타워 무작위 진화, 적 방어력 감소
        levelup, armorpenet
    }
}
