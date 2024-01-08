using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonsClick : MonoBehaviour
{
    public string startGameSceneName = "SampleScene";
    public string sttingsSceneName = "SettingsScene";
    public string createAccountScene = "CreateAccountScene";
    public string loginScene = "LoginScene";
    public Text usernameText;

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

    public void createAcc()
    {
        SceneManager.LoadScene(createAccountScene);
    }

    public void login()
    {
        SceneManager.LoadScene(loginScene);
    }

    public void logout()
    {
        PlayerPrefs.DeleteKey("username");
        //reload scena curenta
        SceneManager.LoadScene("Main Menu");
    }

    public void ChooseCharacter()
    {
        SceneManager.LoadScene("Choose Character");
    }

    public void Start()
    {
        if (PlayerPrefs.GetString("username") != "")
        {
            usernameText.text = "Hello, " + PlayerPrefs.GetString("username");
        }
    }
}
