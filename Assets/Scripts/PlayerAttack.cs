using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float fireRate = 0.2f;
    private float nextFire = 0.0f;
    private bool canAttack;

    public Transform attackPos;
    public float attackRange = 0.3f;
    public LayerMask enemy;
    public int damage;

    public GameObject weapon;

    private AudioSource audioSource;
    public AudioClip audioPunchclip;
    



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {





        if (canAttack = false && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
          

        }
        else {
            canAttack = false;
            
        }


    }



    //temporary gizmos ui to check radius can delete this
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);


    }




    //attack create radius sphere 
    public void Attack()
    {
       
        if (canAttack)
            {
            
            weapon.SetActive(true);


            //whenever it collides create an enemy and get its component in array
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {

                Enemy enemy = enemiesToDamage[i].GetComponent<Enemy>();
                enemy.TakeDamange(damage);
                




                //get the transform property of the current enemy and call it currenEnemy
                Transform currentEnemy = enemiesToDamage[i].GetComponent<Transform>();

                //push back enemy position when punched
                if (currentEnemy.position.x < attackPos.position.x)
                {
                    Vector2 newpos = new Vector2(currentEnemy.position.x - 1f, currentEnemy.position.y);
                    currentEnemy.position = newpos;

                }
                else
                {
                    Vector2 newpos = new Vector2(currentEnemy.position.x + 1f, currentEnemy.position.y);
                    currentEnemy.position = newpos;
                }

                

                audioSource.PlayOneShot(audioPunchclip);
                
                


            }

        }
        canAttack = false;


    }





}//class
