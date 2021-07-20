using System.Collections.Generic;
using UnityEngine;
using System;

public class Magazine
{
    protected Dictionary<eBulletType, int> bullet = new Dictionary<eBulletType, int>();

    protected Magazine()
    {
    }

    public GameObject Get(eBulletType type, Vector2 startVec, Vector2 moveVec)
    {
        if (bullet[type] == 0)
        {
            return null;
        }
        else if (bullet[type] > 0)
        {
            bullet[type]--;
        }
        GameObject obj = ObjectPooling.Inst.Get();
        obj.AddComponent(BulletType.BulletTypeDic[eBulletType.Basic]);
        BulletDefault bulDe = obj.GetComponent<BulletDefault>();
        bulDe.Set(startVec, moveVec);
        return obj;
    }

    public void Set(Magazine mag)
    {
        for(int i = 0; i < bullet.Count; i++)
        {
            bullet[(eBulletType)i] += mag.bullet[(eBulletType)i];
        }
    }
    
}