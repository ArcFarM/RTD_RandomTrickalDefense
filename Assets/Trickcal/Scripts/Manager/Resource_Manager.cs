using System.Collections;
using System.Collections.Generic;
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

    //TODO : 재화 get & set
    
    //TODO : 스펠 구매를 이벤트로 감지하여
    //일회성 또는 웨이브마다 이벤트를 통해 스펠 기능을 구현
    

}
