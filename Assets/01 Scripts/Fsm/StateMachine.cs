using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    private T _target;
    private FsmState<T> _currentState;
    private FsmState<T> _previousState;

    public StateMachine()
    {
        _currentState = null;
        _previousState = null;
    }

    public void ChangeState(FsmState<T> newState)
    {
        if (newState.Equals(_currentState))
            return;

        _previousState = _currentState;

        if (_currentState != null)
            _currentState.Exit(_target);

        _currentState = newState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    public void Init(T initTarget, FsmState<T> initState)
    {
        _target = initTarget;
        ChangeState(initState);
    }

    bool desired = true;
    public void Update()
    {
        if (_currentState == null)
            return;

        if (desired)
        {
            _currentState.Once(_target);
            desired = false;
        }

        _currentState.Update(_target);
        desired = true;
    }

    public void FixedUpdate()
    {
        if (_currentState == null)
            return;

        _currentState.FixedUpdate(_target);
        _currentState.HandleInput(_target);
    }

    public void StateRevert()
    {
        if (_previousState == null)
            return;

        ChangeState(_previousState);
    }
}
