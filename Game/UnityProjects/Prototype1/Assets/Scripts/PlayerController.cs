using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float sprintSpeed;
    public float minDistance;
    bool seated = false;
    Vector3 prevPos;
    Vector3 temp;
    public string[] axis = new string[2];
    public KeyCode seat;
    public KeyCode sprint;

    // Start is called before the first frame update
    void Start()
    {
        temp = GetComponent<Rigidbody>().velocity;
    }

    // Update is called once per frame
    void Update()
    {

        //temp = GetComponent<Rigidbody>().velocity;
        temp.x = Input.GetAxis(axis[0]);
        temp.z = Input.GetAxis(axis[1]);
        temp.y = 0;
        transform.forward = temp;

        if (!seated)
        {
            temp = temp.normalized * speed * Time.deltaTime;
            GetComponent<Rigidbody>().velocity = temp;
        }
       if (Input.GetKeyDown(seat))
        {
            if ((transform.position - target.position).magnitude < minDistance)
            {
                prevPos = transform.position;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.position = target.position + Vector3.up;
                seated = true;

                target.tag = "Untagged"; //removes tag from the chair the player is currently sitting on. 
            }
        }
        if (Input.GetKeyUp(seat))
        {
            if (seated)
            {
                seated = false;
                transform.position = prevPos;
                
                target.tag = "Seat"; //adds tag to the chair the player is currently sitting on.
            }

        }
        //if (Input.GetKeyDown(seat))
        //{
        //    if (seated)
        //    {
        //        transform.position = prevPos;
        //        seated = false;
        //    }
        //    else if((transform.position - target.position).magnitude < minDistance)
        //    {
        //        prevPos = transform.position;
        //        GetComponent<Rigidbody>().velocity = Vector3.zero;
        //        transform.position = target.position + Vector3.up;
        //        seated = true;
        //    }
        //}

        if (Input.GetKeyDown(sprint))
        {
            speed = sprintSpeed;

        }

        if (Input.GetKeyUp(sprint))
        {
            speed = 600f;  //At this point I was tired and done with unity's shite, so it's hard coded, sorry guys
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Seat")
        {
            if (target != null)
            {
                target.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }
            print(col.name);
            target = col.transform;
            col.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
    }
    void onTriggerStay()
    {

    }
    void OnTriggerExit(Collider col)
    {
        target.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

}
