using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBezerk : Enemy
{
    [SerializeField] protected float maxSpeed = 5f;

    public override void Damage(int damage)
    {
        base.Damage(damage);

        float ratio = 1 - (float) (health - 20) / (maxHealth - 20);
        speed = Mathf.Lerp(moveSpeed, maxSpeed, ratio);

        nav.speed = speed;
    }
}
