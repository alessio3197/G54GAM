using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStartCanvas : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject howToPlayCanvas;
    public Text levelText;
    public ScoreManager scoreManager;
    public Text time1;
    public Text time2;
    public Text time3;
    public Text name1;
    public Text name2;
    public Text name3;
    public Button runLevel;
    public LoadLevelOnClick loadLevelOnClick;

    public void enable(int level)
    {
        startCanvas.SetActive(true);
        howToPlayCanvas.SetActive(false);
        levelText.text = "Level " + level;
        float[] scores = scoreManager.getTimeArray(level);
        string[] names = scoreManager.getNameArray(level);
        setTimeText(scores[0], time1);
        setTimeText(scores[1], time2);
        setTimeText(scores[2], time3);
        name1.text = names[0];
        name2.text = names[1];
        name3.text = names[2];
        loadLevelOnClick.setLevelIndex(level + 1);
    }

    void setTimeText(float t, Text timeText)
    {
        if (t > 60)
        {
            float mins = Mathf.Floor(t / 60);
            float seconds = t % 60;
            timeText.text = "" + mins.ToString("0") + ":" + seconds.ToString("00.00");
        }
        else
        {
            timeText.text = "" + t.ToString("0.00");
        }
    }
}
