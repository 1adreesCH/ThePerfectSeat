using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float timer;
    string temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            GetComponent<Text>().text = temp + ((int)timer).ToString();
        }
        else
        {
            //Loose();
        }

    }
}
