using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider slider;

    private int health;

    void Start()
    {
        health = 100;

        slider.maxValue = 100;
        slider.value = 100;
    }

    public void DamageBoss(int num)
    {
        health -= num;
        print("boss health is now " + health);

        if (health <= 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void Update()
    {
        slider.value = health;
    }

}

