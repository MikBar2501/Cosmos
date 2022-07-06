using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] int healthPoint;

    void Damage(int dmg)
    {
        healthPoint -= dmg;
        if (healthPoint <= 0)
        {
            healthPoint = 0;
            Death();
        }
    }

    void Death()
    {
        GameManager.instance.End(true);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<BulletScript>() != null)
        {
            GameManager.instance.InstantiateExplode(transform);
            Damage(5);
            Destroy(other.gameObject);
        }

    }
}
