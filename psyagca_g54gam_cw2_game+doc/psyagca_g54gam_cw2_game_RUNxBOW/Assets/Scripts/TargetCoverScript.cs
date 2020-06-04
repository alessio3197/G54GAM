using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCoverScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (opened == 1)
        {
            if (yPos > 0.5f)
            {
                //targetCover.transform.Rotate(1.0f, 0.0f, 0.0f, Space.Self);
                targetCover.transform.Translate(0.0f, -0.1f, 0.0f, Space.Self);
                yPos -= 0.1f;
            }
        }
        else if (opened == 2)
        {
            if (yPos < 1.5f)
            {
                targetCover.transform.Translate(0.0f, 0.1f, 0.0f, Space.Self);
                yPos += 0.1f;
            }
        }
    }

    public GameObject targetCover;
    public GameObject crossbow;
    public PlayerController playerController;
    public Text crosshair;
    private int opened = 0;
    private float yPos = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if(opened == 0)
        {
            opened = 1;
            crossbow.SetActive(true);
            crosshair.enabled = true;
            playerController.SetBulletsActive(5);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(opened == 1)
        {
            opened = 2;
        }
        else
        {
            opened = 3;
        }
        crossbow.SetActive(false);
        crosshair.enabled = false;
        playerController.SetBulletsActive(0);
    }
}
