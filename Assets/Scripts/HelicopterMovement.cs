using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{

    public float speed = 3f;
    SpriteRenderer _renderer;
    UIManager uiManager;
    public SoldierSpawner soldierSpawner;

    public event EventHandler onReset;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        uiManager = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector2.right * h * Time.deltaTime * speed);
        transform.Translate(Vector2.up * v * Time.deltaTime * speed);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.8f, 7.8f), Mathf.Clamp(transform.position.y, -4.2f, 4.2f));

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _renderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector2(0, 0);
            onReset?.Invoke(this, EventArgs.Empty);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            uiManager.takeDamage();
        }
        
        else if (collision.gameObject.CompareTag("Hospital"))
        {
            uiManager.resetSoldierMeter(true);
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            uiManager.takeDamage();
        }
        else if (collision.gameObject.CompareTag("Soldier"))
        {
            uiManager.pickup(collision.gameObject);
        }
    }
}
