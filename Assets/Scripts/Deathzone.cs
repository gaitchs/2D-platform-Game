using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
      
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            //game over
            
        }

    }
}
