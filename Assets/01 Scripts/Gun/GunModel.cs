using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModel
{
    public GunModel(Magazine mag, Transform obj)
    {
        this.mag = mag;
        gunObj = obj;
    }

    public eBulletType selectedBullet { get; set; }
    public Magazine mag { get; private set; }
    public float shotDelay = 0.5f;
    public Transform gunObj { get; private set; }

    public float reloadingTime = 1f;
}
