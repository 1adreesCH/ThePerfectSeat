using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingChairs : MonoBehaviour
{
    [SerializeField]
    GameObject chairPrefab;
    [SerializeField]
    int numberOfOptions;
    [SerializeField]
    float radius = 4;
    [SerializeField]
    float smoothing = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < numberOfOptions; i++)
        //{
        //    GameObject temp = Instantiate(chairPrefab, GetComponent<Transform>()) as GameObject;
        //    Transform tr = temp.GetComponent<Transform>();
        //    tr.localPosition = new Vector3(Mathf.Cos((Mathf.PI / numberOfOptions) * i * 2), 0, Mathf.Sin((Mathf.PI / numberOfOptions) * i * 2)) * radius;
        //    tr.forward = -tr.localPosition.normalized;
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Transform>().Rotate(new Vector3(0,1/smoothing,0));
    }
}
