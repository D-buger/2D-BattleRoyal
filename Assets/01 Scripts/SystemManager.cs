using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoSingleton<SystemManager>
{
    public CursorManager mouse;

    protected override void AfterAwake()
    {
        DontDestroyOnLoad(this);
        mouse.CursorAwake();
    }

    private void Update()
    {
        mouse.CursorUpdate();
    }

}
