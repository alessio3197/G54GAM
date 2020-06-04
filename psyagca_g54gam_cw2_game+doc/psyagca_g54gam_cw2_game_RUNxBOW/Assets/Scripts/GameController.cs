using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text resultText;
    public Text timeText;
    public PlayerController playerController;
    public BoxCollider finishLine;
    public ScoreManager scoreManager;
    float startTime;
    float t;

    public RaceState raceState;

    public enum RaceState
    {
        START,
        RACING,
        FINISHED
    };

    void Start()
    {
        StartCoroutine(startCountdown());
        raceState = RaceState.START;
    }

    IEnumerator startCountdown()
    {
        int count = 3;
        while (count > 0)
        {
            resultText.text = "" + count;
            count--;
            yield return new WaitForSeconds(1);
        }
        raceState = RaceState.RACING;
        startTime = Time.time;
        resultText.text = "GO";
        timeText.enabled = true;
        playerController.enabled = true;
        yield return new WaitForSeconds(1);
        resultText.enabled = false;
    }

    void goToLevelOverMenu()
    {
        scoreManager.levelPassed = true;
        scoreManager.levelTime = t;
        scoreManager.levelNum = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(5);
    }

    void Update()
    {
        if (raceState == RaceState.RACING)
        {
            t = (Time.time - startTime);
            setTimeText();
        }
        if (raceState == RaceState.FINISHED)
        {
            //scoreManager.setTime(t, SceneManager.GetActiveScene().buildIndex);
            setTimeText();
            goToLevelOverMenu();
        }
    }

    public void finished()
    {
        GameObject[] targetsLeft = GameObject.FindGameObjectsWithTag("Target");
        t += (targetsLeft.Length * 10);
        raceState = RaceState.FINISHED;
        scoreManager.setTime(t, SceneManager.GetActiveScene().buildIndex);
    }

    void setTimeText()
    {
        if (t > 59.9)
        {
            float mins = Mathf.Floor(t / 60);
            float seconds = t % 60;
            timeText.text = "Time: " + mins.ToString("0") + ":" + seconds.ToString("00.0");
        }
        else
        {
            timeText.text = "Time: " + t.ToString("0.0");
        }
    }

}
