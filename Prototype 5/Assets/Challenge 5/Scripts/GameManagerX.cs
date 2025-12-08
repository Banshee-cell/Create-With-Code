using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;

    public List<GameObject> targetPrefabs;

    private int score;
    private float spawnRate = 1.5f;
    public bool isGameActive;

    // Difficulty
    private float difficultyMultiplier = 1f;

    // Grid settings
    private float spaceBetweenSquares = 2.5f;
    private float minValueX = -3.75f;
    private float minValueY = -3.75f;

    // -------------------- START GAME WITH DIFFICULTY --------------------
    public void StartGame(float difficulty)
    {
        difficultyMultiplier = difficulty;
        spawnRate = 1.5f / difficultyMultiplier;

        isGameActive = true;
        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);

        titleScreen.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // -------------------- SPAWN TARGETS --------------------
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            if (isGameActive)
            {
                int index = Random.Range(0, targetPrefabs.Count);
                Instantiate(targetPrefabs[index], RandomSpawnPosition(),
                    targetPrefabs[index].transform.rotation);
            }
        }
    }

    // -------------------- RANDOM SPAWN POSITION --------------------
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // -------------------- UPDATE SCORE (SCALES WITH DIFFICULTY) --------------------
    public void UpdateScore(int scoreToAdd)
    {
        score += Mathf.RoundToInt(scoreToAdd * difficultyMultiplier);
        scoreText.text = "Score: " + score;
    }

    // -------------------- GAME OVER --------------------
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // -------------------- RESTART --------------------
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
