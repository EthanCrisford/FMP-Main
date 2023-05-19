using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class BossScene : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AntiSkip antiSkip = GetComponent<AntiSkip>();

        print("Collided with " + collision.gameObject.name);
        print("enemies alive=" + antiSkip.enemiesAlive.Count);


        
        if (collision.gameObject.name == "Player" && antiSkip.enemiesAlive.Count == 0)
        {
            SceneManager.LoadScene("Boss");
        }
    }
}
