using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    int i;
    GameObject[] seats;
    float timePassed = 0;
    int angerCounter;

    //public GameObject player2;
    //public GameObject player1;

    // Start is called before the first frame update
    void Start()
    {
        seats = GameObject.FindGameObjectsWithTag("Seat");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i])
            {

            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        timePassed += Time.deltaTime;

        //the idea here is to have a set amount of time where the crowd person gets more and more angry to the point
        //where they perform an action.
        while (angerCounter < 3)
        {
            if (col.gameObject.tag.Equals("Player") && timePassed >= 6.0f)
            {
                Debug.Log("Getting angry");
                timePassed = 0;
                angerCounter++;
            }
        }

        Debug.Log("Anger max");
    }

    private void OnCollisionExit(Collision col)
    {
        angerCounter = 0;
    }



}
