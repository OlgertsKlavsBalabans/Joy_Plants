using UnityEngine;

public class HappinessScore : MonoBehaviour
{
    public int happinessScore { get; set; }

    public void increaseScore(int amount)
    {
        happinessScore = happinessScore + amount;
        GlobalValues.Instance.HappinessLabel.GetComponent<TMPro.TextMeshProUGUI>().text = happinessScore.ToString();
    }

    public void decreaseScore(int amount)
    {
        //if (happinessScore > amount)
        //{
        happinessScore = happinessScore - amount;
        GlobalValues.Instance.HappinessLabel.GetComponent<TMPro.TextMeshProUGUI>().text = happinessScore.ToString();
        //}
        //else
        //{
        //    Debug.Log("Game Over!");
        //}

    }


    public void resetScore()
    {
        happinessScore = 0;
    }
}
