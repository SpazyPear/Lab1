using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    float health = 1;
    public Slider healthBar;
    public Image healthBarFill;
    public GameObject blackScreen;
    public GameObject gameOverText;
    public GameObject[] soldierIcons;
    public GameObject soldierMeter;
    public SoldierSpawner soldierSpawner;
    int soldiersHolding = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBarFill.color = Color.Lerp(Color.red, Color.green, health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        health -= (1f / 3f);
        healthBar.value = health;
        healthBarFill.color = Color.Lerp(Color.red, Color.green, health);

        if (health <= 0)
        {
            blackScreen.SetActive(true);
            gameOverText.SetActive(true);
            soldierMeter.SetActive(false);
        }
    }

    public void pickup(GameObject collision)
    {
        if (soldiersHolding <= 2)
        {
            Destroy(collision);
            soldierIcons[soldiersHolding].SetActive(true);
            soldiersHolding++;
            soldierSpawner.spawnNewSoldier();
        }
    }

    public void resetSoldierMeter()
    {
        soldiersHolding = 0;
        foreach (GameObject obj in soldierIcons)
        {
            obj.SetActive(false);
        }
    }
}
