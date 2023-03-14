using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    [SerializeField] NoticePanel _panel;
   public void OnButtonPause()
   {
        _panel.Init("�׸��Ͻðڽ��ϱ�?", stop);
   }

    public void OnButtonRestart()
    {
        _panel.Init("ȯ���Ͻðڽ��ϱ�?", restart);
    }

    public void OnButtonOption()
    {
        _panel.Init("�ɼ��� ���ðڽ��ϱ�?", Option);
    }

    public void OnButtonInventory()
    {
        _panel.setCount("������ ���ðڽ��ϱ�?",3, Inven);
    }

    public void OnButtonSkill()
    {
        _panel.setCount("��ųâ�����ðڽ��ϱ�?", 5, skill);
    }
    void stop()
    {
        Debug.Log("������ �����մϴ�.");
    }
    void restart()
    {
        Debug.Log("ȯ�� �մϴ�.");
    }

    void Option()
    {
        Debug.Log("�ɼ��� �������ϴ�.");
    }
    void Inven(int i)
    {
        Debug.Log("������ �������ϴ�."+"���濡��"+i+"���� �������� ���ֽ��ϴ�.");
    }
    void skill(int i)
    {
        Debug.Log("��ųâ�� �������ϴ�." + i + "���� ��ų�� ������ �ֽ��ϴ�.");
    }
}
