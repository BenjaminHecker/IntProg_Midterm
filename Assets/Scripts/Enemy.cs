using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    protected NavMeshAgent nav;
    [SerializeField] protected float speed = 1f;

    [SerializeField] protected int health = 100;

    private void Awake()
    {
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
