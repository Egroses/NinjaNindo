using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyAnimation enemyAnimation;
    private void Start()
    {
        
        enemyAnimation = transform.parent.Find("stickman").GetComponent<EnemyAnimation>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemyAnimation.setBoolAttack();
        }
    }
}
