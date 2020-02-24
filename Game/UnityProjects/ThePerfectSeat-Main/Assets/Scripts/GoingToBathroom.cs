using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingToBathroom : StateMachineBehaviour
{
    bool seated = false;
    GameObject AI;
    GameObject[] waypoints;
    GameObject bathroom = GameObject.Find("Bathroom");
    int currentWp;

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        currentWp = 0;
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AI = animator.gameObject;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentWp].transform.position,AI.transform.position)<3.0f)
        {
            currentWp++;
            if (currentWp >= waypoints.Length)
            {
                currentWp = 0;
            }
        }
        //rotates the crowd member towards the waypoint
        var direction = waypoints[currentWp].transform.position - AI.transform.position;
        AI.transform.rotation = Quaternion.Slerp(AI.transform.rotation, Quaternion.LookRotation(direction), 1.0f * Time.deltaTime);
        AI.transform.Translate(0, 0, Time.deltaTime*2.0f);
        
        if (Vector3.Distance(bathroom.transform.position, AI.transform.position) < 3.0f)
        {
            
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

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
