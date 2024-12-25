using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Tile : MonoBehaviour
{
    /*
     * 구현할 기능 : 설치할 타워와, 빛나기에 필요한 마테리얼 추가
     */

    //이 오브젝트의 렌더러, 코드 축약용
    Renderer renderer;

    //이 타일에 설치될 타워
    GameObject tower;

    //타워 업그레이드 가능 표시 화살표
    public GameObject up_arrow;

    private void Start() {
        renderer = GetComponent<Renderer>();
        if(up_arrow != null ) up_arrow.SetActive(false);
    }

    private void Update() {
      
    }

    //타워가 설치되어 있다면 true를 반환
    public bool Tower_Check() {
        if (tower == null) return false;
        else return true;
    }

    //타워를 통째로 반환 (설치된 타워 수정용)
    public GameObject Get_Tower() {
        GameObject copy = tower;
        return copy;
    }

    //설치된 타워를 수정, nullable 이유 = 타워 판매 가능
    public void Set_Tower(GameObject? t) { tower = t; }

    //특정 조건에서 빛나서 상호작용 가능한 상태임을 알림

    bool blink_switch = false;
    public void Glow_Tile() {
        //코루틴을 사용하여 투명화 조절
        //이것을 2회 반복
        if(!blink_switch) {
            StartCoroutine(Blinking());
        }
    }

    //깜빡임을 결정하는 코루틴
    IEnumerator Blinking() {
        blink_switch = true;
        Color original = renderer.material.color;
        Color transp = original;

        float glowing = 0f;
        while (glowing < 1f) {
            glowing += Time.deltaTime * 2f;
            //0.5f를 사용하지 않고 *2를 하는 이유 : 이 수를 그대로 렌더러에 적용할 것이기 때문 (0 ~ 1 사이를 가지므로)
            transp.a = 1f - glowing;
            renderer.material.color = transp;
            Debug.Log("now : "+ glowing);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        Debug.Log("------------------------------------------");

        while(glowing > 0f) {
            glowing -= Time.deltaTime * 2f;
            transp.a = 1f - glowing;
            renderer.material.color = transp;
            Debug.Log("now : " + glowing);
            yield return null;
        }

        yield break;
    }

    //업그레이드 가능 화살표 표시 및 지우기
    public void Show_UpArrow() {
        Vector3 new_pos = transform.position;
        new_pos.y = transform.position.y + 2;
        up_arrow.transform.position = new_pos;
        
        up_arrow.SetActive(true);
    }

    public void Hide_UpArrow() {
        up_arrow.SetActive(false);
    }

    IEnumerator Arrow_Test() {
        for(int i = 0; i < 10; i++) {
            Debug.Log("Arrow show");
            Show_UpArrow();
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Arrow Hide");
            Hide_UpArrow();
            yield return new WaitForSeconds(2.0f);
        }

    }
}
