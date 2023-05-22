using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyState
{
    Wander,

    Follow,

    Die,

    Attack
};

public enum EnemyType
{
    Ranged,

    Melee
};

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public EnemyState currentState = EnemyState.Wander;
    public EnemyType enemyType;
    

    public float range;

    public float speed;

    public float rangedAttackRange;
    public float meleeAttackRange;

    public float cooldown;

    private bool chooseDirection = false;

    private bool dead = false;

    private bool attackCooldown = false;

    private int randomDirectionX;
    private int randomDirectionY;
    private Quaternion randomRotation;

    public GameObject bulletPrefab;

    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        enemyType = EnemyType.Ranged;
    }

    void Update()
    {
        switch (currentState)
        {
            case (EnemyState.Wander):
                Wander();
                break;
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Die):
                break;
            case (EnemyState.Attack):
                Attack();
                break;
        }        
    }

    private IEnumerator ChooseDirection()
    {
        chooseDirection = true;
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            randomDirectionX = Random.Range(0, 2);
            randomDirectionY = Random.Range(0, 2);

            chooseDirection = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, meleeAttackRange);
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Wander()
    {
        if (!chooseDirection)
        {
            //print("coroutine started");
            StartCoroutine(ChooseDirection());
        }

        Vector3 dir = new Vector3((randomDirectionX==1) ? 1 : -1, (randomDirectionY==1) ? 1 : -1, 0);

        rb.velocity = dir * speed;

        if (IsPlayerInRange(12))
        {
            currentState = EnemyState.Follow;
        }

    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (IsPlayerInRange(7))
        {
            currentState = EnemyState.Attack;
        }

    }

    void Attack()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (IsPlayerInRange(7) == false )
        {
            //currentState = EnemyState.Follow;
            //return;
        }

            if (attackCooldown)
            return;

        

        switch (enemyType)
        {
            case(EnemyType.Melee):
                Game.DamagePlayer(1);
                StartCoroutine(Cooldown());
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                break;

            case(EnemyType.Ranged):
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Bullet>().GetPlayer(player.transform);
                bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
                bullet.GetComponent<Bullet>().IsEnemyBullet = true;
                StartCoroutine(Cooldown());

                if (Vector3.Distance(transform.position, player.transform.position) <= 7 )
                {
                    enemyType = EnemyType.Melee;
                }

                else
                {
                    enemyType=EnemyType.Ranged;
                }
                break;
        }
    }

    private IEnumerator Cooldown()
    {
        attackCooldown = true;
        yield return new WaitForSeconds(cooldown);
        attackCooldown= false;
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private EnemyType GetEnemyType()
    {
        return enemyType;
    }

    private void IsEnemyRanged()
    {
        if (true)
        {

           

        }

    }

}
