using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UıManager : MonoBehaviour
{
    [SerializeField] GameObject StartButton;
    [SerializeField] GameObject TryButton;
    [SerializeField] GameObject NewButton;
    public void StartSetinvisibleOn()
    {
        StartButton.SetActive(true);
    }
    public void StartSetinvisibleOff()
    {
        StartButton.SetActive(false);
    }
    public void TrySetinvisibleOn()
    {
        TryButton.SetActive(true);
    }
    public void TrySetinvisibleOff()
    {
        TryButton.SetActive(false);
    }
    public void NewSetinvisibleOn()
    {
        NewButton.SetActive(true);
    }
    public void NewSetinvisibleOff()
    {
        NewButton.SetActive(false);
    }
}
