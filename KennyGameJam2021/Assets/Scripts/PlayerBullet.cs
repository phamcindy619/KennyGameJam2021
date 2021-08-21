using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Enemies enemies;

    void Start() {
        enemies = GameObject.Find("Enemies").GetComponent<Enemies>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        Destroy(gameObject);

        if (col.gameObject.tag == "Enemy") {
            enemies.EnemyDie(col.gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
