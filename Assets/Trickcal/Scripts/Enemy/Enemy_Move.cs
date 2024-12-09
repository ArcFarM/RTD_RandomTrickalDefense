using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    //다음 이동할 지점, 마지막 지점인 경우 null로 표기
    public GameObject? next = null;

    //적과 웨이포인트가 만났을 때
    private void OnTriggerEnter(Collider other)
    {
        if (next != null && other.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision Detected");
            Transform target = other.gameObject.transform;
            //적을 다음 웨이포인트가 위치한 지역으로 옮긴다
            target.position = Vector3.MoveTowards(target.position,
                                                  next.gameObject.transform.position,
                                                  1.5f/*target.GetComponent<Enemy_Manager>().spd*/);
        }
        else if(next == null)
        {
            //싱글톤 인스턴스 받아오기
            GameManager gm = GameManager.Instance;
            //TODO : 오브젝트 통과 이벤트
        }
    }
}
