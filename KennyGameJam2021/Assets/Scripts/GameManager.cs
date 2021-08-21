using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                Debug.Log("GameManager is NULL!");
            }
            return _instance;
        }
    }

    public int health = 3;
    public GameObject hearts;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    void Awake() {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            GameOver();
        }
        else if (Enemies.numEnemies <= 0) {
            Win();
        }
    }

    public void PlayerHit() {
        health--;
        hearts.transform.GetChild(health).gameObject.SetActive(false);
    }

    void GameOver() {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    void Win() {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    public void BackToMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
