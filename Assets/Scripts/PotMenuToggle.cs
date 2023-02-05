using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotMenuToggle : MonoBehaviour
{
    [SerializeField]
    GameObject Menu;
    // Start is called before the first frame update
    private float timer = 0;
    public void TurnOn()
    {
        Menu.active = true;
        timer = 0;
        InvokeRepeating("delayTurningOff", 0.0f, 1.0f);
    }
    public void TurnOff()
    {
        CancelInvoke("delayTurningOff");
        timer = 0.0f;
        Menu.active = false;
    }
    public void Toggle()
    {
        if (Menu.active == true)
        {
            TurnOff();
        }
        else if (Menu.active == false)
        {
            TurnOn();
        }

    }

    private void delayTurningOff ()
    {
        timer += 1.0f;
        Debug.Log(timer);
        if (timer >= 30.0f)
        {
            Menu.active = false;
            CancelInvoke("delayTurningOff");
        }
    }

}
