using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelScript : MonoBehaviour
{
    GameManageScript gameManageScript;
    ThrowShuriken throwShuriken;
    RunnerAnimation runnerAnimation;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ButtonStart;
    [SerializeField] GameObject Shuriken;
    [SerializeField] GameObject gameManageObject;
    void Start()
    {
        runnerAnimation = Player.GetComponent<RunnerAnimation>();
        throwShuriken = Shuriken.GetComponent<ThrowShuriken>();
        gameManageScript = gameManageObject.GetComponent<GameManageScript>();
    }

    public void LevelReset()
    {
        runnerAnimation.setBoolDeadOff();
        gameManageScript.setGameEndTrue();
        throwShuriken.returnAxeCompleted();
        
    }
}
