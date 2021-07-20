using System.Collections.Generic;
using UnityEngine;

public enum ePlayerState
{
    Idle,
    Move,
    Fire
}

public class Player : MonoBehaviour, iRotate, iGetModel
{
    public StateMachine<Player> StateMachine { get; private set; }
    private Dictionary<ePlayerState, FsmState<Player>> stateByEnum;

    public PlayerPhysics physics;
    //직렬화때문에 awake에서 새로 할당하게되면 인스펙터창에서 바뀐 값들이 적용이 안된다
    public PlayerModel model = new PlayerModel();

    private void Awake()
    {
        model.SetPhysics(this.gameObject);
        physics = new PlayerPhysics(model);

        stateByEnum = new Dictionary<ePlayerState, FsmState<Player>>();
        stateByEnum.Add(ePlayerState.Idle, new PlayerIdle());
        stateByEnum.Add(ePlayerState.Move, new PlayerMove());
        stateByEnum.Add(ePlayerState.Fire, new PlayerFire());

        StateMachine = new StateMachine<Player>();
        StateMachine.Init(this, new PlayerIdle());
    }

    private void Update()
    {
        StateMachine.Update();
        Rotation();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
        physics.PhysicsUpdate();
        model.Gun.GunUpdate();
    }

    public void ChangeState(ePlayerState state)
    {
        StateMachine.ChangeState(stateByEnum[state]);
    }

    public void StateRevert()
    {
        StateMachine.StateRevert();
    }

    public void Rotation()
    {
        Vector3 mousePos = SystemManager.Inst.mouse.cursorPos;
        Vector2 objPos = transform.position;
        Vector2 gunPos = new Vector2(transform.GetChild(0).position.x, transform.GetChild(0).position.y) - objPos;
        mousePos.x -= objPos.x;
        mousePos.y -= objPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle )) ;
    }

    public PlayerModel GetModel()
    {
        return model;
    }
}
