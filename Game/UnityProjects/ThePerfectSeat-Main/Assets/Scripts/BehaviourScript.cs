using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    List<Seat> seats;
    List<AiMove> npcs;
    //int[,] seatMap;
    [SerializeField]
    int rows;
    [SerializeField]
    int columns;
    float timePassed = 0;
    float timer = 1;
    int angerCounter;
    int i;
    int x = 0;
    GameObject temp;
    bool booltemp = false;
    //public GameObject player2;
    //public GameObject player1;

    // Start is called before the first frame update
    void Start()
    {
        seats = new List<Seat>();
        npcs = new List<AiMove>();
        seats.AddRange(GetComponentsInChildren<Seat>());

        int rand = UnityEngine.Random.Range(0 , seats.Count);

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                if((i * columns) + j != rand)
                {
                    temp = Instantiate(Resources.Load("AI")) as GameObject;
                    temp.transform.SetParent(GetComponent<Transform>());
                    Vector3 pos = seats[(i * columns) + j].transform.position;
                    pos.y += 1.5f;
                    temp.transform.position = pos;
                    seats[(i * columns) + j].SetOccupied(true);
                    temp.GetComponent<AiMove>().SetCurrentSeat(seats[(i*columns)+j]);
                    npcs.Add(temp.GetComponent<AiMove>());
                }
                else
                {
                    seats[(i * columns) + j].SetOccupied(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!booltemp)
        {
            for (int i =0; i < 10; i++)
            {
                int rand = UnityEngine.Random.Range(0, npcs.Count);
                npcs[rand].Bathroom();
            }
            booltemp = true;
        }

        //if (timer > 0)
        //{
        //    timer -= Time.deltaTime;
        //}
        //else
        //{
        //    seats[x].transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
        //    x++;
        //    timer = 0.2f;
        //}
    }

    private void OnCollisionEnter(Collision col)
    {
        //timePassed += Time.deltaTime;
        ////the idea here is to have a set amount of time where the crowd person gets more and more angry to the point
        ////where they perform an action.
        //while (angerCounter < 3)    //THIS CALL BLOCKS THE GAME AS ITS ALWAYS TRUE UNTIL ANGER = 3
        //{
        //    if (col.gameObject.tag.Equals("Player") && timePassed >= 6.0f)
        //    {
        //        Debug.Log("Getting angry");
        //        timePassed = 0;
        //        angerCounter++;
        //    }
        //}

        //Debug.Log("Anger max");
    }

    private void OnCollisionExit(Collision col)
    {
        //angerCounter = 0;
    }



}
