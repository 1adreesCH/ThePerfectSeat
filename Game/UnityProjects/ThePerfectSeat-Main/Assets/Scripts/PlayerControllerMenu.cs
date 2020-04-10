using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerMenu : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float sprintSpeed;
    public float minDistance;
    public bool seated = false;
    public string[] axis = new string[2];
    public KeyCode seat;
    public KeyCode sprint;

    private bool sprinting = false;
    private float tempSpeed;

    Vector3 prevPos;
    Vector3 temp;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        temp = GetComponent<Rigidbody>().velocity;
        tempSpeed = speed;
        anim = GetComponentInChildren<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (seated)
        {
            
        }
        else
        {
            temp.x = Input.GetAxis(axis[0]);
            temp.z = Input.GetAxis(axis[1]);
            temp.y = 0;
            if (temp.magnitude > 1)
            {
                temp = temp.normalized;
            }

            transform.forward = temp;
            GetComponent<Rigidbody>().velocity = temp * speed * Time.deltaTime;
        }

       if (Input.GetKeyDown(seat))
       {
            Transform trgtr = target.GetComponent<Transform>();
            if ((transform.position - target.position).magnitude < minDistance && !target.GetComponent<Seat>().GetOccupied())
            {
                //prevPos = transform.position;
                GetComponent<Transform>().SetParent(trgtr.parent);
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.position = target.position - trgtr.forward + (Vector3.up * 0.33f);
                transform.rotation = Quaternion.identity;
                transform.forward = -trgtr.forward;
                anim.SetBool("Seated",true);
                seated = true;
                

                target.gameObject.GetComponent<Seat>().SetOccupied(true);
                
            }
            //transform.position = target.position - trgtr.forward + (Vector3.up * 0.33f);
        }



        if (Input.GetKeyUp(seat))
        {
            if (seated)
            {
                seated = false;
                //transform.position = prevPos;
                target.gameObject.GetComponent<Seat>().SetOccupied(false);
                anim.SetBool("Seated", false);
                GetComponent<Transform>().SetParent(null);
            }
        }

        if (Input.GetKeyUp(sprint))
        {
            if (!sprinting)
            {
                sprinting = true;
            }
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Seat")
        {
            if (!col.gameObject.GetComponent<Seat>().GetOccupied())
            {
                if (target != null)
                {
                    target.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                }
                target = col.transform;
                col.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
        }
    }
    void onTriggerStay()
    {

    }
    void OnTriggerExit(Collider col)
    {
        if (!col.gameObject.GetComponent<Seat>().GetOccupied())
        {
            target.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }

    public void Disturb(bool v)
    {
        //disturbed = v;
    }
}
