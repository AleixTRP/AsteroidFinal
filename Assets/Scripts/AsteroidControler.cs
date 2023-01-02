using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControler : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;
    public float speed;
    public List<Sprite> sprites;
    public AsteroidManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.asteroid_actuales++;
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
        Debug.Log(direction);
        Debug.Log(direction.magnitude);
        rb.AddForce(direction * speed);
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Muerte()
    {

        if (transform.localScale.x > 0.25f)
        {
            GameObject temp1 = Instantiate(manager.asteroide, transform.position, Quaternion.identity);
            temp1.GetComponent<AsteroidControler>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;


            GameObject temp2 = Instantiate(manager.asteroide, transform.position, Quaternion.identity);
            temp2.GetComponent<AsteroidControler>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;

        }
        Destroy(gameObject);
        GameManager.instance.punt += 100;
        manager.asteroid_actuales--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Muerte();
            Destroy(gameObject);
            manager.asteroid_actuales--;
        }
    }




}


