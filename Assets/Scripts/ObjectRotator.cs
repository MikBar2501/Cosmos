using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    float x;
    float y;
    float z;

    void Start()
    {
        x = Random.Range(0, 0.7f);
        y = Random.Range(0, 0.7f);
        z = Random.Range(0, 0.7f);
    }


    void Update()
    {
        transform.Rotate(x, y, z);
    }


}
