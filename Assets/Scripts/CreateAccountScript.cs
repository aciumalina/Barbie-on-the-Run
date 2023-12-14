using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateAccountScript : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;
    public InputField usernameInput;
    public Text feedbackText;
    public void CreateAccount()
    {
        string email = emailInput.text;
        string password = passwordInput.text;
        string username = usernameInput.text;

        if (!IsValidEmail(email))
        {
            // Afiseaza un mesaj de eroare pentru adresa de e-mail
            feedbackText.text = "Invalid email address!";
            return;
        }

        if (!IsStrongPassword(password))
        {
            // Afiseaza un mesaj de eroare pentru parola
            feedbackText.text = "Password must have minimum length of 8 characters, contain a number and a capital letter!";
            return;
        }


        if (DatabaseConn.Instance.checkIfEmailExists(email))
        {
            feedbackText.text = "This email address is already in use";
            return;
        }

        if (DatabaseConn.Instance.checkIfUsernameExists(username))
        {
            feedbackText.text = "This username is already in use";
            return;
        }

        DatabaseConn.Instance.addUser(email, username, password);
        feedbackText.color = Color.green;
        feedbackText.text = "Account created successfully! Redirecting...";
        PlayerPrefs.SetString("username", username);
        Thread.Sleep(3000);
        SceneManager.LoadScene("Main Menu");
    }

    bool IsValidEmail(string email)
    {
        // Verifica daca adresa de e-mail are o structura corecta
        string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        return Regex.IsMatch(email, emailPattern);
    }

    bool IsStrongPassword(string password)
    {
        // Verifica daca parola este suficient de puternica
        return (Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d).+$") & password.Length >= 8);
    }
}
