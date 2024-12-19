using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public static class EventSubscriber
{
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
    //타워 설치 가능 발판 상호작용 관련
    //public static void OnTowerbuyEnable() { OnTowerbuy += Towerbuy_Method(go); }
    //public static void OnTowerbuyDisable() { OnTowerbuy -= Towerbuy_Method(go); }
    public static void OnTowerupEnable() { OnTowerup += Towerup_Method; }
    public static void OnTowerupDisable() { OnTowerup -= Towerup_Method; }
    public static void OnTowersellEnable() { OnTowersell += Towersell_Method; }
    public static void OnTowersellDisable() { OnTowersell -= Towersell_Method; }

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

    static void Towerbuy_Method(GameObject go) {
    }
    static void Towerup_Method() {
    }
    static void Towersell_Method() {
    }
}
