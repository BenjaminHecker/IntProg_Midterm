using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TurretProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 20;
    [SerializeField] private float lifetime = 1.5f;

    private float timer = 0f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (timer >= lifetime)
            Death();

        timer += Time.deltaTime;
    }

    public void Setup(Vector3 dir)
    {
        rb.velocity = dir.normalized * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Damage(damage);
            Death(true);
        }
    }

    private void Death(bool collision = false)
    {
        Destroy(gameObject);
    }
}
