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
        Debug.Log("���� ������" + _monsters.Count);
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
    public RedSlime() { Name = "���� ������"; }
    public override void Attack()
    {
        Debug.Log(Name + "�� ȭ�� ������ �����մϴ�.");
    }
    
}

public class BlueSlime : Monster
{
    public BlueSlime() { Name = "�Ķ�������"; }
    public override void Attack(){ Debug.Log(Name + "�� �ñ� ������ �����մϴ�.");}
}

public class Orc : Monster 
{
    public Orc() { Name = "��ũ"; }
    public override void Attack(){ Debug.Log(Name + "�� ������ ���� ������ �����մϴ�.");}
}