using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerModel
{
    private int hp = 10;
    public int HP {
        get
        {
            return hp;
        }
        set
        {
            if (value >= 0)
            {
                hp = value;
            }
            else
            {
                hp = 0;
            }
        }
    }

    [SerializeField, Range(0f, 100f)]
    private float movementSpeed = 1f;
    public float GetMovementSpeed => movementSpeed;

    [SerializeField, Range(0f, 100f)]
    private float maxAcceleration = 20f;
    public float GetAcceleration => maxAcceleration;
    
    private Rigidbody2D body;
    public Rigidbody2D Body => body;
    private Transform trans;
    public Transform Trans => trans;

    private Magazine mag;
    public Magazine Mag => mag;
    private GunDefault gun;
    public GunDefault Gun => gun;

    public PlayerModel()
    {
    }

    public void SetPhysics(GameObject obj)
    {
        if (!obj.TryGetComponent<Rigidbody2D>(out body))
        {
            body = obj.AddComponent<Rigidbody2D>();
            body.gravityScale = 0;
        }
        trans = obj.transform;

        mag = new BuildMagazine()
            .SetBullet(eBulletType.Basic, -1);

        gun = new GunDefault(mag, obj.transform.GetChild(0));
    }
}
