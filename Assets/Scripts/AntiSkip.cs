using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSkip : MonoBehaviour
{
    public new List<GameObject> enemiesAlive = new List<GameObject>();

    public BoxCollider2D doorBlocker;

    private void Update()
    {
        foreach(GameObject enem in enemiesAlive)
        {
            if(enem == null)
            {
                enemiesAlive.RemoveAt(enemiesAlive.IndexOf(enem));
            }
        }

        if(enemiesAlive.Count == 0)
        {
            doorBlocker.enabled = false;
        }
    }
}
