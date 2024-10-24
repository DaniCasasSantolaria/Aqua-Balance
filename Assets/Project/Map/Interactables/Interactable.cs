using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected bool isOn;          // Mode
    protected float timer;
    protected float timeToChangeState;
    public GameObject aimedObject;

    protected void AddTime()
    {
        if (!isOn)
        {
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    protected void CheckTimeToChangeState()
    {
        if (timer >= timeToChangeState)
        {
            isOn = !isOn;
        }
    }
}
