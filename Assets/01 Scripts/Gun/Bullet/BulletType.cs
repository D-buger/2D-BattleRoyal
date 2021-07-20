using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eBulletType
{
    Basic,
    Ice,
    Blood,
}

public static class BulletType
{
    public static Dictionary<eBulletType, System.Type> BulletTypeDic =
        new Dictionary<eBulletType, System.Type>()
        {
            {eBulletType.Basic, typeof(BasicBullet)},
        };
}