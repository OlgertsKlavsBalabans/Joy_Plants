using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChooser : MonoBehaviour
{
    [SerializeField]
    List<GameObject> potList;
    // Start is called before the first frame update
    void Start()
    {
        int chosenPot = Random.Range(0, potList.Count);
        GameObject modelInstance = Instantiate(potList[chosenPot], this.transform);
        modelInstance.AddComponent<BoxCollider>();
        modelInstance.tag = "Selectable";
    }
}