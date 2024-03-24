using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : MonoBehaviour
{
    public GolemStats gStats;
    public PlayerStats pStats;

    private bool isColliding = false;
    private float collisionStartTime;
    public float damageInterval = 0.5f;

    // When player first collides with monster
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pStats.Damage(gStats.golemAttackDamage);
            isColliding = true;
            collisionStartTime = Time.time;
        }
    }

    // When player continues to collide with monster
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isColliding)
        {
            // Check if enough time has passed since the initial collision
            if (Time.time - collisionStartTime >= damageInterval)
            {
                pStats.Damage(gStats.golemAttackDamage);
                collisionStartTime = Time.time; // Reset the collision start time
            }
        }
    }

    // When player exists collision with monster
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isColliding = false;
        }
    }
}

