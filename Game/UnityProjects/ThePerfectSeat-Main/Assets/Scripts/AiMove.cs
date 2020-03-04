using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMove : MonoBehaviour
{
    //[SerializeField]
    //Vector3 bathroom;
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    float waitTime;

    int steps;
    bool bathroom;
    bool phoneCall;

    Seat currentSeat;

    Vector3 target;
    Transform tr;

    [SerializeField]
    float disturbanceRadius;

    // Start is called before the first frame update
    void Start()
    {
        target = Vector3.zero;
        tr = GetComponent<Transform>();
        bathroom = false;
        phoneCall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bathroom)
        {
            Bathroom();
        }
        else if (phoneCall)
        {
            PhoneCall();
        }
        
    }

    public void SendToBathroom()
    {
        bathroom = true;
        steps = 0;
    }



    //public void 

    public void startPhoneCall()
    {
        phoneCall = true;
    }

    public void SetCurrentSeat(Seat s)
    {
        currentSeat = s;
    }

    public Seat GetCurrentSeat()
    {
        return currentSeat;
    }

    public bool IsGoingToTheB()
    {
        return bathroom;
    }

    void PhoneCall()
    {
        //
        //start animation phonecall 
        //
        Collider[] tempcol = Physics.OverlapSphere(transform.position, disturbanceRadius, LayerMask.GetMask("Player"));

        if (tempcol != null) {
            foreach(Collider col in tempcol)
            {
                PlayerController playerAffected = col.gameObject.GetComponent<PlayerController>();
                if (playerAffected.seated)
                {
                    playerAffected.Disturb(true);
                }
            }

        }
        phoneCall = false;


    }
    void Bathroom()
    {
        if (steps < 7)
        {
            if (waitTime <= 0)
            {
                if (Mathf.Abs((tr.position - target).magnitude) >= 0.1 && target != Vector3.zero)
                {
                    tr.position += (target - tr.position).normalized * moveSpeed * Time.deltaTime;
                }
                else
                {
                    switch (steps)
                    {
                        case 0:
                            target = tr.position + (Vector3.forward);
                            break;

                        case 1:
                            if (tr.position.x > 15)
                            {
                                target = new Vector3(21, tr.position.y, tr.position.z);
                            }
                            else if (tr.position.x > 11)
                            {
                                target = new Vector3(8.7f, tr.position.y, tr.position.z);
                            }
                            else if (tr.position.x > -1)
                            {
                                target = new Vector3(6, tr.position.y, tr.position.z);
                            }
                            else
                            {
                                target = new Vector3(-5.5f, tr.position.y, tr.position.z);
                            }
                            currentSeat.SetOccupied(false);
                            break;

                        case 2:
                            target = new Vector3(tr.position.x, tr.position.y, -20);
                            break;
                        case 3:
                            waitTime = Random.Range(4, waitTime);
                            target = new Vector3(tr.position.x, tr.position.y, currentSeat.transform.position.z + 1);
                            break;
                        case 4:
                            target = currentSeat.gameObject.transform.position + (Vector3.forward);
                            target.y = tr.position.y;
                            break;
                        case 5:
                            target = currentSeat.gameObject.transform.position;
                            target.y = tr.position.y;
                            currentSeat.SetOccupied(true);
                            break;
                        default:
                            target = Vector3.zero;
                            break;
                    }
                    steps++;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            bathroom = false;
        }
    }
}
