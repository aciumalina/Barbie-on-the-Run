using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public static GameManager instance;
    [SerializeField] Text scoreText;
    // Singleton
    private void Awake()
    {
        instance = this;
    }
    public void IncreaseScore()
    {
        score = score + 1;
        scoreText.text = "SCORE: " + score;
    }
}
