using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float sprintSpeed;
    public float minDistance;
    public bool seated = false;
    public string[] axis = new string[2];
    public KeyCode seat;
    public KeyCode sprint;
    public float scoreWin;
    public float timeScore;
    public GameObject winText;
    Vector3 scale;
    public GameObject scoreBar;
    public float scoreBarSize;

    private bool sprinting = false;
    private float scoreTemp;
    [SerializeField]
    private bool disturbed = false;
    private float tempSpeed;
    private int score;
    private float timeTemp;
    public float dashDistance = 0.8f;
    public bool canDash = true;

    Vector3 prevPos;
    Vector3 temp;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        temp = GetComponent<Rigidbody>().velocity;
        score = 0;
        timeTemp = timeScore;
        winText.SetActive(false);
        //this.fixedDeltaTime = Time.fixedDeltaTime;
        scoreTemp = scoreBarSize / scoreWin;
        scale = scoreBar.transform.localScale;
        Time.timeScale = 1f;// unpauses the game 
        tempSpeed = speed;

        anim = GetComponentInChildren<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (score>=scoreWin)
        {
            winText.SetActive(true);// turns on win text
            Time.timeScale = 0f;// pauses the game
        }

        if (seated)
        {
            
            if (timeTemp <= 0 && !disturbed)
            {
                scale = scoreBar.transform.localScale;
                score++;// increases score
                timeTemp = timeScore;// controls score increase
                scale.x += scoreTemp;
                scoreBar.GetComponent<Transform>().localScale = scale;
            }
            else
            {
                timeTemp -= Time.deltaTime;
            }
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
            if ((transform.position - target.position).magnitude < minDistance && !target.GetComponent<Seat>().GetOccupied())
            {
                //prevPos = transform.position;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.position = target.position + Vector3.forward + (Vector3.up * 0.33f);
                transform.rotation = Quaternion.identity;
                anim.SetBool("Seated",true);
                seated = true;

                target.gameObject.GetComponent<Seat>().SetOccupied(true);
                
            }
       }



        if (Input.GetKeyUp(seat))
        {
            if (seated)
            {
                seated = false;
                //transform.position = prevPos;
                target.gameObject.GetComponent<Seat>().SetOccupied(false);
                anim.SetBool("Seated", false);

                timeTemp = timeScore;

            }
        }

        if (Input.GetKeyUp(sprint))
        {
            if (!sprinting)
            {
                sprinting = true;
            }
        }

        if (Input.GetKeyDown(sprint) && (canDash = true))
        {
            canDash = false;
            Dash();

        }

    }

    void Dash()
    {
        Vector3 dashPos = transform.forward;
        float t = 0f;


        dashPos.x = transform.forward.x + dashDistance;
        dashPos.z = transform.forward.z + dashDistance;

        while (t < 1)
        {
            t += Time.deltaTime * 2;
            transform.position = Vector3.Lerp(transform.position, dashPos, t);
            canDash = true;
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
