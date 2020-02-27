using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    int i;
    GameObject[] seats = GameObject.FindGameObjectsWithTag("Seat");

    
    public GameObject player2;
    public GameObject player1;

    bool p1Seated;
    bool p2Seated;

    
    // Start is called before the first frame update
    void Start()
    {
        p1Seated = player1.GetComponent<PlayerController>().seated;
        p2Seated = player2.GetComponent<PlayerController>().seated;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < seats.Length; i ++)
        {
           
        }
    }

    
}
