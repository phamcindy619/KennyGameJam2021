using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Enemy shooting
    public GameObject bulletPrefab;
    public Transform spawnPoint;

    // Sounds
    private AudioClip shootClip;

    public float bulletForce = 20f;

    void Start() {
        spawnPoint = gameObject.transform.GetChild(0).gameObject.transform;
        shootClip = Resources.Load<AudioClip>("Audio/enemy_gunshot");
    }

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        SoundManager.instance.PlaySingle(shootClip);
        rbBullet.AddForce(spawnPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
