using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{


    public PlayerStats stats;

    // Upon attack triggered
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<MonsterStats>() != null)
        {
            // knockback monster
            Rigidbody2D monsterRigidbody = collider.GetComponent<Rigidbody2D>();
            Vector2 knockbackDirection = (collider.transform.position - transform.position).normalized;
            monsterRigidbody.AddForce(knockbackDirection * stats.knockBack, ForceMode2D.Impulse);

            // Deal damage to monsters
            MonsterStats monsterHealth = collider.GetComponent<MonsterStats>();
            monsterHealth.Damage(stats.attackDamage);
        }
    }
}
