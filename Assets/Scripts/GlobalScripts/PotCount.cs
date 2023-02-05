using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotCount : MonoBehaviour
{
    public int potsGot { get; set; } = 0;
    public int[] potPrice = {5000, 25000, 50000, 100000, 200000, 350000, 500000, 750000, 1000000, 5000, 5000, 5000, 5000, 5000, 5000, 5000, 5000 };
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
                Debug.Log("StartingCorutine !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                StartCoroutine(getPotsDelay(price));
            }
            else
            {
                notEnoughLabel.GetComponent<TMPro.TextMeshProUGUI>().text = "You do not have enough happiness \nto buy more pots!";
            }
        }
    }
    IEnumerator getPotsDelay(int price)
    {
        int chosenAudio =Random.Range(12, 14);
        GlobalValues.Instance.audioSources[chosenAudio].Play(0);
        yield return new WaitUntil(() => GlobalValues.Instance.audioSources[chosenAudio].isPlaying == false);
        GlobalValues.Instance.audioSources[15].Play(0);
        yield return new WaitUntil(() => GlobalValues.Instance.audioSources[15].isPlaying == false);
        potsGot++;
        GlobalValues.Instance.happiness.decreaseScore(price);
        doors.GetComponent<ExplodePots>().explodePots(3);
        GlobalValues.Instance.audioSources[16].Play(0);
        yield return new WaitUntil(() => GlobalValues.Instance.audioSources[16].isPlaying == false);
    }

    private void Update()
    {
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
