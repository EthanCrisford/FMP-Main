using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifetime; 

    public bool IsEnemyBullet = false;

    private Vector2 lastPos;

    private Vector2 currPos;

    private Vector2 playerPos;

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
        if (IsEnemyBullet)
        {
            currPos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, 5f * Time.deltaTime);
            if (currPos == lastPos)
            {
                Destroy(gameObject);
            }
            lastPos = currPos;
        }
    }

    public void GetPlayer(Transform player)
    {
        playerPos = player.position;
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" && !IsEnemyBullet)
        {
            col.gameObject.GetComponent<Enemy>().Die();
            
        }

        if (col.tag == "Player" && IsEnemyBullet)
        {
            Game.DamagePlayer(1);
            Destroy(gameObject);
        }
    }
}
