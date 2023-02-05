using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    public static GlobalValues Instance;
    public HappinessScore happiness;
    public GameObject HappinessLabel;
    

    private void Start()
    {
        Instance = this;
        happiness = new HappinessScore();
        happiness.resetScore();
        //newGame.startNewGame();
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }




}


