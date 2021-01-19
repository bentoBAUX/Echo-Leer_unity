using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeerPoint_Behavior : MonoBehaviour
{
    public bool LP_collide;
    public Vector3 floorPos;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            LP_collide = true;
            floorPos = collision.gameObject.transform.position;
        }
        else
        {
            LP_collide = false;
        }
            
    }

    private void Update()
    {
        //Debug.Log(LP_collide);
    }
}
