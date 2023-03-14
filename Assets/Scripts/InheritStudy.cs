using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritStudy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Parent.p = new Parent();
        Parent p = new Parent(2);
        p.parentName = "�θ�ü";
        p.parentFunc();
        p.Attack();
        //p.forChild();

        Child c = new Child();
        //Child c = new Child(3);
        c.parentName = "�ڽİ�ü";
        c.parentFunc();
        c.childFunc();

        Parent p2 = c;
        p2.Attack();
        Debug.Log("name : " + p2.parentName);
    }
}

public class Parent
{
    public Parent()
    {
        Debug.Log("�θ� Ŭ������ �����մϴ�.");
    }

    public Parent(int i)
    {
        Debug.Log("�θ� Ŭ������ " + i + "���ڷ� �����մϴ�.");
    }
    public string parentName;
    public void parentFunc()
    {
        Debug.Log("�θ� �Լ��� �����մϴ�.");
        Debug.Log("�̸��� : " + parentName);
    }

    protected void forChild()
    {
        Debug.Log("�ڽĿ����� ���Դϴ�.");
    }

    public virtual void Attack()
    {
        Debug.Log("��Ÿ���");
    }
}

public class Child : Parent
{
    public Child()
    {
        Debug.Log("�ڽ� Ŭ������ �����մϴ�.");   
    }
    public void childFunc()
    {
        forChild();
    }

    public override void Attack()
    {
        Debug.Log("���Ÿ� ����");
    }
}