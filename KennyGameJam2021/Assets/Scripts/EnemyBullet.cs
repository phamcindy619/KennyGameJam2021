using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);

        if (other.gameObject.tag == "Player") {
            GameManager.instance.PlayerHit();
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
