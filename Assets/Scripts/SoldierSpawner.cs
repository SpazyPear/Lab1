using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    public GameObject soldierPrefab;
    public HelicopterMovement helicopterMovement;
    // Start is called before the first frame update
    void Start()
    {
        spawnNewSoldier();
        helicopterMovement.onReset += respawnSoldier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnNewSoldier()
    {
        StartCoroutine(findSpawnPos());
    }

    IEnumerator findSpawnPos()
    {
        Vector2 spawnPos;
        while (true)
        {
            spawnPos.x = UnityEngine.Random.Range(-4, 10);
            spawnPos.y = UnityEngine.Random.Range(-3, 3);
            if (!Physics.CheckBox(spawnPos, soldierPrefab.transform.localScale))
            {
                Instantiate(soldierPrefab, spawnPos, Quaternion.identity);
                yield break;
            }
            yield return null;
        }
    }

    void respawnSoldier(object sender, EventArgs e)
    {
        Destroy(GameObject.FindGameObjectWithTag("Soldier"));
        StartCoroutine(findSpawnPos());
    }

}
