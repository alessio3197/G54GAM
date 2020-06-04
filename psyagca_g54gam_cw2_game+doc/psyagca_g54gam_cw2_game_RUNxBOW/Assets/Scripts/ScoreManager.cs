using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreManagerData", menuName = "ScriptableObjects/ScoreManager", order = 1)]
public class ScoreManager : ScriptableObject
{
    public string[] level0BestTimeNames = { "AAA", "AAA", "AAA" };
    public float[] level0BestTimes = { 1000.0f, 1001.0f, 1002.0f };
    public string[] level1BestTimeNames = { "AAA", "AAA", "AAA" };
    public float[] level1BestTimes = { 1000.0f, 1001.0f, 1002.0f };
    public string[] level2BestTimeNames = { "AAA", "AAA", "AAA" };
    public float[] level2BestTimes = { 1000.0f, 1001.0f, 1002.0f };
    public string[] level3BestTimeNames = { "AAA", "AAA", "AAA" };
    public float[] level3BestTimes = { 1000.0f, 1001.0f, 1002.0f };
    public bool[] levelUnlocked = { false, false, false };

    public bool levelPassed = true;
    public float levelTime;
    public int levelNum;
    public string playerName = "AAA";

    private int nameSwitchPos = -1;


    public void setTime(float newTime, int levelNumber)
    {
        switch (levelNumber)
        {
            case 1:
                level0BestTimes = newArray(level0BestTimes, newTime, levelNumber);
                level0BestTimeNames = newNameArray(level0BestTimeNames);
                break;
            case 2:
                level1BestTimes = newArray(level1BestTimes, newTime, levelNumber);
                level1BestTimeNames = newNameArray(level1BestTimeNames);
                break;
            case 3:
                level2BestTimes = newArray(level2BestTimes, newTime, levelNumber);
                level2BestTimeNames = newNameArray(level2BestTimeNames);
                break;
            case 4:
                level3BestTimes = newArray(level3BestTimes, newTime, levelNumber);
                level3BestTimeNames = newNameArray(level3BestTimeNames);
                break;
        }
        
    }

    private float[] newArray(float[] current, float newTime, int levelNumber)
    {
        Debug.Log(current[0] + " " + current[1] + " " + current[2]);
        if(newTime < current[0])
        {
            float[] newArray = { newTime, current[0], current[1] };
            nameSwitchPos = 0;
            unlockNextLevel(levelNumber);
            return newArray;
        }
        if (newTime < current[1])
        {
            float[] newArray = { current[0], newTime, current[1] };
            nameSwitchPos = 1;
            unlockNextLevel(levelNumber);
            return newArray;
        }
        if (newTime < current[2])
        {
            float[] newArray = { current[0], current[1], newTime };
            nameSwitchPos = 2;
            unlockNextLevel(levelNumber);
            return newArray;
        }
        nameSwitchPos = -1;
        return current;
    }

    private string[] newNameArray(string[] current)
    {
        switch (nameSwitchPos)
        {
            case 0:
                string[] newNameArray1 = { playerName, current[1], current[2] };
                return newNameArray1;
            case 1:
                string[] newNameArray2 = { current[0], playerName, current[2] };
                return newNameArray2;
            case 2:
                string[] newNameArray3 = { current[0], current[1], playerName };
                return newNameArray3;
        }
        return current;
    }

    public float[] getTimeArray(int choice)
    {
        switch (choice)
        {
            case 0:
                return level0BestTimes;
            case 1:
                return level1BestTimes;
            case 2:
                return level2BestTimes;
            case 3:
                return level3BestTimes;
        }
        return null;
    }

    public string[] getNameArray(int choice)
    {
        switch (choice)
        {
            case 0:
                return level0BestTimeNames;
            case 1:
                return level1BestTimeNames;
            case 2:
                return level2BestTimeNames;
            case 3:
                return level3BestTimeNames;
        }
        return null;
    }

    void unlockNextLevel(int levelNumber)
    {
        switch (levelNumber)
        {
            case 1:
                levelUnlocked[0] = true;
                break;
            case 2:
                levelUnlocked[1] = true;
                break;
            case 3:
                levelUnlocked[2] = true;
                break;
        }

    }
}
