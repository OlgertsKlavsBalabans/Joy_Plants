using UnityEngine;

public class HappinessScore : MonoBehaviour
{
    public int happinessScore { get; set; }

    public void increaseScore(string id)
    {
        happinessScore = happinessScore + 1; 
        
    }

    public void resetScore()
    {
        happinessScore = 0;
    }
}
