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
        p.parentName = "부모객체";
        p.parentFunc();
        p.Attack();
        //p.forChild();

        Child c = new Child();
        //Child c = new Child(3);
        c.parentName = "자식객체";
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
        Debug.Log("부모 클래스를 생성합니다.");
    }

    public Parent(int i)
    {
        Debug.Log("부모 클래스를 " + i + "인자로 생성합니다.");
    }
    public string parentName;
    public void parentFunc()
    {
        Debug.Log("부모 함수를 실행합니다.");
        Debug.Log("이름은 : " + parentName);
    }

    protected void forChild()
    {
        Debug.Log("자식에서만 보입니다.");
    }

    public virtual void Attack()
    {
        Debug.Log("평타사용");
    }
}

public class Child : Parent
{
    public Child()
    {
        Debug.Log("자식 클래스를 생성합니다.");   
    }
    public void childFunc()
    {
        forChild();
    }

    public override void Attack()
    {
        Debug.Log("원거리 공격");
    }
}