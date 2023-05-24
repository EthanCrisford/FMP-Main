using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider slider;

    private static int damage;

    private static int maxHealth = 20;
    private static int health;

    void Start()
    {
        SetMaxHealth(maxHealth);
        SetHealth(health);
        damage = 1;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = 20;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public static void DamageBoss(int damage)
    {
        health -= damage;
    }
}
