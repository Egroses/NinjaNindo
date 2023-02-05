using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAnimationEventScript : MonoBehaviour
{
    [SerializeField]
    GameObject AxeObject;
    ThrowShuriken throwShuriken;
    private void Start()
    {
        throwShuriken = AxeObject.GetComponent<ThrowShuriken>();
    }

    public void ThrowEventOn()
    {
        throwShuriken.ThrowAxeAnimationEvent();
    }
    public void CatchEvenOn()
    {
        throwShuriken.AxeCome();
    }
}
