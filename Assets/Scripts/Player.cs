using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed_movement;
    public float speed_rotation;
    Rigidbody2D rb;
    public GameObject spark;
    public GameObject ParticulasMuerte;



    private bool canDash = true;
    private bool isDash;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    private TrailRenderer tr;

    Animator anim;


    Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        coll = GetComponent<Collider2D>();  
        

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        horizontal *= speed_movement * Time.deltaTime;
        transform.eulerAngles -= new Vector3(0, 0, horizontal);


        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            rb.AddForce(transform.up * vertical * speed_movement * Time.deltaTime);

        }
        anim.SetBool("Movement", vertical > 0);

        if (Input.GetButtonDown("Jump" ))
        {

            GameObject temp = Instantiate(spark, transform.position, transform.rotation);
            Destroy(temp, 0.5F);

            if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(Dash());
            }
        }

    
    
    }

    public void Muerte()
    {
        GameObject temp = Instantiate(ParticulasMuerte, transform.position, transform.rotation);
        Destroy(temp, 3);

        StartCoroutine(Respawn_Corutine());

       
    }

    IEnumerator Respawn_Corutine()
    {
       
        GameManager.instance.life--;
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        coll.enabled = false;   
        yield return new WaitForSeconds(3);
        coll.enabled = true;
        
    }
    
    private IEnumerator Dash()
    {
        canDash = false;
        isDash = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale *= originalGravity;
        isDash = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    }

