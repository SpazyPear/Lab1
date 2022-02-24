using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    float health = 1;
    public Slider healthBar;
    public Image healthBarFill;
    public GameObject blackScreen;
    public GameObject gameOverText;
    public GameObject winText;
    public GameObject[] soldierIcons;
    public GameObject GameUI;
    public SoldierSpawner soldierSpawner;
    public TMPro.TMP_Text soldiersRescuedLabel;
    int soldiersHolding = 0;
    int soldiersRescued = 0;
    public HelicopterMovement helicopterMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBarFill.color = Color.Lerp(Color.red, Color.green, health);
        helicopterMovement.onReset += resetUI;
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
            GameUI.SetActive(false);
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

    public void resetSoldierMeter(bool deposit)
    {

        if (deposit)
        {
            soldiersRescued += soldiersHolding;
            if (soldiersRescued >= 15)
            {
                GameUI.SetActive(false);
                blackScreen.SetActive(true);
                winText.SetActive(true);
            }
            soldiersRescuedLabel.text = "Soldiers Rescued: " + soldiersRescued.ToString();
        }
        soldiersHolding = 0;
        foreach (GameObject obj in soldierIcons)
        {
            obj.SetActive(false);
        }
        
    }

    void resetUI(object sender, EventArgs e)
    {
        GameUI.SetActive(true);
        blackScreen.SetActive(false);
        winText.SetActive(false);
        gameOverText.SetActive(false);
        resetSoldierMeter(false);
        soldiersRescued = 0;
        soldiersRescuedLabel.text = "Soldiers Rescued: 0";
        healthBar.value = 1;
        health = 1;
        healthBarFill.color = Color.green;
    }

}
