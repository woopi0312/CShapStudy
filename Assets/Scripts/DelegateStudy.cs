using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void TwoInt(int i, int j);
public class DelegateStudy : MonoBehaviour
{
    private void Start()
    {
        TwoInt func = myFunc;
        func += secondFunc;
        func -= myFunc;
        //func = strFunc;
        func(4, 5);
        
    }

    void secondFunc(int a1, int a2)
    {
        Debug.Log("���� ���� ����� :" + (a1 * a2));
    }
    void myFunc(int a, int b)
    {
        Debug.Log("���� ����� :"+ (a+b));   
    }
    string strFunc()
    {
        return "";
    }
}
