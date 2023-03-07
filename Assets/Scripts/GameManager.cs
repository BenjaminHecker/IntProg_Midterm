using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform enemyStart;
    [SerializeField] private Transform enemyGoal;

    [System.Serializable]
    class EnemyData
    {
        public string name;
        public Enemy prefab;
        public float startDelay;
        public float spawnDelay;
        public float spawnDelayLimit;
        public float rampingFactor;

        [HideInInspector] public float timer;
    }
    [SerializeField] private EnemyData[] enemyData;

    private void Awake()
    {
        for (int i = 0; i < enemyData.Length; i++)
            enemyData[i].timer = 0f;
    }

    private void Update()
    {
        for (int i = 0; i < enemyData.Length; i++)
        {
            EnemyData data = enemyData[i];

            if (Time.time >= data.startDelay)
            {
                if (data.timer == 0f)
                {
                    SpawnEnemy(data);
                }

                data.timer += Time.deltaTime;

                if (data.timer >= data.spawnDelay)
                {
                    data.timer = 0f;
                    data.spawnDelay /= data.rampingFactor;
                    data.spawnDelay = Mathf.Max(data.spawnDelay, data.spawnDelayLimit);
                }
            }
        }
    }

    private void SpawnEnemy(EnemyData data)
    {
        Enemy enemy = Instantiate(data.prefab, enemyStart.position + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
        enemy.SetDestination(enemyGoal.position);
    }
}
