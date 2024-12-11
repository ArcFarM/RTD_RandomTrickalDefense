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

    //이벤트 호출
    public static void EventTrigger_Allup()
    {
        OnAllup?.Invoke();
    }

    public static void EventTrigger_Potion()
    {
        OnPotion?.Invoke();
    }
}
