using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,

    Follow,

    Die,

    Attack
};

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public EnemyState currentState = EnemyState.Wander;

    public float range;

    public float speed;

    public float attackRange;

    public float cooldown;

    private bool chooseDirection = false;

    private bool dead = false;

    private bool attackCooldown = false;

    private int randomDirectionX;
    private int randomDirectionY;
    private Quaternion randomRotation;

    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
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

        if (IsPlayerInRange(range) && currentState != EnemyState.Die)
        {
            currentState = EnemyState.Follow;
        }
        else if (!IsPlayerInRange(range) && currentState == EnemyState.Die)
        {
            currentState = EnemyState.Wander;
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            currentState = EnemyState.Attack;
            //Debug.Log("Attacking");
        }

    }

    private IEnumerator ChooseDirection()
    {
        chooseDirection = true;
        //for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            randomDirectionX = Random.Range(0, 2);
            randomDirectionY = Random.Range(0, 2);


            //Quaternion nextRotation = Quaternion.Euler(randomDirection); //Eular is for rotating x degrees around the corresponding axis, in that order. 
            //transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f)); //Lerp is for a more accurate rotation since it can take 3 parameters, I am using it to say, rotate between 50% and 250% in a random direction. 
            chooseDirection = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, attackRange);
    }

    void Wander()
    {
        if (!chooseDirection)
        {
            print("coroutine started");
            StartCoroutine(ChooseDirection());
        }

        Vector3 dir = new Vector3((randomDirectionX==1) ? 1 : -1, (randomDirectionY==1) ? 1 : -1, 0);

        //transform.position += dir  * speed * Time.deltaTime;
        rb.velocity = dir * speed;



        if (IsPlayerInRange(range))
        {
            currentState = EnemyState.Follow;
        }
    }

    void Follow()
    {
          transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void Attack()
    {
        if (attackCooldown)
            return;

        Game.DamagePlayer(1);
        StartCoroutine(Cooldown());
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

    public void Death()
    {
        Destroy(gameObject);  
    }

}
