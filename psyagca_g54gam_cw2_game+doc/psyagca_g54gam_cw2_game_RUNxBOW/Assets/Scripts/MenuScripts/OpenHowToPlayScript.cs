using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHowToPlayScript : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject howToPlayCanvas;

    public void enable()
    {
        startCanvas.SetActive(false);
        howToPlayCanvas.SetActive(true);
    }
}
