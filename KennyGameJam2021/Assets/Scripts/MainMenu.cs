using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private AudioClip selectClip;
    private Texture2D crosshair;

    void Start() {
        selectClip = Resources.Load<AudioClip>("Audio/mouse_click");
        crosshair = Resources.Load<Texture2D>("Sprites/crosshair");
    }

    public void PlayGame() {
        SoundManager.instance.PlaySingle(selectClip);
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        SoundManager.instance.PlaySingle(selectClip);
        Application.Quit();
    }
}
