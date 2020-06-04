using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOverScript : MonoBehaviour
{
    //public GameObject restartButton;
    public GameObject nextButton;
    public Text passFailText;
    public Text timeText;
    public ScoreManager scoreManager;

    void Start()
    {
        if (scoreManager.levelPassed)
        {
            passFailText.text = "Level Passed";
            passFailText.color = Color.green;
            if(scoreManager.levelTime < 60)
            {
                timeText.text = "Time: " + scoreManager.levelTime.ToString("0.0");
            }
            else
            {
                float mins = Mathf.Floor(scoreManager.levelTime / 60);
                float seconds = scoreManager.levelTime % 60;
                timeText.text = "Time: " + mins.ToString("0") + ":" + seconds.ToString("00.0");
            }
            if(scoreManager.levelNum == 4)
            {
                nextButton.SetActive(false);
            }
        }
        else
        {
            passFailText.text = "Level Failed";
            passFailText.color = Color.red;
            timeText.enabled = false;
            nextButton.SetActive(false);
        }
        //enableButtons();
        Cursor.lockState = CursorLockMode.None;
    }

    public void loadScene(int buttonNum)
    {
        switch (buttonNum)
        {
            case 0:
                SceneManager.LoadScene(0);
                break;
            case 1:
                SceneManager.LoadScene(scoreManager.levelNum);
                break;
            case 2:
                SceneManager.LoadScene(scoreManager.levelNum+1);
                break;
        }
    }
}
