using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private AudioClip selectClip;

    void Start() {
        selectClip = Resources.Load<AudioClip>("Audio/mouse_click");
    }

    public void PlayGame() {
        SoundManager.instance.PlaySingle(selectClip);
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        SoundManager.instance.PlaySingle(selectClip);
        Application.Quit();
    }
}
