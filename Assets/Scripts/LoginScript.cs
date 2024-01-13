using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;
    public Button backButton;
    public Text feedbackText;
    
    public void login()
    {

        feedbackText.text = "debugging";

        string email = emailInput.text;
        string password = passwordInput.text;

        if (!DatabaseConn.Instance.userLogin(email, password))
        {
            feedbackText.text = "Email and/or password are invalid";
            return;
        }
            
        else
        {
            feedbackText.color = Color.green;
            feedbackText.text = "Login successful! Redirecting...";
            string username = DatabaseConn.Instance.fetchUsername(email);
            PlayerPrefs.SetString("username", username);
            Thread.Sleep(2000);
            SceneManager.LoadScene("Main Menu");
        }
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
