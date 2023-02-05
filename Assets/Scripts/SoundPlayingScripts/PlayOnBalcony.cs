using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnBalcony : MonoBehaviour
{
    private int chsenAudio;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            chsenAudio = Random.Range(1, 2);
            GlobalValues.Instance.audioSources[chsenAudio].Play(0);
        }
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            GlobalValues.Instance.audioSources[chsenAudio].Stop();
        }
    }
}
