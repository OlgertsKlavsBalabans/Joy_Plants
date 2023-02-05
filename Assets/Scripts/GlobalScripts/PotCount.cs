using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotCount : MonoBehaviour
{
    public int potsGot { get; set; } = 0;
    public int[] potPrice = {5700, 58500, 132000, 234000, 453750, 645000, 858750, 1350000, 1598437, 1743750 };
    [SerializeField]
    GameObject notEnoughLabel;
    [SerializeField]
    GameObject priceLabel;
    [SerializeField]
    GameObject doors;
    [SerializeField]
    GameObject button;

    public void getPot()
    {
        if (potsGot < potPrice.Length - 1)
        {
            int price = potPrice[potsGot];
            if (price <= GlobalValues.Instance.happiness.happinessScore)
            {
                potsGot++;
                GlobalValues.Instance.happiness.decreaseScore(price);
                doors.GetComponent<ExplodePots>().explodePots(3);

            }
            else
            {
                notEnoughLabel.GetComponent<TMPro.TextMeshProUGUI>().text = "You do not have enough happiness \nto buy more pots!";
            }
        }
    }

    private void Update()
    {
        Debug.Log(potsGot);
        Debug.Log(potPrice.Length);
        if (potsGot == potPrice.Length - 1)
        {
            priceLabel.GetComponent<TMPro.TextMeshProUGUI>().text = "No more pots available";
            button.GetComponent<Button>().interactable = false;
        }
        else {
            int price = potPrice[potsGot];
            if (price <= GlobalValues.Instance.happiness.happinessScore)
            {
                notEnoughLabel.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                button.GetComponent<Button>().interactable = true;
            }
            else
            {
                notEnoughLabel.GetComponent<TMPro.TextMeshProUGUI>().text = "You do not have enough happiness \nto buy more pots!";
                button.GetComponent<Button>().interactable = false;
            }
            priceLabel.GetComponent<TMPro.TextMeshProUGUI>().text = price.ToString();
        }
    }


}
