using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    float health = 1;
    public Slider healthBar;
    public Image healthBarFill;
    
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
    }
}
