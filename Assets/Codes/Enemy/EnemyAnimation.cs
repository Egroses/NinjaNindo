using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    public void setBoolAttack()
    {
        animator.SetTrigger("enemyAttack");
    }
    public void setBoolDead()
    {
        animator.SetBool("enemyDead",true);
    }
}
