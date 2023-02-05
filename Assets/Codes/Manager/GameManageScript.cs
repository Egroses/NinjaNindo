using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManageScript : Singleton<GameManageScript>
{
    bool GameEnd;
    void Start()
    {
        GameEnd = true;
    }
    
    public void setGameEndFalse()
    {
        GameEnd = false;
    }
    public void setGameEndTrue()
    {
        GameEnd = true;
    }
    public bool getGameEnd()
    {
        return GameEnd;
    }
}
