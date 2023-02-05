using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    TrailRenderer trailRenderer;
    ThrowShuriken throwShuriken;
    private void Start()
    {
        throwShuriken = transform.parent.GetComponent<ThrowShuriken>();
        trailRenderer = transform.GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (!GameManageScript.Instance.getGameEnd() && !trailRenderer.enabled)
        {
            trailRenderer.enabled = true;
        }
        if(throwShuriken.getCheckFinishThrowing() && GameManageScript.Instance.getGameEnd() && trailRenderer.enabled)
        {
            trailRenderer.enabled = false;
        }
    }
}
