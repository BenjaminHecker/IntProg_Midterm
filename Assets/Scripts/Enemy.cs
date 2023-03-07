using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    protected NavMeshAgent nav;
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected int maxHealth = 100;

    protected float speed;
    protected int health;

    private void Awake()
    {
        speed = moveSpeed;
        health = maxHealth;

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }

    public virtual void SetDestination(Vector3 dest)
    {
        nav.SetDestination(dest);
    }

    public virtual void Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Death();
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
