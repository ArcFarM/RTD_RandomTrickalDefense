using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public static class EventSubscriber
{
    //이벤트에 사용할 매니저 오브젝트들
    public static GameObject gameManager;
    public static GameObject enemyManager;
    public static GameObject towerManager;
    public static GameObject groundManager;
    public static GameObject tileManager;
    public static GameObject resourceManager;

    //이벤트 구독 및 해제

    //스펠 구매 관련
    public static void OnAllupEnable() { OnAllup += Allup_Method; }
    public static void OnAllupDisable() { OnAllup -= Allup_Method; }
    public static void OnPotionEnable() { OnPotion += Potion_Method; }
    public static void OnPotionDisable() { OnPotion -= Potion_Method; }
    public static void OnRndmoneyEnable() { OnRndmoney += Potion_Method; }
    public static void OnRndmoneyDisable() { OnRndmoney -= Potion_Method; }
    public static void OnRndupEnable() { OnRndup += Rndup_Method; }
    public static void OnRndupDisable() { OnRndup -= Rndup_Method; }

    static void Allup_Method()
    {
        GameManager gm = GameManager.Instance;
        //TODO : 타워 리스트 받아와서 엘다인 제외 모든 타워를 무작위 상위 등급 타워로 변환
    }

    static void Potion_Method()
    {
        GameManager gm = GameManager.Instance;
        //TODO : 적 리스트 받아와서 모든 적들의 방어력 감소
    }

    static void Rndmoney_Method() {
        //TODO : 무작위 돈을 지급
    }

    static void Rndup_Method() {
        //TODO : 무작위 타워 (단, 엘다인 타워 제외)의 등급을 1 올림
    }

    //적 관련 이벤트
    public static void OnEnemyEndEnable() { OnEnemyEnd += EnemyEnd_Method; }
    public static void OnEnemyEndDisable() { OnEnemyEnd -= EnemyEnd_Method; }

    static void EnemyEnd_Method() {
        Resource_Manager rm = resourceManager.GetComponent<Resource_Manager>();
        //목숨 1 차감
        rm.set_life(rm.get_life() - 1);
    }
}
