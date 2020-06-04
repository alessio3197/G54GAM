using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{

    public Transform barrelLocation;
    public PlayerController playerController;
    public GameObject shot;
    public Text ammoText;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (playerController.GetBullets() >= 0)
            {
                Instantiate(shot, barrelLocation.position, barrelLocation.rotation);
                ammoText.text = "Ammo: " + playerController.GetBullets();
            }
        }
    }
}
