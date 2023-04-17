using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public static Game instance;

    private static float health = 6;

    private static int maxHealth = 6;

    private static float moveSpeed = 5f;

    private static float fireRate = 0.5f;

    private static float bulletSize = 0.5f;

    public static int collectedAmount;


    public static float Health
    {
        get => health ; set => health = value;
    }

    public static int MaxHealth
    {
        get => maxHealth; set => maxHealth = value;
    }

    public static float MoveSpeed
    {
        get => moveSpeed; set => moveSpeed = value;
    }

    public static float FireRate
    {
        get => fireRate; set => fireRate = value;
    }

    public static float BulletSize
    {
        get => bulletSize; set => bulletSize = value;
    }

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI collectedText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
    }

    private void Start()
    {
        healthText.text = "Health: " + health;
    }

    void Update()
    {
        healthText.text = "Health: " + health;

        //collectedText.text = "Coins: " + collectedAmount;

    }

    public static void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillPlayer();
        }
    }

    public static void HealPlayer(float healAmount)
    {
        Health = Mathf.Min(maxHealth, health + healAmount); //Mathf is a function collection.
    }

    public static void MoveSpeedChange(float speed)
    {
        moveSpeed += speed;
    }

    public static void FireRateChange(float rate)
    {
        fireRate -= rate;
    }

    public static void BulletSizeChange(float size)
    {
        bulletSize += size;
    }

    private static void KillPlayer()
    {
        
    }

}
