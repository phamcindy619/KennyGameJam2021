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

    // Sounds
    private AudioClip youWinClip;
    private AudioClip gameOverClip;
    private AudioClip selectClip;

    void Start() {
        youWinClip = Resources.Load<AudioClip>("Audio/you_win");
        gameOverClip = Resources.Load<AudioClip>("Audio/game_over");
        selectClip = Resources.Load<AudioClip>("Audio/mouse_click");
    }

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
        if (health > 0) {
            health--;
            hearts.transform.GetChild(health).gameObject.SetActive(false);
        }
    }

    void GameOver() {
        gameOverPanel.SetActive(true);
        SoundManager.instance.PlaySingle(gameOverClip);
    }

    void Win() {
        winPanel.SetActive(true);
        SoundManager.instance.PlaySingle(youWinClip);
    }

    public void BackToMainMenu() {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        SoundManager.instance.PlaySingle(selectClip);
        SceneManager.LoadScene("MainMenu");
    }
}
