using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public static class EventSubscriber
{
    //이벤트 구독 및 해제
    public static void OnAllupEnable()
    { OnAllup += Allup_Method; }
    public static void OnAllupDisable()
    { OnAllup -= Allup_Method; }

    public static void OnPotionEnable()
    { OnPotion += Potion_Method; }
    public static void OnPotionDisable()
    { OnPotion -= Potion_Method; }

    static void Allup_Method()
    {
        GameManager gm = GameManager.Instance;
        //TODO : 타워 리스트 받아와서 모든 타워를 무작위 상위 등급 타워로 변환
    }

    static void Potion_Method()
    {
        GameManager gm = GameManager.Instance;
        //TODO : 적 리스트 받아와서 모든 적들의 방어력 감소
    }
}
