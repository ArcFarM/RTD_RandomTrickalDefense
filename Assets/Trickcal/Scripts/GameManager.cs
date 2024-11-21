using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            //중복 생성 방지
            if(instance == null)
            {
                GameObject singleton = new GameObject();
                instance = singleton.AddComponent<GameManager>();
                DontDestroyOnLoad(singleton);
            }
            return instance;
        }
    }

    //현재 자원
    int life;
    int leaf;
    int mocaron;
    int coupon;
    //현재 스테이지
    int wave;
    //---------------------------적 스탯----------------------------
    //id
    int id;
    //체력
    double hp;
    //클래스(일반/특수/보스)
    enum Enemy_Class { Normal, Special, Boss };
    //특수 적 한정) 사용할 스펠
    enum Sp_Enemy_Spell { SpeedUp, HPRegen, DmgOne };
    //이동 속도
    float spd;
    //방어력
    int armor;

    //적 생성과 타겟팅, 제거를 담당할 전역 리스트
    private List<GameObject> Enemys = new List<GameObject>();

    //적 생성
    public void Create_Enemy(GameObject go)
    {
        //null check
        if (go == null || go.tag != "Enemy") return;

        //전역 리스트에 추가
        Enemys.Add(go);
        go.GetComponent<Enemy_Manager>();
    }
    public List<GameObject> Get_Enemy(){
        return Enemys;
    }
    public void Set_Enemy(List<GameObject> l)
    {
        Enemys = l;
    }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this)
        {
            //싱글톤은 오직 이 오브젝트의 인스턴스여야만 한다
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
