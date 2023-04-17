using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifetime; 

   public bool IsEnemyBullet = false;


    void Start()
    {
        StartCoroutine(DeathDelay());
        if (!IsEnemyBullet)
        {
            transform.localScale = new Vector2(Game.BulletSize, Game.BulletSize);
        }
    }


    void Update()
    {
        if (isEnemyBullet)
        {

        }
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
