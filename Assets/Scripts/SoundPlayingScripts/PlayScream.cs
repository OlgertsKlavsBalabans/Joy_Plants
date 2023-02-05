using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScream : MonoBehaviour
{
    private int chsenAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            chsenAudio = Random.Range(4, 7);
            GlobalValues.Instance.audioSources[chsenAudio].Play(0);
        }
    }
}
