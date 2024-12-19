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
        id, grade,
        //순서대로 공격력, 공격속도, 사거리, 쿨타임, 스킬 계수
        //순서대로 현재 기본수치, +증가량, %증가량(배수), 최종 수치
        dmg, dmg_plus, dmg_pcnt, dmg_total,
        spd, spd_plus, spd_pcnt, spd_total,
        rng, rng_plus, rng_pcnt, rng_total,
        cd, cd_plus, cd_pcnt, cd_total,
        skl, skl_plus, skl_pcnt, skl_total,
        crit, crit_plus, crit_pcnt, crit_total
    }
    //플레이어가 보유 가능한 스펠 목록
    public enum P_spell
    {
        //공속 증가, 평타 공격력 증가, 스킬 공격력 증가
        atkspdup, atkup, skillup,
        //모든 타워 무작위 진화, 적 방어력 감소
        allup, armorpenet,
        //무작위 돈 증가, 단일 타워 무작위 진화, 무작위 업그레이드
        rndmoney, rndup, rndupgrade
    }
}
