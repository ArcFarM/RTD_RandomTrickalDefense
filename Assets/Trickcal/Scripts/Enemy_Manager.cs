using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    List<GameObject> enemys = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        enemys = GameManager.Instance.Get_Enemy();
    }

    //적 생성하기
    public void Create_Enemy(GameObject go)
    {
        enemys.Add(go);
    }
    //적 제거하기
    public void Destroy_Enemy(GameObject go)
    {
        enemys.Remove(go);
        GameManager.Instance.Set_Enemy(enemys);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
