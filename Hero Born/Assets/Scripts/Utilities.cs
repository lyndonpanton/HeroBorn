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

}
