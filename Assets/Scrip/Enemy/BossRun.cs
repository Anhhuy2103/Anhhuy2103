using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
    public float moveSpeed;
    Transform player;
    Rigidbody2D rb;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = rb.GetComponent<Rigidbody2D>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      Vector2 target = new Vector2 (player.position.x,rb.position.y);
      Vector2 newPos =  Vector2.MoveTowards(rb.position, target, moveSpeed* Time.fixedDeltaTime);
       rb.MovePosition(newPos);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
