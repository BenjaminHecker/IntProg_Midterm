using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    protected NavMeshAgent nav;
    [SerializeField] protected float speed = 1f;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }

    public virtual void SetDestination(Vector3 dest)
    {
        nav.SetDestination(dest);
    }
}
