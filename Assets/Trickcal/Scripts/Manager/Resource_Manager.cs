using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static EnumDict;
using static EventManager;
using static EventSubscriber;

public class Resource_Manager : MonoBehaviour
{
    //선택 타워 건설 재화
    int t_select;
    //일반 타워 건설
    int t_normal;
    //타워 업그레이드
    int t_up;
    //스펠 보유 현황
    List<bool> spells = new List<bool>();

    //목숨
    int life;

    //디스플레이 할 텍스트들
    public TMP_Text t_select_text;
    public TMP_Text t_normal_text;
    public TMP_Text t_up_text;
    public TMP_Text life_text;

    //재화 get & set
    public void set_normal(int value) {  t_normal = value; }
    public void set_select(int value) { t_select = value; }
    public void set_up(int value) { life = value; }
    public void set_life(int value) { life = value; }

    public int get_normal() { return t_normal; }
    public int get_select() { return t_select; }
    public int get_up() { return t_up; }
    public int get_life() {  return life; }

    //TODO : 스펠 구매를 이벤트로 감지하여
    //일회성 또는 웨이브마다 이벤트를 통해 스펠 기능을 구현
    

}
