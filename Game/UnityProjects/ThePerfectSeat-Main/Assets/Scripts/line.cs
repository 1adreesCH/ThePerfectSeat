using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public GameObject cube;
    Vector3 scale;
    
    void Start()
    {
        //scale = new Vector3(1f, 1f, 1f);
        //Vector3 scale = cube.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        scale = cube.transform.localScale;
        scale.x += 1f;
        cube.transform.localScale = scale;
    }
}
