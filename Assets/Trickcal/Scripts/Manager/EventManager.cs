using System.Collections;
using System.Collections.Generic;

public static class EventManager
{

    //이벤트 선언
    public delegate void EventDelegate();
    //단체 월반 스펠 구매
    public static event EventDelegate OnAllup;
    //포셔 물약 스펠 구매
    public static event EventDelegate OnPotion;
    //랜덤 돈 스펠 구매
    public static event EventDelegate OnRndmoney;
    //랜덤 업그레이드 스펠 구매
    public static event EventDelegate OnRndup;
    //타워 건설 가능 지역 빛나기
    public static event EventDelegate OnTowerbuy;
    //타워 합성 가능 지역 빛나기
    public static event EventDelegate OnTowerup;
    //타워 판매 가능 지역 빛나기
    public static event EventDelegate OnTowersell;

    //이벤트 호출
    public static void EventTrigger_Allup()
    {
        OnAllup?.Invoke();
    }

    public static void EventTrigger_Potion()
    {
        OnPotion?.Invoke();
    }

    public static void EventTrigger_Rndmoney() {
        OnRndmoney?.Invoke();
    }

    public static void EventTrigger_OnRndup() {
        OnRndup?.Invoke();
    }

    public static void EventTrigger_OnTowerbuy() {
        OnTowerbuy?.Invoke();
    }
    public static void EventTrigger_OnTowerup() {
        OnTowerup?.Invoke();
    }
    public static void EventTrigger_OnTowersell() {
        OnTowersell?.Invoke();
    }
}
