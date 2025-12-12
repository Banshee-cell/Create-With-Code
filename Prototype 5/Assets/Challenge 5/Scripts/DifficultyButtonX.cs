using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    private Button button;
    private GameManagerX gameManagerX;

    public int difficulty;  // 1 = Easy, 2 = Medium, 3 = Hard

    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");

        // Convert int difficulty to float multiplier
        float difficultyMultiplier = 1f;

        switch (difficulty)
        {
            case 1: // Easy
                difficultyMultiplier = 0.8f;
                break;

            case 2: // Medium
                difficultyMultiplier = 1.0f;
                break;

            case 3: // Hard
                difficultyMultiplier = 1.5f;
                break;
        }

        gameManagerX.StartGame(difficultyMultiplier);
    }
}
