using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform enemyStart;
    [SerializeField] private Transform enemyGoal;
    [SerializeField] private Enemy prefab_Enemy;

    private void Awake()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(prefab_Enemy, enemyStart.position, Quaternion.identity);
        enemy.SetDestination(enemyGoal.position);
    }
}
