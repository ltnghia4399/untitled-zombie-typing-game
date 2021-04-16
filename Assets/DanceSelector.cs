using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceSelector : StateMachineBehaviour
{
    public int numberOfAnim = 2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int rand = Random.Range(0, numberOfAnim);

        switch (rand)
        {
            case 0:
                animator.SetTrigger("Dance_01");
                break;
            case 1:
                animator.SetTrigger("Dance_02");
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
    //    
    //}

}
