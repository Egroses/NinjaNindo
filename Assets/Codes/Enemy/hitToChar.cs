using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitToChar : MonoBehaviour
{
    bool canDamage;
    RunnerAnimation runnerAnimation;
    GameManageScript gameManageScript;
    GameObject playerObject,GameManageObject;
    BoxCollider swordCollider;
    GameObject TryButton;
    void Start()
    {
        TryButton = GameObject.Find("Canvas").transform.Find("Try").gameObject;
        playerObject = GameObject.Find("Kano Tsuneo");
        GameManageObject = GameObject.Find("GameManageObject");
        gameManageScript = GameManageObject.GetComponent<GameManageScript>();
        runnerAnimation = playerObject.GetComponent<RunnerAnimation>();
        canDamage = false;
        swordCollider = transform.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"&&canDamage)
        {
            playerIsDeath();
        }
    }

    void playerIsDeath()
    {
        runnerAnimation.setBoolDeadOn();
        gameManageScript.setGameEndTrue();
        canDamage = false;
        TryButton.SetActive(true);
    }
    public void enemyCanDamage()
    {
        canDamage = true;
        swordCollider.enabled = true;
    }
}
