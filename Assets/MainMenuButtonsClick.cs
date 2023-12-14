using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsClick : MonoBehaviour
{
    public string startGameSceneName = "SampleScene";
    public string sttingsSceneName = "SettingsScene";


    public void startGame()
    {
        Debug.Log("Game should start");
        SceneManager.LoadScene(startGameSceneName);
    }
    public void settings()

    {
        Debug.Log("Settings scene called");
        // SceneManager.LoadScene(sttingsSceneName);
    }
}
