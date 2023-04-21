using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;

    public string description;

}

public class Collection : MonoBehaviour
{

    public Item item;

    public float healthChange;

    public float moveSpeedChange;

    public float attackSpeedChange;

    public float bulletSizeChange;

    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Game.collectedAmount++;
            Game.HealPlayer(healthChange);
            Game.MoveSpeedChange(moveSpeedChange);
            Game.FireRateChange(attackSpeedChange);
            Game.BulletSizeChange(bulletSizeChange);
            Game.instance.UpdateCollectedItems(this);

            Destroy(gameObject);
        }
    }




}
