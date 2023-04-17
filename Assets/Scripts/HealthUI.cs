using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject heartContainer;

    private float fillValue;

    void Update()
    {
        fillValue = (float)Game.Health;
        fillValue = fillValue / Game.MaxHealth;
        heartContainer.GetComponent<Image>().fillAmount = fillValue;
    }
}
