using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMove : MonoBehaviour
{
    //[SerializeField]
    //Vector3 bathroom;
    Vector3 initialPos;
    [SerializeField]
    public float moveSpeed;
    int steps;
    bool bathroom;

    Seat currentSeat;

    Vector3 target;
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        target = Vector3.zero;
        tr = GetComponent<Transform>();
        bathroom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bathroom)
        {
            if (steps < 3)
            {
                switch (steps)
                {
                    case 0:
                        target = initialPos + (Vector3.forward);
                        break;

                    case 1:
                        if (initialPos.x > 15)
                        {
                            target = new Vector3(21, initialPos.y, initialPos.z);
                        }
                        else if (initialPos.x > 11)
                        {
                            target = new Vector3(8.7f, initialPos.y, initialPos.z);
                        }
                        else if (initialPos.x > -1)
                        {
                            target = new Vector3(6, initialPos.y, initialPos.z);
                        }
                        else
                        {
                            target = new Vector3(-5.5f, initialPos.y, initialPos.z);
                        }
                        break;

                    case 2:
                        target = new Vector3(initialPos.x, initialPos.y, -20);
                        break;

                    default:
                        target = Vector3.zero;
                        break;
                }
                if (Mathf.Abs((tr.position - target).magnitude) >= 0.1 && target != Vector3.zero)
                {
                    tr.position += (target - tr.position).normalized * moveSpeed * Time.deltaTime;
                }
                else
                {
                    initialPos = tr.position;
                    steps++;
                    if(steps == 1)
                    {
                        currentSeat.SetOccupied(false);
                    }
                }
            }
            else
            {
                bathroom = false;
            }
        }
        
    }

    public void Bathroom()
    {
        bathroom = true;
        initialPos = tr.position;
        steps = 0;
    }

    public void Phone()
    {
        
    }

    public void SetCurrentSeat(Seat s)
    {
        currentSeat = s;
    }

    public Seat GetCurrentSeat()
    {
        return currentSeat;
    }
}
