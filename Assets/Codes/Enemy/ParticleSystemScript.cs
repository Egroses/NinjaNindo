using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour
{
    ParticleSystem particleSystemObject;
    ParticleSystemRenderer particleSystemRenderer;
    Color EnemyColor;
    void Start()
    {
        EnemyColor = transform.parent.Find("mesh").GetComponent<SkinnedMeshRenderer>().material.color;
        particleSystemObject = transform.GetComponent<ParticleSystem>();
        particleSystemRenderer = particleSystemObject.GetComponent<ParticleSystemRenderer>();
        particleSystemRenderer.material.color = EnemyColor;
    }
}
