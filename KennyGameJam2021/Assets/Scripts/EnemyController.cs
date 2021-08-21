using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Enemy shooting
    public GameObject bulletPrefab;
    public Transform spawnPoint;

    public float bulletForce = 2f;

    void Start() {
        spawnPoint = gameObject.transform.GetChild(0).gameObject.transform;
    }

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(spawnPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
