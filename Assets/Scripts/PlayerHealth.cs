using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healthPoint;
    [SerializeField] TMP_Text healthText;


    void Update()
    {
        healthText.text = "Health: " + healthPoint;
    }

    void AddPoints(int hp)
    {
        healthPoint += hp;
    }

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
        Debug.Log("Umar³eœ!!");
        GameManager.instance.End(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<BossHealth>() != null)
        {
            GameManager.instance.InstantiateExplode(transform);
            Damage(healthPoint);
            Destroy(other.gameObject);
        }
        else if(other.GetComponent<EnemyHealth>() != null)
        {
            GameManager.instance.InstantiateExplode(transform);
            Damage(healthPoint);
            Destroy(other.gameObject);
        }
        else if (other.GetComponent<EnemyBullet>() != null)
        {
            GameManager.instance.InstantiateExplode(transform);
            Damage(5);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Health")
        {
            AddPoints(10);
            Destroy(other.gameObject); 
        }
    }
}
