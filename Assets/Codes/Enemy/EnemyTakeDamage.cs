using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField]
    Material ColorToChange;
    ParticleSystem cutActionOn;

    SkinnedMeshRenderer StickmanColor;
    Rigidbody selfRigid;
    CapsuleCollider selfCollider;
    bool isDeadEnemy;
    EnemyAnimation enemyAnimation;
    [SerializeField]
    GameObject Sword;
    BoxCollider SwordCollider;
    void Start()
    {
        SwordCollider = Sword.GetComponent<BoxCollider>();
        cutActionOn = transform.Find("ParticleSystemObject").GetComponent<ParticleSystem>();
        StickmanColor = transform.Find("mesh").transform.GetComponent<SkinnedMeshRenderer>();
        enemyAnimation = transform.GetComponent<EnemyAnimation>();
        isDeadEnemy = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Shuriken"&&!isDeadEnemy)
        {
            SwordCollider.enabled = false;
            cutActionOn.Play();
            StickmanColor.material = ColorToChange;
            enemyAnimation.setBoolDead();
            isDeadEnemy = true;
        }
    }
}
