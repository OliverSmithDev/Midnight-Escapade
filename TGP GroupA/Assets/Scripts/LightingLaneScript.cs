using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingLaneScript : MonoBehaviour
{
    public int LaneCounter;
    public GameObject LightLane1;
    public GameObject LightLane2;
    public GameObject LightLane3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LaneCounter = MoveScript.Lane;

        if (LaneCounter == 0)
        {
            LightLane1.SetActive(true);
            LightLane2.SetActive(false);
            LightLane3.SetActive(false);
        }
        if (LaneCounter == 1)
        {
            LightLane1.SetActive(false);
            LightLane2.SetActive(true);
            LightLane3.SetActive(false);
        }
        if (LaneCounter == 2)
        {
            LightLane1.SetActive(false);
            LightLane2.SetActive(false);
            LightLane3.SetActive(true);
        }
    }
}
