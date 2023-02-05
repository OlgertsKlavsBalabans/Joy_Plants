using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePots : MonoBehaviour
{

    [SerializeField]
    GameObject pot;


    public void explodePots (int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            var position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f);
            Instantiate(pot, this.transform).GetComponent<Rigidbody>().AddExplosionForce(1f,this.transform.position,1f,0.5f);
        }
    }
}
