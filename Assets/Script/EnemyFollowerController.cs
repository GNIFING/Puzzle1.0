using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowerController : EnemyController
{
    private GameObject player;
    protected override void Update(){
        player = GameObject.FindGameObjectsWithTag("Player")[0];

        enemy.speed = this.speed;
        enemy.SetDestination(player.transform.position);

        // update animation
        Vector3 movementVector = enemy.velocity.normalized;

        animator.SetFloat("Horizontal", movementVector.x);
        animator.SetFloat("Vertical", movementVector.y);
        animator.SetFloat("Speed", movementVector.magnitude);

        // set facing direction  can customize the threshold
        if (movement.magnitude > 0.1f)
        {
            animator.SetFloat("FacingHorizontal", movement.x);
            animator.SetFloat("FacingVertical", movement.y);
        }
    }
}
