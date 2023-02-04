using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{ 
public class StateManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject mainMenuCanvas;
    public void onStartGame()
    {
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;

    }
    public void onExitGame()
    {

    }
}
}
