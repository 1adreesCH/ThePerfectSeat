using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    // Start is called before the first frame update

    bool occupied = false;
    float timeSeated = 0;
    [SerializeField]
    int threshold;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (occupied)
        {
            timeSeated += Time.deltaTime;
            if(timeSeated >= threshold)
            {

            }
        }
    }

    public void SetOccupied(bool value)
    {
        occupied = value;
    }
    public bool GetOccupied()
    {
        return occupied;
    }
}
