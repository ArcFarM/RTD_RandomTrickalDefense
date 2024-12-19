using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    //설치 가능 지역들을 담을 리스트 
    public List<GameObject> tiles = new List<GameObject>();

    /*
     * 구현할 기능 : 키보드 입력에 반응하여 변하는 기능 넣기
     */
    private void Update() {
        if (Input.GetKey(KeyCode.W)) React_up();
    }

    //합성 가능한 타워 표시
    public void React_up() {
        //TODO : 코루틴에는 타워 리스트가 여러개 있는데, 이중 무슨 타워가 몇 개 있는 지 재는 것을 사용
        //2개 이상 존재하되 5단계가 아닌 타워에 해당하는 id를 가진 타일을 전부 밝게 빛나게 실시
    }
    
}
