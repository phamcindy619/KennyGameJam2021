using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public static int numEnemies;
    private List<GameObject> enemies;

    public GameObject enemyPrefab;

    public float rotationSpeed = 50f;

    // Start is called before the first frame update
    void Awake()
    {
        numEnemies = 15;
        enemies = new List<GameObject>();
        SpawnEnemies(Vector3.zero, 4.5f);
        InvokeRepeating("RandomShoot", 1.0f, 1.0f);
    }

    void Update()
    {
        gameObject.transform.RotateAround(Vector3.zero, Vector3.back, rotationSpeed * Time.deltaTime);
    }

    void SpawnEnemies(Vector3 center, float radius) {
        for (int i = 0; i < numEnemies; i++) {
            // Circle calculations
            float dist = 2 * Mathf.PI / numEnemies * i;
            float x = Mathf.Cos(dist);
            float y = Mathf.Sin(dist);
            Vector3 spawnDir = new Vector3(x, y, 0);
            Vector3 spawnPos = center + spawnDir * radius;
            // Create enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.transform.SetParent(gameObject.transform);
            Vector2 lookDir = center - enemy.transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            enemy.transform.rotation = Quaternion.Euler(0, 0, angle);
            enemies.Add(enemy);
        }
    }

    public void EnemyDie(GameObject enemy) {
        numEnemies--;
        enemies.Remove(enemy);
        enemy.SetActive(false);
    }

    void RandomShoot() {
        if (GameManager.instance.isPlaying && numEnemies > 0) {
            int rand = Random.Range(0, numEnemies - 1);
            int angle = Random.Range(-10, 10);
            enemies[rand].transform.Rotate(0, 0, angle);
            enemies[rand].GetComponent<EnemyController>().Shoot();
        }
    }
}
