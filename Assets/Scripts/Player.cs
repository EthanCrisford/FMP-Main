using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public static int collectedAmount;
    public Text collectedText;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        float shootHorizontal = Input.GetAxis("Shoot Horizontal");
        float shootVertical = Input.GetAxis("Shoot Vertical");
        if ((shootHorizontal != 0 || shootVertical != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootHorizontal, shootVertical);
            lastFire = Time.time;
        }

        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
        collectedText.text = "Coins: " + collectedAmount;

    }

    void Shoot(float x, float y)
    {
        GameObject bullet  = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
            0
            );
        //ternary operator, more efficient if statement where : is else, Floor lowers the value and Ceil raises it to an Int so you can have a constant speed. https://www.youtube.com/watch?v=JhSbHfM6J24&ab_channel=CalebCurry

    }

}
