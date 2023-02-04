using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


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
    bool isButton;
    bool isPotExplosion;
    Button selectedButton;
    float keyPressedTime;
    GameObject selectedPot;
    GameObject selectedPotExplosion;
    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        isJoined = false;
        isButton = false;
        isPotExplosion = false;
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
        if (other.gameObject.tag == "Button")
        {
            isButton = true; 
            selectedButton = GameObject.Find(other.gameObject.name).GetComponent<Button>();
            var colors = selectedButton.colors;
            colors.selectedColor = Color.green;
            selectedButton.colors = colors;
            selectedButton.Select();
        }
        if (other.gameObject.tag == "PotExplosion")
        {
            isPotExplosion = true;
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
        if (other.gameObject.tag == "Button")
        {
            EventSystem.current.SetSelectedGameObject(null);
            isButton = false;

        }
        if (other.gameObject.tag == "PotExplosion")
        {
            selectedPotExplosion = other.gameObject;
            isPotExplosion = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (isButton)
            {
                Debug.Log("Button click ???");
                selectedButton.onClick.Invoke();

            }
            if (isSelected && keyPressedTime != 0)
            {
                keyPressedTime = Time.time;

            }
            if (isPotExplosion)
            {
                selectedPotExplosion.gameObject.GetComponent<ExplodePots>().explodePots(3);
            }

        }
        if (Input.GetKeyUp(KeyCode.E) && isJoined)
        {
            Debug.Log("joint Released");

            isJoined = false;
            joint.connectedBody = null;
            keyPressedTime = 0;
        }
        if (Input.GetKey(KeyCode.E))
        {
            //Debug.Log(isSelected);
            //Debug.Log((Time.time - keyPressedTime));

            if (isSelected && (Time.time - keyPressedTime) > 1)
            {

                Debug.Log("joined");

                isJoined = true;
                joint.connectedBody = selectedPot.GetComponentInParent<Rigidbody>();
            }
        }
        
    }
}
