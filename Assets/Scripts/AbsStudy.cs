using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsStudy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //AbsParent ab = new AbsParent();
        AbsChild ac = new AbsChild();
        ac.parentFunc();
        AbsParent ab = ac;
        ab.Action();
        ac.MyAction();
        ab.MyAction();
    }
}

public abstract class AbsParent
{
    public abstract void parentFunc();
    public virtual void Action()
    {
        Debug.Log("parent Action");
    }
    public void MyAction()
    {
        Debug.Log("parent MyAction");
    }
}

public class AbsChild : AbsParent
{
    public override void parentFunc()
    {

    }

    public override void Action()
    {
            Debug.Log("child Action");
    }
    
    public new void MyAction()
    {
        Debug.Log("child MyAction");
    }
}