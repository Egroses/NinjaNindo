using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventSystem : Singleton<EventSystem>
{
    [SerializeField] UnityEvent GameWin;
    [SerializeField] UnityEvent GameEnd;
    [SerializeField] UnityEvent LevelLoad;

  
    public void GameEndEvent()
    {
        GameEnd.Invoke();
    }
    public void GameWinEvent()
    {
        GameWin.Invoke();
    }
    public void LevelLoadEvent()
    {
        LevelLoad.Invoke();
    }
}
