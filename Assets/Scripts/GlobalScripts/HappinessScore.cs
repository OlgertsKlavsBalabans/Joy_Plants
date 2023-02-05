using UnityEngine;

public class HappinessScore : MonoBehaviour
{
    public int happinessScore { get; set; }

    public void increaseScore(int amount)
    {
        happinessScore = happinessScore + amount;
        GlobalValues.Instance.HappinessLabel.GetComponent<TMPro.TextMeshProUGUI>().text = happinessScore.ToString();
        Debug.Log(happinessScore); 
    }

    public void decreaseScore(int amount)
    {
        Debug.Log(happinessScore);

        if (happinessScore >= amount)
        {
            happinessScore = happinessScore - amount;
            GlobalValues.Instance.HappinessLabel.GetComponent<TMPro.TextMeshProUGUI>().text = happinessScore.ToString();
        }
        else
        {
            Debug.Log("Not enough happiness");
        }
        Debug.Log(happinessScore);


    }


    public void resetScore()
    {
        happinessScore = 300;
        GlobalValues.Instance.HappinessLabel.GetComponent<TMPro.TextMeshProUGUI>().text = happinessScore.ToString();
    }
}
