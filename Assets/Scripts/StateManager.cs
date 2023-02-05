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

        private void Start()
        {
            GlobalValues.Instance.audioSources[0].Play(0);
        }


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
