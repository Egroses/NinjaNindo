using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAnimation : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    public void setTriggerAxeCatch()
    {
        animator.SetTrigger("AxeCatch");
    }
    public void setTriggerAxeThrow()
    {
        animator.SetTrigger("AxeThrow");
    }

    public void setBoolRunOn()
    {
        animator.SetBool("runOn", true);
    }
    public void setBoolRunOff()
    {
        animator.SetBool("runOn", false);
    }
    public void setBoolDeadOn()
    {
        animator.SetBool("RunnerDead",true);
    }
    public void setBoolDeadOff()
    {
        animator.SetBool("RunnerDead", false);
    }
    public void setTriggerWin()
    {
        animator.SetTrigger("Win");
    }
    public void setTriggerNewGame()
    {
        animator.SetTrigger("newGame"); 
    }
    public void setResetTrigger()
    {
        animator.ResetTrigger("newGame");
    }
}
