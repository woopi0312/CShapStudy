using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GenericStudy : MonoBehaviour
{
    List <string> _strs = new List<string>();  
    List <int> _ints = new List<int>();
    int count = 1;
    void Start()
    {
        ListManager<HeroForLM> heroList = new ListManager<HeroForLM>();
        ListManager<MonsterLM> monsterList= new ListManager<MonsterLM>();
        Exam5();
    }

    
    void Exam1()
    {
        //Time.time.ToString();
        if(Input.GetMouseButton(0)) 
        {
            _strs.Add(Time.time.ToString());
        }
        if(Input.GetMouseButtonDown(1))
        {
            foreach(string str in _strs) 
            {
                Debug.Log(str);
            }
        }
    }

    void Exam2()
    {
        
        if(Input.GetMouseButton(0)) 
        {
            _ints.Add(count++);
           
        }
        if(Input.GetMouseButtonDown(1))
        {
            foreach(int data in _ints)
            {
                Debug.Log(data);
            }
        }
    }

    void Exam3()
    {
        ListManager<HeroForLM> heroList = new ListManager<HeroForLM>();

        HeroForLM hlm1 = new HeroForLM();
        hlm1.id = 1;
        hlm1.Name = "영웅";
        HeroForLM hlm2 = new HeroForLM();
        hlm2.id = 2;
        hlm2.Name = "영웅2";
        HeroForLM hlm3= new HeroForLM();
        hlm3.id = 3;
        hlm3.Name = "영웅3";
        HeroForLM hlm4 = new HeroForLM();
        hlm4.id = 4;
        hlm4.Name = "영웅4";

        heroList.Add(hlm1);
        heroList.Add(hlm2);
        heroList.Add(hlm3);
        heroList.Add(hlm4);

        heroList.View();
    }

    void Exam4()
    {
        ListManager<MonsterLM> monsterList = new ListManager<MonsterLM>();

        MonsterLM mlm1 = new MonsterLM();
        mlm1.id = 1;
        mlm1.Name = "몬스터";
        MonsterLM mlm2 = new MonsterLM();
        mlm2.id = 2;
        mlm2.Name = "몬스터";
        MonsterLM mlm3 = new MonsterLM();

    }

    void Exam5()
    {
        int i = 0;
        int j = 10;
        Add(i, j);
        string str1 = "문자열1";
        string str2 = "문자열2";
        Add(str1, str2);
    }
    
    void Add<T>(T i, T j)
    {
        decimal x = 0;
        decimal y = 0;
        bool parseI = decimal.TryParse(i.ToString(), out x);
        bool parseJ = decimal.TryParse(j.ToString(), out y);
        if (parseI == true && parseJ == true) 
        {
            Debug.Log("Sum Result is : " + (x + y));
        }
        else
        {
            Debug.Log("Sum Result is : "+ i.ToString() + j.ToString());
        }
        
    }

    private void Update()
    {
       // Exam2();
    }

    public class ItemForLM
    {
        public string Name;
        public float Weight;
    }

    public class HeroForLM : IListId
    {
        public long id { get; set; }
        public string Name;
        public int HeroClass;
        public int LV;
    }

    public class MonsterLM : IListId 
    {
        public long id { get; set; }
        public string Name;
        public int EXP;
    }
     
    public interface IListId
    {
        long id { get; set; }
    }

    public class ListManager<T> where T : IListId
    {
        List<T> _lst = new List<T>();
        Dictionary<long, T> _dic = new Dictionary<long, T>();

        public void Sort() 
        {
            _lst = _lst.OrderBy(i=>i.id).ToList();
        }

        public void Add(T t)
        {
            if (_dic.ContainsKey(t.id) == false)
            {
                _lst.Add(t);
                _dic.Add(t.id, t);
            }    
            else
            {
                Debug.Log(t.id + "Id 데이터가 이미 있습니다.");
            }
        }

        public void Remove(T t) 
        {
            if (_dic.ContainsKey(t.id) == true)
            {
                _lst.Remove(t);
                _dic.Remove(t.id);
            }
            else
            {
                Debug.Log(t.id + " Id의 데이터가 없습니다.");
            }
        }

        public void View()
        {
            Debug.Log("전체 Skill의 갯수는 : " + _lst.Count);
            foreach (T t in _lst)
            {
                Debug.Log("ID : " + t.id);
            }
        }
    }
}


