using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager
{
    List<MonsterForInter> lstMons = new List<MonsterForInter>();
    public HitManager(List<MonsterForInter> lstMons)
    {
        this.lstMons = lstMons;
    }
    public int GetAttacker()
    {
        int i = Random.Range(0, lstMons. Count);
        return i;
    }
}