using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePots : MonoBehaviour
{

    [SerializeField]
    GameObject pot;

    [SerializeField]
    GameObject explosionLocation;


    public void explodePots (int amount)
    {

        for (var i = 0; i < amount; i++)
        {
            Instantiate(pot, explosionLocation.transform).GetComponent<Rigidbody>().AddExplosionForce(2f,explosionLocation.transform.position,2f,1f);
        }
    }

    public void explodePotsDestroy(int amount)
    {
        explodePots(amount);
        Destroy(this.gameObject);
    }
}
