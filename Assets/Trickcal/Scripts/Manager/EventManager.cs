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

    //적 관련 이벤트
    //적 사망
    public static event EventDelegate OnEnemyDeath;
    //적 최종 지점 도달
    public static event EventDelegate OnEnemyEnd;
    //보스 사망
    public static event EventDelegate OnBossDeath;
    //게임 진행 관련 이벤트

    //웨이브 시작
    public static event EventDelegate OnWaveStarted;
    //웨이브 종료
    public static event EventDelegate OnWaveEnded;
    //게임 시작
    public static event EventDelegate OnGameStart;
    //게임 오버
    public static event EventDelegate OnGameOver;

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

    //적 이벤트
    public static void EventTrigger_OnEnemyEnd() {
        OnEnemyEnd?.Invoke();
    }

    public static void EventTrigger_OnEnemyDeath() {
        OnEnemyDeath?.Invoke();
    }
    public static void EventTrigger_OnBossDeath() {
        OnBossDeath?.Invoke();
    }

    //진행 이벤트
    public static void EventTrigger_OnWaveStarted() {
        OnWaveStarted?.Invoke();
    }
    public static void EventTrigger_OnWaveEnded() {
        OnWaveEnded?.Invoke();
    }
    public static void EventTrigger_OnGameStart() {
        OnGameStart?.Invoke();
    }
    public static void EventTrigger_OnGameOver() {
        OnGameOver?.Invoke();
    }
  
}
