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
        Debug.Log("타겟을 찾는다.");
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
        Debug.Log("인터페이스 구현 내용");
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
        Debug.Log("자식 인터페이스를 구현했습니다.");
    }

    public void parent()
    {
        Debug.Log("부모 인터페이스를 구현했습니다.");
    }
    public MonsterForInter(int a)
    {
        i = a;
    }
    //public void Attack()
    //{
    //    Debug.Log("몬스터가 공격합니다.");
    //}

    void IAttack.Attack()
    {
        Debug.Log("공격자의 Attack을 구현합니다.");
    }

    void IFighter.Attack()
    {
        Debug.Log("전사의 attack을 구현합니다.");
    }
    public void Hitted(HitManager hit)
    {
        Debug.Log(i + "번째 몬스터가" + hit.GetAttacker() + "에게 공격 당했습니다!.");
    }
}

