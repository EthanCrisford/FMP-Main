using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifetime; 


    void Start()
    {
        StartCoroutine(DeathDelay());
        transform.localScale = new Vector2(Game.BulletSize, Game.BulletSize);
    }

    void Update()
    {
        
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().Death();
            Destroy(gameObject);
        }
    }
}
