using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;
    public float bulletFireRate;
    public float minBulletSpreadAngle;
    public float maxBulletSpreadAngle;

    private Rigidbody2D rb;
    private bool isActive;
    private float timeSinceLastBullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeSinceLastBullet = 0f;
        isActive = false;
        StartCoroutine(ActivateShip());
    }

    void Update()
    {
        if (isActive)
        {
            rb.velocity = new Vector2(speed, 0f);

            timeSinceLastBullet += Time.deltaTime;
            if (timeSinceLastBullet >= bulletFireRate)
            {
                timeSinceLastBullet = 0f;
                FireBullet();
            }
        }
    }

    private void FireBullet()
    {
        float randomAngle = Random.Range(minBulletSpreadAngle, maxBulletSpreadAngle);
        Vector3 bulletDirection = Quaternion.Euler(0f, 0f, randomAngle) * transform.up;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bullet.GetComponent<Bala>().speed;
    }

    IEnumerator ActivateShip()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            if (GameManager.instance.punt >= 1000)
            {
                isActive = true;
            }
        }
    }
    public void Muerte()
    {
        
        Destroy(gameObject);
    }
}


