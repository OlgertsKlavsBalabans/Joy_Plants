using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour

{
    [SerializeField]
    Material defaultMaterial;
    [SerializeField]
    Material selectedMaterial;
    [SerializeField]
    SpringJoint joint;
    bool isSelected;
    bool isJoined;
    float keyPressedTime;
    GameObject selectedPot;
    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        isJoined = false;
        keyPressedTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Debug.Log(isSelected);
        Debug.Log(other);


        if (other.gameObject.tag == "Selectable" && !isSelected)
        {
            //other.gameObject.GetComponent<MeshRenderer>().material = selectedMaterial;
            isSelected = true;
            selectedPot = other.gameObject;
            Debug.Log("Selected");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");

        if (isSelected && !isJoined)
        {
            //other.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            isSelected = false;
            Debug.Log("Released");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected && keyPressedTime != 0)
        {
            keyPressedTime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.E) && isJoined)
        {
            Debug.Log("joint Released");

            isJoined = false;
            joint.connectedBody = null;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(isSelected);
            Debug.Log((Time.time - keyPressedTime));

            if (isSelected && (Time.time - keyPressedTime) > 1)
            {

                Debug.Log("joined");

                isJoined = true;
                joint.connectedBody = selectedPot.GetComponentInParent<Rigidbody>();
            }
        }

    }
}
