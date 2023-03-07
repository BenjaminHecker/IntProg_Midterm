using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;
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
    }
    [SerializeField] private EnemyData[] enemyData;

    private Dictionary<EnemyData, float> timers = new Dictionary<EnemyData, float>();

    private bool gameOver = false;

    private void Awake()
    {
        for (int i = 0; i < enemyData.Length; i++)
            timers[enemyData[i]] = 0f;

        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }

    private void Update()
    {
        if (gameOver) return;

        for (int i = 0; i < enemyData.Length; i++)
        {
            EnemyData data = enemyData[i];

            if (Time.time >= data.startDelay)
            {
                if (timers[data] == 0f)
                {
                    SpawnEnemy(data);
                }

                timers[data] += Time.deltaTime;

                if (timers[data] >= data.spawnDelay)
                {
                    timers[data] = 0f;
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

    public void Finish()
    {
        gameOver = true;
        canvas.GetComponent<Animator>().SetBool("FadeIn", true);
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }
}
