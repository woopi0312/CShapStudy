using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    [SerializeField] NoticePanel _panel;
   public void OnButtonPause()
   {
        _panel.Init("그만하시겠습니까?", stop);
   }

    public void OnButtonRestart()
    {
        _panel.Init("환생하시겠습니까?", restart);
    }

    public void OnButtonOption()
    {
        _panel.Init("옵션을 여시겠습니까?", Option);
    }

    public void OnButtonInventory()
    {
        _panel.setCount("가방을 여시겠습니까?",3, Inven);
    }

    public void OnButtonSkill()
    {
        _panel.setCount("스킬창을여시겠습니까?", 5, skill);
    }
    void stop()
    {
        Debug.Log("게임을 종료합니다.");
    }
    void restart()
    {
        Debug.Log("환생 합니다.");
    }

    void Option()
    {
        Debug.Log("옵션을 열었습니다.");
    }
    void Inven(int i)
    {
        Debug.Log("가방을 열었습니다."+"가방에는"+i+"개의 아이템이 들어가있습니다.");
    }
    void skill(int i)
    {
        Debug.Log("스킬창을 열었습니다." + i + "개의 스킬을 가지고 있습니다.");
    }
}
