using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testline : MonoBehaviour
{

    public GameObject cube;
    //private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        //lineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        //lineRenderer.transform.localScale=(0f,0f,1f);
        //lineRenderer.SetWidth(0f, 0f);
        //lineRenderer.startWidth(0f,0f);
        //lineRenderer.endWidth(0f);
        //lineRenderer.transform.localScale(1, 1, 1);
        //gameObject.GetComponent<LineRenderer>().startWidth(2.0f, 1.5f);
        cube.transform.localScale(1, 1, 1);
        //scoreText.GetComponent<Text>().text = "Score:" + score;
        //scaleChange = new Vector3(0f, 0f, 0f);
        Vector3 = Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        //LineRenderer.transform.localScale += scaleChange;
       // sphere.transform.localScale += scaleChange;
        
    }
}
