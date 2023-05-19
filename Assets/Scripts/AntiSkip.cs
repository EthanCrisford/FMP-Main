using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSkip : MonoBehaviour
{
    public List<GameObject> enemiesAlive;
    public BoxCollider2D doorBlocker;


    public void Start()
    {

    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("count=" + enemiesAlive.Count + "  tag=" + collision.gameObject.tag);
        print("name=" + collision.gameObject.name);
        if ((collision.gameObject.tag == "Player") && enemiesAlive.Count == 0)
        {
            print("player has hit door");
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), doorBlocker);
        }
    }
}
