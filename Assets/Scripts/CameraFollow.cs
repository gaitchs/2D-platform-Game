using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public Transform target;
    public float smooth = 0.2f;
    public float offset = 10f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //camera transform is equal to target(player) transform, so camera moves to player postiion
        
       transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
      
    }



}
