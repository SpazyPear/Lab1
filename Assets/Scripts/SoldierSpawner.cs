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
            spawnPos.x = UnityEngine.Random.Range(-4, 7);
            spawnPos.y = UnityEngine.Random.Range(-3, 3);
            if (!Physics2D.BoxCast(spawnPos, new Vector2(soldierPrefab.transform.localScale.x + 0.4f, soldierPrefab.transform.localScale.y + 0.4f), 1f, Vector2.zero))
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
