using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public GameObject Boss;

    void Start()
    {
        
    }

    void Update()
    {
        if (Boss == null)
        {
            Boss = GetComponent<GameObject>();
            BossIsDead();
        }
    }

    private void BossIsDead()
    {
        SceneManager.LoadScene("Victory");
    }
}
