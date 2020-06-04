using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 100.0f;
    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        this.transform.Rotate(90, 0, 0, Space.Self);
        Destroy(gameObject, 10);
    }
}
