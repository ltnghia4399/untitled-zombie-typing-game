using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSelector : StateMachineBehaviour
{
    public int numberOfAnim = 4;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int rand = Random.Range(0, numberOfAnim);

        switch (rand)
        {
            case 0:
                animator.SetTrigger("ZWalk_01");
                break;
            case 1:
                animator.SetTrigger("ZWalk_02");
                break;
            case 2:
                animator.SetTrigger("ZWalk_03");
                break;
            case 3:
                animator.SetTrigger("ZWalk_04");
                break;
            default:
                break;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
 
    //}


}
