using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

//public delegate void doAction();
public class NoticePanel : MonoBehaviour
{
    [SerializeField] Text _text;
    //doAction _action;
    Action _action;
    Action<int> _intAction;
    int count = 0;

    public void Init(string text, Action action)
    {
        gameObject.SetActive(true);
        _text.text = text;
        _action = action;
    }

    public void setCount(string text, int i, Action<int> action)
    {
        gameObject.SetActive(true);
        _text.text = text;
        _intAction = action;
        count = i;
    }
    public void OnButtonYes()
    {
        _action?.Invoke();
        _intAction?.Invoke(count);
        close();
    }

    public void OnButtonNO()
    {
        close();
    }

    void close()
    {
        _action = null;
        _intAction = null;
        gameObject.SetActive(false);
    }
}
