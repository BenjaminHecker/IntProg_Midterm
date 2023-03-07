using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private TurretProjectile projectile;
    [SerializeField] private float range = 5f;
    [SerializeField] private float fireRate = 0.5f;

    private float timer = 0f;

    private void Update()
    {
        if (timer == 0f)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject nearestEnemyInRange = null;
            float nearestDistance = float.PositiveInfinity;

            foreach (GameObject enemy in enemies)
            {
                float dist = (enemy.transform.position - transform.position).magnitude;

                if (dist <= range && dist < nearestDistance)
                {
                    nearestEnemyInRange = enemy;
                    nearestDistance = dist;
                }
            }

            if (nearestEnemyInRange != null)
                Fire(nearestEnemyInRange.transform.position);
        }

        timer += Time.deltaTime;

        if (timer >= fireRate)
            timer = 0f;
    }

    private void Fire(Vector3 pos)
    {
        TurretProjectile proj = Instantiate(projectile, firePoint.position, Quaternion.identity);
        proj.Setup(pos - firePoint.position);
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

#endif
}
