using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int health = 3;
    public GameObject hearts;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    public bool isPlaying = true;

    // Sounds
    private AudioClip youWinClip;
    private AudioClip gameOverClip;
    private AudioClip selectClip;
    private AudioClip hitClip;

    // Cursor
    private Texture2D cursor;

    void Start() {
        youWinClip = Resources.Load<AudioClip>("Audio/you_win");
        gameOverClip = Resources.Load<AudioClip>("Audio/game_over");
        selectClip = Resources.Load<AudioClip>("Audio/mouse_click");
        hitClip = Resources.Load<AudioClip>("Audio/player_hit");
        cursor = Resources.Load<Texture2D>("Sprites/cursor");
    }

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying && health <= 0) {
            GameOver();
        }
        else if (isPlaying && Enemies.numEnemies <= 0) {
            Win();
        }
    }

    public void PlayerHit() {
        if (health > 0) {
            SoundManager.instance.PlaySingle(hitClip);
            health--;
            hearts.transform.GetChild(health).gameObject.SetActive(false);
        }
    }

    void GameOver() {
        gameOverPanel.SetActive(true);
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        SoundManager.instance.PlaySingle(gameOverClip);
        isPlaying = false;
    }

    void Win() {
        winPanel.SetActive(true);
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        SoundManager.instance.PlaySingle(youWinClip);
        isPlaying = false;
    }

    public void BackToMainMenu() {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        SoundManager.instance.PlaySingle(selectClip);
        SceneManager.LoadScene("MainMenu");
    }
}
