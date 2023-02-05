using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackAnimationEvent : MonoBehaviour
{
    hitToChar Damage;
    [SerializeField]
    GameObject sword;

    void Start()
    {
        Damage = sword.GetComponent<hitToChar>();
    }

    public void setBoolTrueDamage()
    {
        Damage.enemyCanDamage();
    }
}
