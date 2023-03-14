using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    List<Monster> _monsters = new List<Monster>();
    public void makeRedSlime()
    {
        _monsters.Add(new RedSlime());
    }

    public void makeBlueSlime()
    {
        _monsters.Add(new BlueSlime());
    }

    public void makeOrc()
    {
        _monsters.Add(new Orc());
    }

    public void AllMonsterAttack()
    {
        Debug.Log("몬스터 갯수는" + _monsters.Count);
        foreach(Monster data in _monsters)
        {
            data.Attack();
        }
    }
}

public class Monster
{
    public string Name;
    public virtual void Attack()
    {

    }
}

public class RedSlime : Monster
{
    public RedSlime() { Name = "레드 슬라임"; }
    public override void Attack()
    {
        Debug.Log(Name + "이 화염 공격을 시전합니다.");
    }
    
}

public class BlueSlime : Monster
{
    public BlueSlime() { Name = "파란슬라임"; }
    public override void Attack(){ Debug.Log(Name + "이 냉기 공격을 시전합니다.");}
}

public class Orc : Monster 
{
    public Orc() { Name = "오크"; }
    public override void Attack(){ Debug.Log(Name + "이 강력한 물리 공격을 시전합니다.");}
}