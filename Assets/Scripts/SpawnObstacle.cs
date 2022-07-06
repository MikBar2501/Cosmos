using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{

    public GameObject [] spawnObject; //zmieniamy na tablicê
    public GameObject boss; //obiekt bossa
    public float spawnRate = 0.5f;
    Vector2 screenBounds;
    [SerializeField] float timeToBoss = 20; //czas po jakim pojawi siê Boss


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        InvokeRepeating("Spawn", spawnRate, spawnRate);
        Invoke("Boss", timeToBoss);
    }

    void Spawn()
    {
        int rand = Random.Range(0, spawnObject.Length);
        Vector3 pos = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), transform.position.y, transform.position.z);
        Instantiate(spawnObject[rand], pos, Quaternion.identity);
    }

    void Boss()
    {
        CancelInvoke("Spawn");
        spawnRate *= 10;
        InvokeRepeating("Spawn", spawnRate, spawnRate);
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
