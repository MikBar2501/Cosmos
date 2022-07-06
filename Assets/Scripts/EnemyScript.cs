using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform [] guns; //tablica z wszystkimi dzia�ami nazego przeciwnika
    [SerializeField] GameObject bulletPrefab; //prefab pocisku
    [SerializeField] float bulletSpeed = 30f; //pr�dko�� pocisku
    [SerializeField] float attackTime; // co jaki czas przeciwnik b�dzie strzela�
    Transform player; //b�dzie przechowywa� pozycj� gracza
    [SerializeField] bool lookingToPlayer; //czy ma patrze� zawsze na gracza
    Vector3 direction = Vector3.down; //zwrot w stron� gracza
    Vector3 bulletDir = Vector3.down; //kierunek wystrza�u pocisk�w



    void Shoot(Transform gun)
    {
        GameObject bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = bulletDir * bulletSpeed;
    }

    void Attack()
    {
        foreach(Transform gun in guns)
        {
            Shoot(gun);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Attack", attackTime, attackTime);
    }

    void Target()
    {
        if (lookingToPlayer)
        {
            direction = (transform.position - player.transform.position).normalized;
            transform.up = direction;
            bulletDir = -direction;
        }
        else
        {
            bulletDir = Vector3.down;
        }
    }

    void Update()
    {
        Target();
    }
}
