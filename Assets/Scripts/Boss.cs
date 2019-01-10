using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public Vector2 Scale;

    Enemy enem;

    void Awake()
    {
        enem = GetComponent<Enemy>();

        Scale = gameObject.GetComponent<Transform>().localScale;
        Debug.Log(Scale);
    }
    void FixedUpdate()
    {
        if (enem.takingDamage)
        {
            enem.takingDamage = false;
            
            int health = enem.GetComponent<Enemy>().health;
            float scale = Mathf.Lerp(0.2f, 1f,health/100f);
            enem.transform.localScale = new Vector2(scale, scale);

        }

    }


}//class
