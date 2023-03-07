using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealer : Enemy
{
    [SerializeField] protected int healFactor = 5;
    [SerializeField] protected float healRate = 1f;

    protected float timer = 0f;

    private void Update()
    {
        if (timer >= healRate)
        {
            health = Mathf.Min(maxHealth, health + healFactor);
            timer = 0f;
        }
        else
            timer += Time.deltaTime;
    }
}
