using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionalRenderingMainMenu : MonoBehaviour
{
    public Button createAccBtn;
    public Button loginBtn;
    public Button logoutBtn;
    void Start()
    {
        if (PlayerPrefs.HasKey("username"))
        {
            // Activeaza butonul daca exista date salvate
            createAccBtn.gameObject.SetActive(false);
            loginBtn.gameObject.SetActive(false);
            logoutBtn.gameObject.SetActive(true);
        }
        else
        {
            // dezactiveaza butonul
            createAccBtn.gameObject.SetActive(true);
            loginBtn.gameObject.SetActive(true);
            logoutBtn.gameObject.SetActive(false);
        }

    }
}

