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

        transform.Translate(Vector3.right * h * Time.deltaTime * speed);
        transform.Translate(Vector3.up * v * Time.deltaTime * speed);

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            uiManager.takeDamage();
        }
        else if (collision.gameObject.CompareTag("Soldier"))
        {
            uiManager.pickup(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Hospital"))
        {
            uiManager.resetSoldierMeter(true);
        }
    }
}
