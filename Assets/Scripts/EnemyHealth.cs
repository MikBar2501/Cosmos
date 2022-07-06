using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletScript>() != null)
        {
            GameManager.instance.InstantiateExplode(transform);
            GameManager.instance.EnemyDestroy(transform);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
