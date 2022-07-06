using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] Transform gun1;
    [SerializeField] Transform gun2;
    [SerializeField] Transform gun3;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int weaponLevel = 0;
    [SerializeField] float bulletSpeed = 10;

    [SerializeField] int bombsAmount = 10;
    [SerializeField] float bombsSpeed = 10;
    [SerializeField] int bombCount = 3;


    [SerializeField] TMP_Text bombText;
    [SerializeField] TMP_Text weaponText;


    void ResetWeaponLevel()
    {
        weaponLevel = 1;
    }

    void AddBomb()
    {
        bombCount++;
    }

    void AddWeaponLevel()
    {
        if(weaponLevel < 3)
        {
            weaponLevel++;
        } else
        {
            AddBomb();
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Weapon")
        {
            AddWeaponLevel();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bomb")
        {
            AddBomb();
            Destroy(other.gameObject);
        } 
        else if(other.GetComponent<EnemyBullet>() != null)
        {
            ResetWeaponLevel();
            Destroy(other.gameObject);
        }
    }




    void Shoot(Transform gun)
    {
        GameObject bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.up * bulletSpeed;
    }

    void FireLevel1()
    {
        Shoot(gun1);
    }

    void FireLevel2()
    {
        Shoot(gun3);
        Shoot(gun2);
    }

    void FireLevel3()
    {
        Shoot(gun3);
        Shoot(gun2);
        Shoot(gun1);
    }

    void BombAttack(Transform gun)
    {
        float angleStep = 360 / bombsAmount; //wyliczenie co ile stopni bêdzie nowy pocisk
        float angle = 0f; //startowy k¹t

        for (int i = 0; i < bombsAmount + 1; i++)
        {
            //wyliczenie kierunk w x i y dla wybranego pocisku
            float bulDirX = gun.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = gun.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            //stworzenie wektora po którym bêdzie siê poruszaæ dany pocisk
            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - gun.position).normalized * bombsSpeed;

            //stworzenie pocisku
            GameObject bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);

            //nadanie pociskowi prêdkoœci i kierunku
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(bulDir.x, bulDir.y, 0f);
            //zmiana k¹ta dla kolejnego pocisku
            angle += angleStep;
        }
        
    }

    void Update()
    {
        Attack();
        weaponText.text = "Weapon level: " + weaponLevel.ToString();
        bombText.text = "Bombs: " + bombCount.ToString();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if (weaponLevel > 2)
            {
                FireLevel3();
            }
            else if (weaponLevel == 2)
            {
                FireLevel2();
            }
            else if (weaponLevel < 2)
            {
                FireLevel1();
            }
        }

        if (Input.GetButtonDown("Fire2") && bombCount > 0)
        {
            BombAttack(gun1);
            bombCount--;
            
        }
    }


}
