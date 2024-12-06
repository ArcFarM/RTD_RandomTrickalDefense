using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    //타워 기본 공격을 실행하는 매커니즘
    //가장 앞에 존재하는(진행 거리가 제일 많은) 적을 조준한다
    //적이 공격되기 전에 죽었다면, 코루틴을 다시 실행한다

    // Start is called before the first frame update
 
    public GameObject tower;
    //싱글톤을 이용하여 적 정보를 가져온다
    private List<GameObject> enemys;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
