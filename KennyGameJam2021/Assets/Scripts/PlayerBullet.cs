using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col) {
        Destroy(gameObject);

        if (col.gameObject.tag == "Enemy") {
            Destroy(col.gameObject);
            Enemies.numEnemies--;
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
