using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] Vector3 target;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 0.01f);
    }
}
