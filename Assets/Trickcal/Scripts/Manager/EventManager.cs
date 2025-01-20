using System.Collections;
using System.Collections.Generic;

public static class EventManager
{

    //이벤트 선언
    public delegate void EventDelegate();

    //스펠 구매 이벤트
    //단체 월반 스펠 구매
    public static event EventDelegate OnAllup;
    //포셔 물약 스펠 구매
    public static event EventDelegate OnPotion;
    //랜덤 돈 스펠 구매
    public static event EventDelegate OnRndmoney;
    //랜덤 업그레이드 스펠 구매
    public static event EventDelegate OnRndup;

    //타워 관련 이벤트
    //타워 건설 가능 지역 빛나기
    public static event EventDelegate OnTowerbuy;
    //타워 합성 가능 지역 빛나기
    public static event EventDelegate OnTowerup;
    //타워 판매 가능 지역 빛나기
    public static event EventDelegate OnTowersell;

    //적 관련 이벤트
    //적 스폰
    //적 사망
    //적 최종 지점 도달
    //게임 진행 관련 이벤트
    //웨이브 시작
    //웨이브 종료
    //게임 오버

    //이벤트 호출

    //스펠 이벤트
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

    //타워 이벤트
    public static void EventTrigger_OnTowerbuy() {
        OnTowerbuy?.Invoke();
    }
    public static void EventTrigger_OnTowerup() {
        OnTowerup?.Invoke();
    }
    public static void EventTrigger_OnTowersell() {
        OnTowersell?.Invoke();
    }

    //적 이벤트
    public static void EventTrigger_OnEnemySpawn() {

    }
    public static void EventTrigger_OnEnemyEnd() {

    }

    public static void EventTrigger_OnEnemyDead() {

    }
    //진행 이벤트
    public static void EventTrigger_OnWaveStarted() {

    }
    public static void EventTrigger_OnWaveEnded() {

    }
    public static void EventTrigger_OnGameStart() {

    }
    public static void EventTrigger_OnGameOver() {

    }
  
}
