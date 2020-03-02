using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    // Start is called before the first frame update

    bool occupied = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
