using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    //현재 자원 -> 별도 더미오브젝트가 수행할 예정(삭제)
    public int life;
    public int leaf;
    public int mocaron;
    public int coupon;
    //현재 스테이지 넘버
    public int wave;
    public TMP_Text Life_Count;

    //적을 관리할 리스트 : 현재 생존해 있는 적들과 그 정보를 저장
    private List<GameObject> Enemys = new List<GameObject>();
    
    public List<GameObject> Get_Enemy(){
        return Enemys;
    }
    public void Set_Enemy(List<GameObject> l)
    {
        Enemys = l;
    }


    public void Life_Decrease(int damage){
        life -= damage;
        Life_Count.text = life.ToString();
    }

    //싱글톤 설정
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

    void Start(){
        Life_Count.text = life.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
