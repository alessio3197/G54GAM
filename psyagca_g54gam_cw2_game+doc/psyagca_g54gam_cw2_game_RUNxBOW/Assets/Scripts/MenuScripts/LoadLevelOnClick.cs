using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnClick : MonoBehaviour
{

    private int levelIndex;

    public void loadLevel()
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void setLevelIndex(int level)
    {
        levelIndex = level;
    }
}
