using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private GameObject map; 

    [SerializeField]
    private List<GameObject> players;

    protected override void AfterAwake()
    {
    }

    public void PlayerDead(GameObject obj)
    {
        if (!players.Contains(obj))
            return;

        players.Remove(obj);
    }

    private void RandomPos()
    {

    }
}
