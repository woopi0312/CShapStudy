using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InterStudy : MonoBehaviour
{
    List<IHit> hits = new List<IHit>();
    List<MonsterForInter> lstMons = new List<MonsterForInter>();
    int i = 0;
    HitManager _hit;
    // Start is called before the first frame update
    void Start()
    {
        //CChild cc = new CChild();
        // IComm ic = cc;
        // ic.func();
        _hit = new HitManager(lstMons);
        //ticks.Add(new Orc2());
        //ticks.Add(new Orc2());
        //ticks.Add(new Hero());
        //ticks.Add(new Hero()); 
        //ticks.Add(new Hero());
        //ticks.Add(new Hero());
        MonsterForInter mon = new MonsterForInter(3);
        //mon.Attack();
        IAttack ia = mon;
        ia.Attack();
        IFighter ifi = mon;
        ifi.Attack();
        IChild ic = mon;
        IParent ip = mon;
        ic.parent();
        ip.parent();

    }

    public void OnButtonMakeMonster()
    {
        MonsterForInter mon = new MonsterForInter(i);
        hits.Add(mon);
        lstMons.Add(mon);
        i++;
    }

    public void OnButtonAllMonsterHits()
    {
        foreach(IHit data in hits)
        {
            data.Hitted(_hit);
        }
    }
    List<ITick> ticks = new List<ITick>();
    float _timer = 0f;

    private void Update()
    {
        
        {
            _timer += Time.deltaTime;
            if(_timer > 0.3f)
            {
                foreach(ITick data in ticks)
                {
                    data.OnTick();
                }
            }
        }
    }
}

interface ITick
{
    void OnTick();
}

public class Orc2 : ITick
{
    public void OnTick() 
    {
        Debug.Log("Ÿ���� ã�´�.");
    }
}

public class Hero : ITick
{
    public void OnTick()
    {
        
    }
}
interface IComm
{
    void func();
}

public class CChild : IComm
{
    public void func()
    {
        Debug.Log("�������̽� ���� ����");
    }
}

interface IAttack
{
    void Attack();
}

interface IFighter
{
    void Attack();
}

interface IHit
{
    void Hitted(HitManager hit);
}

interface IParent
{
    void parent();
}

interface IChild : IParent
{
    void child();
}

public class MonsterForInter : IAttack, IHit, IFighter, IChild
{
    int i = 0;

    public void child()
    {
        Debug.Log("�ڽ� �������̽��� �����߽��ϴ�.");
    }

    public void parent()
    {
        Debug.Log("�θ� �������̽��� �����߽��ϴ�.");
    }
    public MonsterForInter(int a)
    {
        i = a;
    }
    //public void Attack()
    //{
    //    Debug.Log("���Ͱ� �����մϴ�.");
    //}

    void IAttack.Attack()
    {
        Debug.Log("�������� Attack�� �����մϴ�.");
    }

    void IFighter.Attack()
    {
        Debug.Log("������ attack�� �����մϴ�.");
    }
    public void Hitted(HitManager hit)
    {
        Debug.Log(i + "��° ���Ͱ�" + hit.GetAttacker() + "���� ���� ���߽��ϴ�!.");
    }
}

