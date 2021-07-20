using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : BulletDefault
{
    public BasicBullet()
        : base(1, 0.5f) { }

    public override void Set(Vector2 _startVec, Vector2 _moveVec)
    {
        model.Set(_startVec, _moveVec);
        gameObject.transform.position = _startVec;
    }

    protected override void BeforeOnTrigger(Collider2D collision)
    {
    }
}