using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotMenuPrice : MonoBehaviour
{
    [SerializeField]
    GameObject priceLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalValues.Instance.happiness.happinessScore < int.Parse(priceLabel.GetComponent<TMPro.TextMeshProUGUI>().text))
        {
            this.GetComponentInParent<Button>().interactable = false;
        }
        else
        {
            this.GetComponentInParent<Button>().interactable = true;
        }
    }
}
