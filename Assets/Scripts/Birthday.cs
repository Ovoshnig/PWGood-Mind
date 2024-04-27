using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birthday : MonoBehaviour
{
    [SerializeField] private GameObject cake;
    [SerializeField] private new Light light;

    void Start()
    {
        
    }

    void Update()
    {
        if (cake.transform.position.x >= 0)
        {
            cake.transform.Translate(new Vector3(-0.002f, 0, 0));
            cake.transform.localScale -= new Vector3(0.0002f, 0.0001f, 0.0003f);
        }
        else if (cake.transform.position.x < 0)
        {
            cake.transform.position = new Vector3(5, 9.879f, 0);
            cake.transform.localScale = new Vector3(1, 0.5f, 1);
        }

        light.color = Color.Lerp(Color.white, Color.magenta, Mathf.PingPong(Time.time, 1));
    }
}
