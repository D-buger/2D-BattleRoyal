using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildMagazine : Magazine
{
    public Magazine SetBullet(eBulletType type, int i = 10)
    {
        bullet.Add(type, i);

        return this;
    }

    public Magazine Build()
    {
        if (bullet.Count == Enum.GetNames(typeof(eBulletType)).Length)
            return (Magazine)this;
        else
        {
            Debug.LogError("총알 종류별 초기화가 맞지 않습니다");
            return null;
        }
    }
}
