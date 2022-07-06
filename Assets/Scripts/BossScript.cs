using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    [SerializeField] Transform gun1;
    [SerializeField] Transform gun2;
    [SerializeField] Transform gun3;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 8;
    [SerializeField] float bombsSpeed = 10;

    private void Start()
    {
        StartCoroutine(BossRush());
    }

    void Shoot(Transform gun)
    {
        GameObject bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.down * bulletSpeed;
    }

    void TripleShoot()
    {
        Shoot(gun1);
        Shoot(gun2);
        Shoot(gun3);
    }

    void DoubleShoot()
    {
        Shoot(gun2);
        Shoot(gun3);
    }

    void BombAttack(Transform gun, int bombsAmount)
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

    IEnumerator BossRush()
    {
        while (true) 
        {
            yield return new WaitForSeconds(2f);
            BombAttack(gun1, 20);
            for (int i = 0; i < 12; i++)
            {
                TripleShoot();
                yield return new WaitForSeconds(0.1f);
                DoubleShoot();
                yield return new WaitForSeconds(0.1f);
                DoubleShoot();
                yield return new WaitForSeconds(0.1f);
            }
            BombAttack(gun2, 8);
            TripleShoot();
            for (int i = 0; i < 10; i++)
            {
                DoubleShoot();
                yield return new WaitForSeconds(0.1f);
                TripleShoot();
                yield return new WaitForSeconds(0.1f);
                DoubleShoot();
                yield return new WaitForSeconds(0.1f);
                TripleShoot();
                yield return new WaitForSeconds(0.1f);
            }
            BombAttack(gun3, 16);
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < 6; i++)
            {
                Shoot(gun1);
                yield return new WaitForSeconds(0.1f);
                Shoot(gun2);
                Shoot(gun3);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(5f);
            BombAttack(gun1, 10);
            for (int i = 0; i < 20; i++)
            {
                Shoot(gun2);
                yield return new WaitForSeconds(0.2f);
                Shoot(gun3);
                yield return new WaitForSeconds(0.2f);
            }
            BombAttack(gun1, 10);
            for (int i = 0; i < 10; i++)
            {
                TripleShoot();
                yield return new WaitForSeconds(0.1f);
            }
            BombAttack(gun2, 16);
            BombAttack(gun3, 16);
            yield return new WaitForSeconds(6f);
        }
    }


}
