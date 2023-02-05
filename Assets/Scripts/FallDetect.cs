using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetect : MonoBehaviour
{
    GameObject PlayerCapsule;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCapsule = GameObject.Find ("PlayerCapsule");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCapsule.transform.position.y <= -10)
        {
            PlayerCapsule.transform.position=new Vector3(4,3,1);
        }
    }
}
