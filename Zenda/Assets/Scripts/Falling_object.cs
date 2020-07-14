using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Falling_object : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 speedMinMax;
    private float speed;
    float visibleHeight;
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleHeight = -Camera.main.orthographicSize - transform.localScale.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < visibleHeight)
        {
            Destroy(gameObject);
        }

        
    }
}
