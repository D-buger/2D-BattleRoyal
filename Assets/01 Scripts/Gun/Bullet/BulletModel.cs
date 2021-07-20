using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(int damage, float speed, float lifeDist)
    {
        bulletSpeed = speed;
        this.damage = damage;
        this.lifeDist = lifeDist;
    }

    public void Set(Vector2 _startVec, Vector2 _moveVec)
    {
        startVec = _startVec;
        moveVec = _moveVec;
    }

    public float bulletSpeed { get; private set; }
    public int damage { get; private set; }

    public Vector2 moveVec;
    public Vector2 startVec;
    public float lifeDist;
}