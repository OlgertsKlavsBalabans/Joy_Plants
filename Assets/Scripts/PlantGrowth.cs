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
            float percentDone =  (this.GetComponent<PlantInfo>().GrowTime - timeRemaining) / this.GetComponent<PlantInfo>().GrowTime;
            this.GetComponentInParent<Rigidbody>().gameObject.GetComponentInChildren<RadialProgressManager>().setValue(percentDone);
        }
        else
        {
            ready = true;
            this.GetComponentInParent<Rigidbody>().gameObject.GetComponentInChildren<RadialProgressManager>().setValue(100);

        }
    }
    public void restartGrowth()
    {
        timeRemaining = this.GetComponent<PlantInfo>().GrowTime;
        ready = false;
        this.GetComponentInParent<Rigidbody>().gameObject.GetComponentInChildren<RadialProgressManager>().setValue(0);
    }
}
