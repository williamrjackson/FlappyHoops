using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public Text scoreOutput;
    private int score;
    public bool isGameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            // Bail if an instance already exists
            DestroyObject(this);
        }
    }
    public void ChangeScore(int amount)
    {
        score += amount;
        scoreOutput.text = score.ToString();
    }
}
