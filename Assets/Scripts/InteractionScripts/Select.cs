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
    [SerializeField]
    float holdTimeForJoint;
    bool isSelected;
    bool isJoined;
    bool isButton;
    bool isPotExplosion;
    Button selectedButton;
    float keyPressedTime;
    GameObject selectedPot;
    GameObject selectedPotExplosion;
    GameObject selectedObject;
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
        //Debug.Log(isSelected);
        //Debug.Log(other);

        if (isJoined == false && isSelected == false)
        {
        switch (other.gameObject.tag)
        {
            case "Selectable":
                isSelected = true;
                selectedObject = other.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                break;
            case "PotExplosion":
                isSelected = true;
                selectedObject = other.gameObject;
                break;
            case "Button":
                isSelected = true;
                selectedObject = other.gameObject;
                selectedButton = selectedObject.GetComponent<Button>();
                selectedButton = selectedObject.GetComponent<Button>();
                var colors = selectedButton.colors;
                colors.selectedColor = Color.green;
                selectedButton.colors = colors;
                selectedButton.Select();
                break;
            default:
                break;
        }
        }


        /*
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
        */
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        switch (other.gameObject.tag)
        {
            case "Selectable":
            case "PotExplosion":
                isSelected = false;
                selectedObject = this.gameObject;
                break;
            case "Button":
                isSelected = false;
                EventSystem.current.SetSelectedGameObject(null);
                selectedObject = this.gameObject;
                break;
            default:
                break;
        }

        /*
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
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (selectedObject.tag)
            {
                case "Selectable":
                    keyPressedTime = Time.time;
                    break;
                case "PotExplosion":
                    selectedObject.GetComponent<ExplodePots>().explodePots(3);
                    break;
                case "Button":
                    selectedButton.onClick.Invoke();
                    break;
                default:
                    break;
            }
            /*
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
            */
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            switch (selectedObject.tag)
            {
                case "Selectable":
                    if ((Time.time - keyPressedTime) <= holdTimeForJoint)
                    {
                        Debug.Log("SelectSelectableObject");
                        if (selectedObject.GetComponentInChildren<PlantGrowth>().ready)
                        {
                            GlobalValues.Instance.happiness.increaseScore(selectedObject.GetComponentInChildren<PlantGrowth>().GetComponent<PlantInfo>().ValuePerHarvest);
                            selectedObject.GetComponentInChildren<PlantGrowth>().restartGrowth();

                        }
                    }
                    break;
                case "PotExplosion":
                    break;
                case "Button":
                    selectedButton.onClick.Invoke();
                    break;
                default:
                    break;
            }
            if (isJoined == true){
                isJoined = false;
                joint.connectedBody = null;
                keyPressedTime = 0;
                Debug.Log("joint Released");
            }

        }
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log(selectedObject);
            //Debug.Log(isSelected);
            //Debug.Log((Time.time - keyPressedTime));

            if (selectedObject.tag == "Selectable" && (Time.time - keyPressedTime) > holdTimeForJoint)
            {
                Debug.Log("joined");
                isJoined = true;
                joint.connectedBody = selectedObject.GetComponentInParent<Rigidbody>();
            }
        }
        
    }
}
