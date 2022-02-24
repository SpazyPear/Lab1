using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowManager : MonoBehaviour
{
    public SpriteRenderer renderer;
    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.3f * Time.deltaTime, 0.3f * Time.deltaTime);
        Color color = renderer.color;
        
        renderer.color = new Color(color.r, color.g, color.b, Mathf.Clamp(color.a + 0.1f * Time.deltaTime, 0, 1));
        if (transform.localScale.magnitude > 3)
        {
            GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            Destroy(bomb, 0.3f);
            Destroy(gameObject);
        }
    }
}
