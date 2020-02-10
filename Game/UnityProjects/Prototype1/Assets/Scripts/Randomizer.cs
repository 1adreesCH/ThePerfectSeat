using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public Renderer[] cubes;
    Renderer selected;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, 7);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            randomize();
            timer = Random.Range(5, 10);
        }
    }

    void randomize()
    {
        if(selected != null)
        {
            selected.material.SetColor("_Color", Color.white);
        }
        selected = cubes[Random.Range(0, cubes.Length)];
        selected.material.SetColor("_Color", Color.black);
    }
}
