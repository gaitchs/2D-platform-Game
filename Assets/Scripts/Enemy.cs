using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float sightDistance = 5f;
    public int health;
    public float speed;
    public Transform Detection;
    private bool movingRight = true;
    public Slider healthSlider;
    private Rigidbody2D rb;
    public bool takingDamage;

    private string mood;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        healthSlider.value = health;


        move();
        sight();
    }

    public void TakeDamange(int damage)
    {

        health -= damage;
        Debug.Log(health);
        takingDamage = true;
        

    }


    void move()
    {

        RaycastHit2D groundInfo = Physics2D.Raycast(Detection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

                movingRight = true;

            }

        }


        if (movingRight)
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        if (!movingRight)
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);


    }


    void sight()
    {

        RaycastHit2D raycast = Physics2D.Raycast(Detection.position, transform.right * sightDistance, sightDistance);

        Debug.DrawRay(Detection.position, transform.right * sightDistance, Color.green);

        if (raycast.collider == true)
        {
           
            if (raycast.collider.tag == "Player" && raycast.collider.transform.position != transform.position)
            {
               
             //  transform.position = new Vector2(raycast.collider.transform.position.x * speed, transform.position.y);
              transform.position =  Vector2.MoveTowards(transform.position, raycast.collider.transform.position,.05f);
            }
        }






    }





}//class
