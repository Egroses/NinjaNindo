using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    [SerializeField] GameManageScript gameManageScript;
    GameObject NextButton;
    GameObject player;
    RunnerAnimation runnerAnimation;
    ParticleSystem particleSystemPlay;
    private void Start()
    {
        player = GameObject.Find("Kano Tsuneo").gameObject;
        particleSystemPlay = player.transform.Find("NinjaBomb").GetComponent<ParticleSystem>();
        runnerAnimation = player.GetComponent<RunnerAnimation>();
        gameManageScript = GameObject.Find("GameManageObject").GetComponent<GameManageScript>();
        NextButton = GameObject.Find("Canvas").transform.Find("Win").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Kano Tsuneo")
        {
            NextButton.SetActive(true);
            gameManageScript.setGameEndTrue();
            runnerAnimation.setTriggerWin();
            particleSystemPlay.Play();
        }  
    }
}
