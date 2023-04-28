using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiars : MonoBehaviour
{
    private float lastFire;

    private GameObject player;

    public FamiliarData familiar;

    private float lastOffsetX;

    private float lastOffsetY;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        float shootHorizontal = Input.GetAxis("Shoot Horizontal");
        float shootVertical = Input.GetAxis("Shoot Vertical");
        if ((shootHorizontal != 0 || shootVertical != 0) && Time.time > lastFire + familiar.fireDelay)
        {
            Shoot(shootHorizontal, shootVertical);
            lastFire = Time.time;
        }

        if (horizontal != 0 || vertical != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, familiar.speed * Time.deltaTime);
            lastOffsetX = horizontal;
            lastOffsetY = vertical;
        }
        else
        {
            if (!(transform.position.x > lastOffsetX + 0.5f) || !(transform.position.y < lastOffsetY + 0.5f))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - lastOffsetX, player.transform.position.y - lastOffsetY), familiar.speed * Time.deltaTime);
            }
        }
    }


    void Shoot(float x, float y)
    {

    }



}
