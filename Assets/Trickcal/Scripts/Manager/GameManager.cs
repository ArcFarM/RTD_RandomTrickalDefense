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

    //현재 스테이지 넘버
    public int wave;

    //적을 관리할 리스트 : 현재 생존해 있는 적들과 그 정보를 저장
    private List<GameObject> Enemys = new List<GameObject>();
    
    public List<GameObject> Get_Enemy(){
        return Enemys;
    }
    public void Set_Enemy(List<GameObject> l){
        Enemys = l;
    }

    //현재 게임 내에 존재하는 타워의 종류와 갯수를 저장할 딕셔너리
    Dictionary<string, int> tower_count = new Dictionary<string, int>();
    public int Get_dict(string str) {
        if (tower_count.ContainsKey(str))
            return tower_count[str];
        else return -1;
    }

    public void Set_dict(string str, int val) {
        if (tower_count.ContainsKey(str)) tower_count[str] = val;
        else tower_count.Add(str, 1);
        if (tower_count[str] < 0) tower_count[str] = 0;
    }

    public int Get_Tower_Count(string id) {
        if (tower_count.ContainsKey(id)) { return tower_count[id]; }
        else {
            Debug.LogError("Wrong Id has been sent.");
            return -1;
        }
    }

    public void Set_Tower_Count(string id) {
        if (tower_count.ContainsKey(id)) { tower_count[id]++; }
        else {
            Debug.LogError("Wrong Id has been sent.");
        }
    }

    //타워 목록 리스트 <<< 타워 설치, 합성에 쓰일 리스트
    public List<List<GameObject>> All_Towers = new List<List<GameObject>>();

    public List<GameObject> Lv1_Towers = new List<GameObject>();
    public List<GameObject> Lv2_Towers = new List<GameObject>();
    public List<GameObject> Lv3_Towers = new List<GameObject>();
    public List<GameObject> Lv4_Towers = new List<GameObject>();
    public List<GameObject> Lv5_Towers = new List<GameObject>();

    //이 메서드를 사용해서 레벨대에 맞는 랜덤 타워 얻기
    public GameObject Get_RandomTower(int lvl) {
        int rnd = Random.Range(0, All_Towers[lvl].Count);
        return All_Towers[lvl][rnd];
    }

    //선택 타워 건설에 사용
    public GameObject Get_SelectTower(int lvl, int idx) {
        return All_Towers[lvl][idx];
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
        //딕셔너리 초기화
        All_Towers.Add(Lv1_Towers);
        All_Towers.Add(Lv2_Towers);
        All_Towers.Add(Lv3_Towers);
        All_Towers.Add(Lv4_Towers);
        All_Towers.Add(Lv5_Towers);

        for (int i = 0; i < All_Towers.Count; i++) {
            for(int j = 0; j <  All_Towers[i].Count; j++) {
                //string tower_id = All_Towers[i][j].GetComponent<TowerStats>().Get_Stat(EnumDict.T_stats.id).ToString();
                //tower_count.TryAdd(tower_id, 0);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
