using System;
using UnityEngine;

public class RefactorPatrol : MonoBehaviour

{
    private RefactorEnemy rf;
    
    private void Start()
    {
        rf = GetComponent<RefactorEnemy>();
    }

    public void Patrol()
    {
        // changes the enemy's behavior: pacing in circles or chasing the player
        if (rf.enemyStats.idle == true)
        {
            //Patrol Logic
            Vector3 moveToPoint = rf.patrolPoints[rf.currentPatrolPoint].position;
            transform.position = Vector3.MoveTowards(transform.position, moveToPoint, rf.enemyStats.walkSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveToPoint) < 0.01f)
            {
                rf.currentPatrolPoint++;
                if (rf.currentPatrolPoint > rf.patrolPoints.Length - 1)
                {
                    rf.currentPatrolPoint = 0;
                }
            }
        }
        else if (rf.enemyStats.idle == false)
        {
            rf.Chase(rf.transform);
            rf.ExplodeCheck();
        }
    }
}
