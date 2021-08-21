using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public static SoundManager instance = null;

    // Toggle audio
    [SerializeField] Toggle audioToggle;


    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
    }

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable() {
        SceneManager.sceneLoaded += OnNewScene;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnNewScene;
    }

    void OnNewScene(Scene scene, LoadSceneMode mode) {
        audioToggle = GameObject.Find("Audio Toggle").GetComponent<Toggle>();

        // Audio is off
        if (AudioListener.volume == 0) {
            audioToggle.isOn = false;
        }
    }

    public void PlaySingle(AudioClip clip) {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void PlayMusic() {
        bgmSource.Play();
    }

    public void ToggleAudio(bool isOn) {
        if (isOn) {
            AudioListener.volume = 1;
            bgmSource.UnPause();
        }
        else {
            AudioListener.volume = 0;
            bgmSource.Pause();
        }
    }

}
