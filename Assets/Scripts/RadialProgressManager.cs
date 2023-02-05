using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgressManager : MonoBehaviour
{
    [SerializeField]
    GameObject progressImage;

    public void setValue (float value)
    {
        progressImage.GetComponent<Image>().fillAmount = value;
    }
}
