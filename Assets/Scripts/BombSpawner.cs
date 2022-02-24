using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shadowPrefab;
    float timer;
    float timeBetweenBombs = 2f;
    void Start()
    {
        timer = timeBetweenBombs;
        StartCoroutine(spawnBombs());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnBombs()
    {
        while (true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Vector2 spawnPos = new Vector2();
                spawnPos.x = UnityEngine.Random.Range(-4, 10);
                spawnPos.y = UnityEngine.Random.Range(-3, 3);
                Instantiate(shadowPrefab, spawnPos, Quaternion.identity);
                timer = timeBetweenBombs;
                yield return null;
            }
            yield return null;
        }
    }
      
}
