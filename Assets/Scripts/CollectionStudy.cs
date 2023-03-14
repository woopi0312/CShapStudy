using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class CollectionStudy : MonoBehaviour
{
    private void Start()
    {
        //Exam1();
        //Exam2();
        Exam3();
    }

    void Exam3()
    {
        Inventory inven8 = new Inventory(8);
        Inventory inven4 = new Inventory(4);

        InvenItem item1 = new InvenItem();
        item1._count = 2;
        item1._name = "지렛대";
        item1._weight = 2.5f;
        item1._isUnique = false;
        item1._isUse = false;

        InvenItem item2 = new InvenItem();
        item2._count = 1;
        item2._name = "후라이팬";
        item2._weight = 4.5f;
        item2._isUnique = true;
        item2._isUse = true;

        InvenItem item3 = new InvenItem();
        item3._count = 1;
        item3._name = "후라이팬";
        item3._weight = 4.5f;
        item3._isUnique = true;
        item3._isUse = true;

        inven4.Add(item2);
        inven4.Add(item3);
        inven4.Add(item1);
        inven4.Add(item1);

        inven4.View();
    }

    void Exam2()
    {
        Skill sk1 = new Skill();
        sk1.Id = 1;
        sk1.Name = "근접 공격 강화";

        Skill sk2 = new Skill();
        sk2.Id = 2;
        sk2.Name = "원거리 공격 강화";

        Skill sk3 = new Skill();
        sk3.Id = 3;
        sk3.Name = "내성 강화";

        SkillListManager skManager = new SkillListManager();
        skManager.Add(sk3);
        skManager.Add(sk1);

        skManager.Add(sk2);

        skManager.View();

        skManager.Sort();

        skManager.View();

    }

    void Exam1()
    {
        Queue q = new Queue();
        q.Enqueue(10);
        q.Enqueue(20);
        q.Enqueue(30);
        q.Enqueue(40);
        q.Enqueue(50);

        int[] ints = new int[5];
        ints[0] = 1;
        ints[1] = 2;
        ints[2] = 3;
        ints[3] = 4;
        ints[4] = 5;


        int[] ints2 = new int[6];
        //ints.CopyTo(ints2, 0);

        //q.CopyTo(ints2, 1);
        //foreach(int i in ints2)
        //{
        //    Debug.Log("값 : " +i);
        //}

        //Debug.Log("q Count is : " + q.Count);

        Debug.Log("배열은 고정 사이즈 인가요? : " + ints2.IsFixedSize);

        ArrayList array = new ArrayList();

        Debug.Log("ArrayList는 고정 사이즈 인가요? " + array.IsFixedSize);

        string s1 = "문자열을 추가합니다.";
        string s2 = "삭제될 데이터 입니다.";

        List<string> strings = new List<string>();
        strings.Add(s1);
        strings.Add(s2);

        Debug.Log("데이터 확인" + strings.Contains(s1));
        Debug.Log("인덱스 확인" + strings.IndexOf(s2));

        IList il = strings;

        Debug.Log("List<string>은 고정 사이즈 인가요? " + il.IsFixedSize);

        Hashtable hs = new Hashtable();
        Dictionary<int, string> dics = new Dictionary<int, string>();

        string s3 = "세번째 값입니다.";
        dics.Add(1, s1);
        dics.Add(2, s2);
        dics.Add(10, s3);

        Debug.Log("키 데이터 : " + dics.Keys);
        Debug.Log("값 데이터 : " + dics.Values);

        foreach (KeyValuePair<int, string> kvp in dics)
        {
            Debug.Log("key : " + kvp.Key + ", value : " + kvp.Value);
        }
        foreach (int i in dics.Keys)
        {
            Debug.Log("keys : " + i);
        }

        foreach (string str in dics.Values)
        {
            Debug.Log("values : " + str);
        }
        Debug.Log("is contained ? : " + dics.ContainsKey(10));
        Debug.Log("is contained value? : " + dics.ContainsValue(s3));

        Array ar = ints2;
    }
}

public class Inventory : InvenItem, ICollection
{
    InvenItem[] _items;
    float _maxWeight;
    public int Count { get; }
    public bool IsSynchronized { get; }
    public object SyncRoot { get; }

    public void CopyTo(Array array, int index) { }

    public Inventory(int i)
    {
        _items = new InvenItem[i];
        _maxWeight = i * 3;
    }

    public IEnumerator GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    public void Add(InvenItem item)
    {
        if (HaveUniqueItem(item)) return;
        if (!WeightCheck(item)) return;
        addItem(item);
    }

    bool WeightCheck(InvenItem item)
    {
        float fullWeight = 0f;
        foreach (InvenItem data in _items)
        {
            if (data == null) continue;
            fullWeight += data._weight;
        }
        fullWeight += item._weight;
        if (fullWeight > _maxWeight) return false;
        return true;
    }

    void addItem(InvenItem item)
    {
        bool isFull = true;
        bool isAdded = false;
        foreach (InvenItem data in _items)
        {
            if (data == null) continue;
            if (data._name == item._name)
            {
                data._count += item._count;
                isAdded = true;
                Debug.Log(item._name + "아이템을 가방에 " + item._count + "개 만큼 추가했습니다.");
            }
        }
        if (isAdded) return;
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                _items[i] = item;
                isFull = false;
                Debug.Log(item._name + " 아이템을 가방에 추가했습니다.");
                break;
            }
        }
        if (isFull) Debug.Log("가방이 가득 찼습니다.");
    }

    public void View()
    {
        foreach (InvenItem item in _items)
        {
            if (item == null) continue;
            Debug.Log("item Name : " + item._name + ", count : " + item._count);
        }
    }

    bool HaveUniqueItem(InvenItem item)
    {
        if (!item._isUnique) return false;
        foreach (InvenItem data in _items)
        {
            if (data == null) continue;
            if (data._name == item._name)
            {
                Debug.Log("같은 아이템이 이미 있습니다.");
                return true;
            }
        }
        return false;
    }
}

public class InvenItem
{
    public float _weight;
    public string _name;
    public bool _isUse;
    public bool _isUnique;
    public int _count;
}

interface IListId
{
    long id { get; set; }
}

public class ListManager<T>  where T : class
{
    List<T> _lst = new List<T>();
    Dictionary<long,T> _dic = new Dictionary<long,T>();

    public void Sort() { }
    
    public void Add( T t)
    {
        _lst.Add(t);
        _dic.Add(0,t);
    }

    public void Remove(T t) { }

    public void View()
    {
        Debug.Log("전체 T의 갯수는 : "+ _lst.Count);
        foreach (T t in _lst) { }
    }
}
public class SkillListManager
{
    List<Skill> _lstSkills = new List<Skill>();
    Dictionary<int, Skill> _dicSkills = new Dictionary<int, Skill>();

    public void Sort()
    {
        _lstSkills = _lstSkills.OrderBy(i => i.Id).ToList();
    }

    public void Add(Skill sk)
    {
        if (_dicSkills.ContainsKey(sk.Id) == false)
        {
            _lstSkills.Add(sk);
            _dicSkills.Add(sk.Id, sk);
        }
        else
        {
            Debug.Log(sk.Id + "Id 데이터가 이미 있습니다.");
        }
    }

    public void Remove(Skill sk)
    {
        if (_dicSkills.ContainsKey(sk.Id) == true)
        {
            _lstSkills.Remove(sk);
            _dicSkills.Remove(sk.Id);
        }
        else
        {
            Debug.Log(sk.Id + " Id의 데이터가 없습니다.");
        }
    }

    public void View()
    {
        Debug.Log("전체 Skill의 갯수는 : " + _lstSkills.Count);
        foreach (Skill sk in _lstSkills)
        {
            Debug.Log("ID : " + sk.Id + ", Name : " + sk.Name);
        }
    }


}

public class Skill
{
    public int Id;
    public string Name;
}