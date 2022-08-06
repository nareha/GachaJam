using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown; // Time (in seconds) between each attack

    private float nextTimeToAttack;

    public GameObject currentTarget;

    private void Start()
    {
        nextTimeToAttack = Time.time;
    }

    private void updateNearestEnemy()
    {
        GameObject curNearestEnemy = null;
        
        float distance = Mathf.Infinity;
        foreach (GameObject enemy in EnemyManager.enemies)
        {
            if (enemy != null)
            {
                float cur = (transform.position - enemy.transform.position).magnitude;

                if (cur < distance)
                {
                    distance = cur;
                    curNearestEnemy = enemy;
                }
            }
        }

        if (distance <= range)
        {
            currentTarget = curNearestEnemy;
        }
        else
        {
            currentTarget = null;
        }
    }

    protected virtual void attack()
    {
        Enemy enemyScript = currentTarget.GetComponent<Enemy>();

        enemyScript.takeDamage(damage);
    }

    private void Update()
    {
        updateNearestEnemy();

        if (Time.time >= nextTimeToAttack)
        {
            if (currentTarget != null)
            {
                attack();
                nextTimeToAttack = Time.time + attackCooldown;
            }
        }
    }
}
