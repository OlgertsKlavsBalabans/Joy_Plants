using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public float timeRemaining;
    public bool ready;
    // Start is called before the first frame update
    void Start()
    {
        restartGrowth();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            ready = true;
        }
    }
    public void restartGrowth()
    {
        timeRemaining = this.GetComponent<PlantInfo>().GrowTime;
        ready = false;
    }
}
