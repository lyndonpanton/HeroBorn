using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    public static int PlayerDeaths = 0;

    public static void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }

    public static bool RestartLevel(int sceneIndex)
    {
        // Unity does not support negative indexes when loading scenes
        if (sceneIndex < 0)
        {
            throw new System
                .ArgumentException("Scene index cannot be negative");
        }

        Debug.Log("Player deaths: " + PlayerDeaths);

        string message = UpdateDeathCount(ref PlayerDeaths);

        Debug.Log("Player deaths: " + PlayerDeaths);

        Debug.Log(message);

        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;

        return true;
    }

    public static string UpdateDeathCount(ref int countReference)
    {
        countReference++;
        return "Next time you'll be at number " + countReference;
    }
}
