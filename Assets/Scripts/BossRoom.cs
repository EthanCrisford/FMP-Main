using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRoom : MonoBehaviour
{
    GameObject healthBar;

    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("Healthbar");
        if(healthBar == null)
        {
            print("health bar not found");
        }

        healthBar.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        var camera = Camera.main;
        var brain = (camera == null) ? null : camera.GetComponent<CinemachineBrain>();
        var vcam = (brain == null) ? null : brain.ActiveVirtualCamera as CinemachineVirtualCamera;
        if (vcam != null)
            vcam.m_Lens.OrthographicSize = 10;

        healthBar.GetComponent<Canvas>().enabled = true;
    }
}
