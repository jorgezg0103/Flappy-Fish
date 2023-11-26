using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PoolManager PoolManager;
    [Header("Spawn Rate Settings")]
    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawmTime = 3f;
    [SerializeField] private float minSpawnTimeLimit = 1f;
    [SerializeField] private float maxSpawmTimeLimit = 2f;
    [SerializeField] private float decraseTimePerIteration = 0.001f;

    [Header("Pipe Spawn Settings")]
    [SerializeField] private float minSpawnHeight = 2f;
    [SerializeField] private float maxSpawnHeight = 2f;

    private float timeBtwSpawn = 2f;
    private float timer = 0;

    private void spawnObstacle() {
        GameObject obstacle = PoolManager.getObstacle();
        float randomHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
        Vector2 spawnPos = new Vector2(transform.position.x, randomHeight);
        obstacle.transform.position = spawnPos;
    }

    void Update() {
        timer += Time.deltaTime;
        if(timer >= timeBtwSpawn && GameManager.Instance.isGameStarted && !GameManager.Instance.isGameOver) {
            timeBtwSpawn = Random.Range(minSpawnTime, maxSpawmTime);
            if(minSpawnTime > minSpawnTimeLimit) minSpawnTime -= decraseTimePerIteration;
            if(maxSpawmTime > maxSpawmTimeLimit) maxSpawmTime -= decraseTimePerIteration;
            spawnObstacle();
            timer = 0;
        }
    }
}
