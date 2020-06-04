using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    bool movingRight = true;
    public float moveSpeed;
    public float rightLimit;
    public float leftLimit;

    private void Start()
    {
        transform.SetPositionAndRotation(new Vector3(Random.Range(leftLimit + 0.5f, rightLimit - 1f), transform.position.y, transform.position.z), transform.rotation);
        moveSpeed = Random.Range(moveSpeed - 0.02f, moveSpeed + 0.02f);
    }

    void FixedUpdate()
    {
        if (movingRight)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z), transform.rotation);
        }
        else
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z), transform.rotation);
        }
         
        if(transform.localPosition.x > rightLimit)
        {
            movingRight = false;
        }else if (transform.localPosition.x < leftLimit)
        {
            movingRight = true;
        }
    
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
