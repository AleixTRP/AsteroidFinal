using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{


    Rigidbody2D rb;
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<AsteroidControler>().Muerte();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "EnemyShip")
        {
            collision.gameObject.GetComponent<EnemyShip>().Muerte();
            Destroy(gameObject);
        }
    }
}
   

