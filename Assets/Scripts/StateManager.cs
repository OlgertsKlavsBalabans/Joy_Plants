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
         Cursor.lockState = CursorLockMode.Locked;
         player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
         mainMenuCanvas.SetActive(false);
    }
    public void onExitGame()
    {
        Application.Quit();
    }
}
}
