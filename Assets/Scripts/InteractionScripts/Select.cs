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
    HingeJoint joint;
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
    Color originalColor;

    List<Vector3> PastPositions = new List<Vector3>{};
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
        //Debug.Log("OnTriggerEnter");
        //Debug.Log(isSelected);
        //Debug.Log(other);

        if (isJoined == false && isSelected == false)
        {
        switch (other.gameObject.tag)
        {
            case "Plant":
                isSelected = true;
                selectedObject = other.gameObject;
                    break;
            case "Selectable":
                isSelected = true;
                selectedObject = other.gameObject;
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
            selectedObject.layer = 3;
        }

    }

    void OnTriggerExit(Collider other)
    {
        selectedObject.layer = 0;
        //Debug.Log("OnTriggerExit");
        switch (other.gameObject.tag)
        {
            case "Selectable":
            case "Plant":
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (selectedObject.tag)
            {
                case "Plant":
                case "Selectable":
                    keyPressedTime = Time.time;
                    break;
                case "PotExplosion":
                    selectedObject.GetComponent<ExplodePots>().explodePotsDestroy(3);
                    selectedObject = this.gameObject;
                    break;
                case "Button":
                    selectedButton.onClick.Invoke();
                    break;
                default:
                    break;
            }

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            switch (selectedObject.tag)
            {
                case "Plant":
                    if (selectedObject.GetComponentInParent<PlantGrowth>().ready)
                    {
                        GlobalValues.Instance.happiness.increaseScore(selectedObject.GetComponentInParent<PlantGrowth>().GetComponent<PlantInfo>().ValuePerHarvest);
                        selectedObject.GetComponentInParent<PlantGrowth>().restartGrowth();

                    }
                    break;
                case "Selectable":
                    if ((Time.time - keyPressedTime) <= holdTimeForJoint)
                    {
                        selectedObject.GetComponentInParent<PotMenuToggle>().Toggle();
                    }
                    break;
                case "PotExplosion":
                    break;
                case "Button":
                    break;
                default:
                    break;
            }
            if (isJoined == true){
                isJoined = false;
                //Debug.Log(transform.TransformPoint(Vector3.zero) - PastPositions[0]);
                joint.connectedBody.velocity = (transform.TransformPoint(Vector3.zero) - PastPositions[0] )*10;
                joint.connectedBody = null;
                keyPressedTime = 0;
                //Debug.Log("joint Released");
            }

        }
        if (Input.GetKey(KeyCode.E))
        {
            //Debug.Log(selectedObject);
            //Debug.Log(isSelected);
            //Debug.Log((Time.time - keyPressedTime));

            if ((selectedObject.tag == "Selectable" || selectedObject.tag == "Plant") && (Time.time - keyPressedTime) > holdTimeForJoint)
            {
                //Debug.Log("joined");
                isJoined = true;
                joint.connectedBody = selectedObject.GetComponentInParent<Rigidbody>();
            }
        }
        
        if (PastPositions.Count >= 10) {
            PastPositions.RemoveAt(0);
        }
        PastPositions.Add(transform.TransformPoint(Vector3.zero));
    }
}
