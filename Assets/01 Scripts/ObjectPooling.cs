using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPooling : MonoSingleton<ObjectPooling>
{
    [SerializeField]
    private int poolObjCount;
    [SerializeField]
    private GameObject Prefab;

    private Queue<GameObject> pool;

    private Transform poolGroup;

    protected override void AfterAwake()
    {
        pool = new Queue<GameObject>(poolObjCount);
        poolGroup = this.transform;

        Initialize();
    }

    private void Initialize()
    {
        for(int i = 0; i < poolObjCount; i++)
        {
            CreateNewObject(i);
        }
    }

    private GameObject CreateNewObject(int num)
    {
        GameObject obj = Instantiate(Prefab, poolGroup);
        obj.name = Util.StringBuilder("Bullet_", num);

        pool.Enqueue(obj);
        obj.SetActive(false);
        obj.transform.SetParent(poolGroup);

        return obj;
    }

    public GameObject Get()
    {
        if(pool.Count <= 0)
            CreateNewObject(poolObjCount++);

        GameObject obj = pool.Dequeue();

        obj.SetActive(true);
        return obj;
    }

    public void Set(GameObject obj)
    {
        if (pool.Contains(obj))
            return;
        pool.Enqueue(obj);
        obj.SetActive(false);
    }
    
}
