using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public static Game instance;

    private static int health = 10;

    private static int maxHealth = 10;

    private static float moveSpeed = 5f;

    private static float fireRate = 0.5f;

    public static int Health
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

    private Text healthText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
    }

    void Update()
    {
        healthText.text = "Health: " + health;
    }

    public static void DamagePlayer(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            KillPlayer();
        }
    }

    public static void HealPlayer(int healAmount)
    {
        Health = Mathf.Min(maxHealth, health + healAmount); //Mathf is a function collection.
    }

    private static void KillPlayer()
    {

    }

}
