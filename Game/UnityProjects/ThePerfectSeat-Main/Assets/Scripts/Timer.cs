using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float timer;
    string temp;
    public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
        temp = GetComponent<Text>().text;

        Time.timeScale = 1f;// unpauses the game 
        lose.SetActive(false);// turns off lose text
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
            Time.timeScale = 0f;// pauses the game
            lose.SetActive(true);// turns on lose text
        }

    }
}
