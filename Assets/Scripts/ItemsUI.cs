using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsUI : MonoBehaviour
{
    public static ItemsUI Instance { get; private set; }

    public Image NoodlesPickup;
    public Image PowerStonePickup;

    public void UpdateItemHolderInventory(string item)
    {
        if(item == "Noodles")
        {
            NoodlesPickup.enabled = true;
        }

        if (item == "Power Stone")
        {
            PowerStonePickup.enabled = true;
        }
    }
}
