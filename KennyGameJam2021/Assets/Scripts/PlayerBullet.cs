using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Enemies enemies;

    void Start() {
        enemies = GameObject.Find("Enemies").GetComponent<Enemies>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);

        if (other.gameObject.tag == "Enemy") {
            enemies.EnemyDie(other.gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
