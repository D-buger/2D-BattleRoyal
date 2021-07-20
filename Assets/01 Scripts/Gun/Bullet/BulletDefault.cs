using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public abstract class BulletDefault : MonoBehaviour
{
    protected BulletModel model;

    protected BulletDefault(int damage, float speed, float lifeDist = 100f)
    {
        model = new BulletModel(damage, speed, lifeDist);
    }
    
    protected virtual void Update()
    {
        CheckLife();
    }

    protected virtual void FixedUpdate()
    {
       MoveTo();
    }

    protected virtual void MoveTo()
    {
        transform.Translate(model.moveVec * model.bulletSpeed);
    }

    protected void CheckLife()
    {
        if(Vector2.Distance(model.startVec, transform.position)  >= model.lifeDist)
        {
            Destroy();
        }
    }

    protected void Destroy()
    {
        ObjectPooling.Inst.Set(this.gameObject);
    }

    public abstract void Set(Vector2 _startVec, Vector2 _moveVec);

    protected abstract void BeforeOnTrigger(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BeforeOnTrigger(collision);
        if (collision.CompareTag("Enemy"))
        {
            PlayerModel plModel = collision.GetComponent<iGetModel>().GetModel();
            plModel.HP -= model.damage;
        }
        CheckDestroy(collision);
    }

    protected virtual void CheckDestroy(Collider2D coll)
    {
        if (coll.CompareTag("Wall") ||
            coll.CompareTag("Door") ||
            coll.CompareTag("Enemy") ||
            coll.CompareTag("Player")
            )
        {
            Destroy();
        }
    }
}

interface iSpecialBullet
{
    void SpecialEffect();
}