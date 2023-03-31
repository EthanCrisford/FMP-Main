using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifetime; 


    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    void Update()
    {
        
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
