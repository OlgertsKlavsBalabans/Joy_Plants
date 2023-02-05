using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets{
public class PlayFootsteps : MonoBehaviour
{
    StarterAssetsInputs inputs;
    FirstPersonController controller;
    
    void Start()
    {
        controller = this.GetComponent<FirstPersonController>();
        inputs = this.GetComponent<StarterAssetsInputs>();
    }
    void Update()
    {
        if ((inputs.move.x != 0 || inputs.move.y != 0) && controller.Grounded == true && GlobalValues.Instance.audioSources[3].isPlaying == false) {
           GlobalValues.Instance.audioSources[3].Play(0);
       } 
       
       if (GlobalValues.Instance.audioSources[3].isPlaying &&((inputs.move.x == 0 && inputs.move.y == 0) || controller.Grounded == false) ){
                    GlobalValues.Instance.audioSources[3].Stop();
       }
       
    }
}
}