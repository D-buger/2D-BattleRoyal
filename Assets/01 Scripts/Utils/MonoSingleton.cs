using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour
    where T : MonoSingleton<T>
{
    private static T inst;
    public static T Inst
    {
        get
        {
            if (inst == null)
            {
                inst = GameObject.FindObjectOfType(typeof(T)) as T;

                if (inst == null)
                    inst = new GameObject(typeof(T).ToString()).AddComponent<T>();
            }
            return inst;
        }
    }

    private void Awake()
    {
        inst = this.transform.GetComponent<T>();
        AfterAwake();
    }

    protected abstract void AfterAwake();

    public virtual void Destroy() { Destroy(this); }
}
