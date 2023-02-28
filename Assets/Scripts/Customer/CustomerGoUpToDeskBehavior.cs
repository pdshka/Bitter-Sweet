using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGoUpToDeskBehavior : StateMachineBehaviour
{
    private float speed;
    private Transform otherCustomerCheck;
    private LayerMask customerMask;
    private Transform orderPoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        speed = animator.GetComponent<Customer>().speed;
        otherCustomerCheck = animator.GetComponent<Customer>().otherCustomerCheck;
        customerMask = animator.GetComponent<Customer>().customerMask;
        orderPoint = GameObject.Find("OrderPoint").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.position.y + speed * Time.fixedDeltaTime >= orderPoint.position.y)
        {
            animator.SetBool("Waiting", true);
        }
        if (!Physics2D.OverlapPoint(otherCustomerCheck.position, customerMask))
        {
            animator.transform.position = animator.transform.position + new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
