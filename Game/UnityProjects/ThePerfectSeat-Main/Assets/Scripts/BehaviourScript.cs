using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    List<Seat> seats;
    List<AiMove> npcs;
    List<AiMove> toTheB;
    //int[,] seatMap;
    [SerializeField]
    int rows;
    [SerializeField]
    int columns;
    float timePassed = 0;
    float timer = 2;
    GameObject temp;
    bool booltemp = true;
    //public GameObject player2;
    //public GameObject player1;

    // Start is called before the first frame update
    void Start()
    {
        seats = new List<Seat>();
        npcs = new List<AiMove>();
        toTheB = new List<AiMove>();
        seats.AddRange(GetComponentsInChildren<Seat>());

        int rand = Random.Range(0 , seats.Count);

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                if((i * columns) + j != rand)
                {
                    temp = Instantiate(Resources.Load("AI")) as GameObject;
                    temp.transform.SetParent(GetComponent<Transform>());
                    Vector3 pos = seats[(i * columns) + j].transform.position;
                    pos.y += 1f;
                    temp.transform.position = pos;
                    seats[(i * columns) + j].SetOccupied(true);
                    temp.GetComponent<AiMove>().SetCurrentSeat(seats[(i*columns)+j]);
                    npcs.Add(temp.GetComponent<AiMove>());
                }
                else
                {
                    seats[(i*columns)+j].SetOccupied(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (booltemp)
        {
            npcs[18].startPhoneCall();
            booltemp = false;
        }

        if (timer <= 0)
        {
            //timer = Random.Range(15, 25);
            timer = Random.Range(0, 2);  //JUST FOR TESTING
            if(toTheB.Count < 3)
            {
                timer = Random.Range(0, 3);
                int rand = Random.Range(0, npcs.Count);
                if (!npcs[rand].IsGoingToTheB())
                {
                    timer = 1;
                    npcs[rand].SendToBathroom();
                    toTheB.Add(npcs[rand]);
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
            foreach(AiMove i in toTheB)
            {
                if (!i.IsGoingToTheB())
                {
                    toTheB.Remove(i);
                    break;
                }
            }
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
