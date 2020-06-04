using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject level1Button;
    public GameObject level2Button;
    public GameObject level3Button;
    public ScoreManager scoreManager;

    void Start()
    {
        enableButtons();
        Cursor.lockState = CursorLockMode.None;
    }

    void enableButtons()
    {
        bool[] enable = scoreManager.levelUnlocked;
        if (enable[0])
        {
            level1Button.SetActive(true);
        }
        if (enable[1])
        {
            level2Button.SetActive(true);
        }
        if (enable[2])
        {
            level3Button.SetActive(true);
        }
    }
}
