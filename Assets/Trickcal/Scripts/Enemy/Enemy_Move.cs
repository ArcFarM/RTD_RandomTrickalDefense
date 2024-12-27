using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumDict;

public class Enemy_Move : MonoBehaviour
{
    //다음 이동할 지점, 마지막 지점인 경우 null로 표기
    public GameObject? next = null;

    IEnumerator Move_to_Next(GameObject move_this, Transform to_here)
    {
        yield return new WaitForSeconds(1.0f);
        //디버깅 용
        //Debug.Log("Coroutine Started");
        //코드 축약을 위한 선언
        float spd = (float)move_this.GetComponent<Enemy_Stat>().Get_List(Stats.speed);

        while (Vector2.Distance(move_this.transform.position, to_here.position) > 0.1f)
        {
            //거리가 '붙었다' 라고 판정될 때까지 이동 시킨다
            move_this.transform.position
            = Vector2.MoveTowards(move_this.transform.position, to_here.position, Time.deltaTime * spd);

            yield return null;
        }


    }

    //적과 웨이포인트가 만났을 때
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (next != null && other.gameObject.tag == "Enemy")
        {
            //Debug.Log("Collision Detected");
            Transform target = other.gameObject.transform;
            //적을 다음 웨이포인트가 위치한 지역으로 옮긴다
            //코루틴을 사용하여 Update를 사용하지 않고 이동시킨다
            StartCoroutine(Move_to_Next(other.gameObject, next.transform));
        }
        else if(next == null)
        {
            //싱글톤 인스턴스 받아오기
            GameManager gm = GameManager.Instance;
            gm.Life_Decrease(1);
            //TODO : 오브젝트 통과 이벤트

        }
    }
}
