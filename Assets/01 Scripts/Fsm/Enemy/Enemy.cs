using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum eEnemyState
{

}

public class Enemy : MonoBehaviour, iGetModel
{
    public StateMachine<Enemy> StateMachine { get; private set; }
    private Dictionary<eEnemyState, FsmState<Enemy>> stateByEnum;
    private EnemyModel model;

    public PlayerPhysics physics;

    private void Awake()
    {
        model.SetPhysics(this.gameObject);
        physics = new PlayerPhysics(model);
        
        StateMachine = new StateMachine<Enemy>();
    }

    public PlayerModel GetModel()
    {
        return model;
    }
}
