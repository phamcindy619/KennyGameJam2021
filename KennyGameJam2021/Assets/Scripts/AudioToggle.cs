using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{
    private Texture2D cursor;
    private Texture2D crosshair;

    // Start is called before the first frame update
    void Start()
    {
        cursor = Resources.Load<Texture2D>("Sprites/cursor");
        crosshair = Resources.Load<Texture2D>("Sprites/crosshair");

        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(SoundManager.instance.ToggleAudio);


    }

    public void OnMouseEnter() {
        if (GameManager.instance.isPlaying)
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit() {
        if (GameManager.instance.isPlaying)
            Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.Auto);
    }
}
