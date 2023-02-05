using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMesh;
    //[SerializeField] Material material;
    [SerializeField] List<Color> Colors;
    void Awake()
    {
        skinnedMesh = transform.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh.material.color = Colors[Random.Range(0, Colors.Count)];
    }


    
}
