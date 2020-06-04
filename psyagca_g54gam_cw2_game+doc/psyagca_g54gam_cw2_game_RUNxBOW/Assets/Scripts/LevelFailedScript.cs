using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedScript : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.levelPassed = false;
        scoreManager.levelNum = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(5);
    }
}
