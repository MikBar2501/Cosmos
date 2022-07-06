using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
    public float speed = 20f;

    void FixedUpdate()
    {
        transform.position -= new Vector3(0, speed, 0);
    }
}
