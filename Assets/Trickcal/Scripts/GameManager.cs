using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button Enemy_Spawn_button;
    private IEnumerator coroutine;
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
    public int life;
    public int leaf;
    public int mocaron;
    public int coupon;
    //현재 스테이지
    public int wave;


    //적 생성과 타겟팅, 제거를 담당할 전역 리스트
    private List<GameObject> Enemys = new List<GameObject>();

    //적 소환을 위한 버튼과 스폰 타이머
    public void Spawn_Enemy_Button(){
        coroutine = CountDownStart(10);
        StartCoroutine(coroutine);
        return;
    }

    IEnumerator CountDownStart(int CountDown)
    {
        while (CountDown > 0)
        {//카운트다운이 0이 될때까지
            CountDown--;//카운트다운 감소
            Create_Enemy();
            yield return new WaitForSeconds(1.0f);//1초대기
        }
    }
    //적 생성
    public void Create_Enemy()
    {
        //Enemy_Manager를 통해 세팅
        GameObject go = new GameObject();
        Enemy_Manager em = go.AddComponent<Enemy_Manager>();

        //특수 적 소환 버튼 누르기 감지
        //if(특수 적 소환 버튼 눌렸다면) go = em.Enemy_Setting(wave, true); else
        go = em.Enemy_Setting(wave, false);

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
        Enemy_Spawn_button.onClick.AddListener(Spawn_Enemy_Button);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
