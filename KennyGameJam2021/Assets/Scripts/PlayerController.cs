using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movement
    public float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Player shooting
    public GameObject bulletPrefab;
    public Transform spawnPoint;

    public float bulletForce = 2f;

    // Sounds
    private AudioClip shootClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        shootClip = Resources.Load<AudioClip>("Audio/gunshot");
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void FixedUpdate() 
    {
        Vector3 newPos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        if (newPos.magnitude < 4f) {
            rb.MovePosition(newPos);
        }

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        SoundManager.instance.PlaySingle(shootClip);
        rbBullet.AddForce(spawnPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
