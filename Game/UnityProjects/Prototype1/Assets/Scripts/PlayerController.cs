using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float minDistance;
    bool seated = false;
    Vector3 prevPos;
    Vector3 temp;
    public string[] axis = new string[2];
    public KeyCode seat;

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
            }
        }
        if (Input.GetKeyUp(seat))
        {
            if (seated)
            {
                seated = false;
                transform.position = prevPos;
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
