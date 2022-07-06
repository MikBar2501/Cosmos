using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float destroyTime;

    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletScript>() != null)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }*/
}
