using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<GameObject> Levels = new List<GameObject>();

    [SerializeField] bool TestLevel = false;

    [ShowIf("TestLevel")][SerializeField] GameObject TestLevelPrefab;
    
    public int levelNumber;

    GameObject go;

    

    private void Start()
    {
        if (TestLevel)
        {
            go = Instantiate(TestLevelPrefab, Vector3.zero + Vector3.forward * 160, Quaternion.identity);
        }
        else
        {
            go = Instantiate(Levels[levelNumber], Vector3.zero + Vector3.forward * 160, Quaternion.identity);
        }
    }
    public void NewLevel()
    {
        Destroy(go);
        EventSystem.Instance.LevelLoadEvent();
        levelNumber = levelNumber+1>=5 ? 0 : levelNumber+1;
        go = Instantiate(Levels[levelNumber], Vector3.zero + Vector3.forward * 160, Quaternion.identity);
    }
    public void LevelAgain()
    {
        Destroy(go);
        EventSystem.Instance.LevelLoadEvent();
        go = Instantiate(Levels[levelNumber], Vector3.zero + Vector3.forward * 160, Quaternion.identity);
    }
}
