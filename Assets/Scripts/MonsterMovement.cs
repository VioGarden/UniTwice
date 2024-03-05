using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    // This is a script for a single monster
    public Transform[] patrolPoints; // Points where monster clusters travel around
    public MonsterStats mStats;
    public float stoppingDistance = 0.5f; // The distance at which the monster stops before proceeding to the next patrol point
    private int currentPatrolIndex = 0;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    public FullPlayerControl playerCondition;

    private void Update()
    {
        // If player is camo, monsters should just patrol
        if (playerCondition.isCurrentlyCamo)
        {
            Patrol();
            return;
        }
        // If isChasing setting, chase player
        if (isChasing)
        {
            ChasePlayer();
        }
        // If player comes close to a monster, start chase
        else if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            isChasing = true;
        }
        // Default is to patrol
        else
        {
            Patrol();
        }

    }

    private void ChasePlayer()
    {
        // Stop chasing player if too far from player
        if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance)
        {
            isChasing = false; // Stop chasing if player is out of range
            return;
        }

        MoveTowardsTarget(playerTransform.position);
    }


    private void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogWarning("No patrol points assigned.");
            return;
        }

        // get patrol coord target
        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];

        MoveTowardsTarget(targetPatrolPoint.position);

        // If gets close to patrol point, get a new patrol point
        if (Vector2.Distance(transform.position, targetPatrolPoint.position) < stoppingDistance)
        {
            currentPatrolIndex = GetRandomPatrolIndex();
        }
    }


    private int GetRandomPatrolIndex()
    {
        int randomIndex = Random.Range(0, patrolPoints.Length);
        while (randomIndex == currentPatrolIndex)
        {
            randomIndex = Random.Range(0, patrolPoints.Length);
        }
        return randomIndex;
    }

    private void MoveTowardsTarget(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, mStats.monsterSpeed * Time.deltaTime);
    }
}

