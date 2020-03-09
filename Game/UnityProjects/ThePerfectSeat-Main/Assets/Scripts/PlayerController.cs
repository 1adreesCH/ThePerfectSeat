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
    Vector3 prevPos;
    Vector3 temp;
    public string[] axis = new string[2];
    public KeyCode seat;
    public KeyCode sprint;
    //public GameObject scoreText;
    private double score;
    public float scoreWin;
    public float timeScore = 1f;
    private float timeTemp;
    public GameObject winText;
    Vector3 scale;
    public GameObject scoreBar;
    public float scoreBarSize;
    private float scoreTemp;
    //private float fixedDeltaTime;
    [SerializeField]
    private bool disturbed = false;
    private float tempSpeed;

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
        disturbed = false;

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
            scale = scoreBar.transform.localScale;
            if (timeTemp <= 0 && !disturbed)
            {
                score++; // increases score
                timeTemp = timeScore;// controls score increase
                scale.x += scoreTemp;
                scoreBar.transform.localScale = scale;
                speed = 0;
            }

            else if(timeTemp <= 0 && disturbed)
            {
                score+=0.5;// increases score 
                timeTemp = timeScore;// controls score increase
                scale.x += scoreTemp/2;
                scoreBar.transform.localScale = scale;
                speed = 0;
            }

            else
            {
                timeTemp -= Time.deltaTime;
            }
        }
        else
        {
            speed = tempSpeed;
            temp.x = Input.GetAxis(axis[0]);
            temp.z = Input.GetAxis(axis[1]);
            temp.y = 0;
            temp = temp.normalized;
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
                
                speed = 0;
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

                speed = tempSpeed;
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
        disturbed = v;
    }

}
