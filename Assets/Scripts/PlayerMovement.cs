using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 screenBounds;
    public float speed = 5;

    [SerializeField] Transform child;
    public float angle = 45;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        Move();
        StayInside();
    }


    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(moveX, moveY, 0) * speed;
        transform.position += move * Time.deltaTime;

        Quaternion target = Quaternion.Euler(-90, angle * moveX * -1, 0);
        child.transform.rotation = target;
    }

    void StayInside()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, (screenBounds.x * -1), screenBounds.x),
            Mathf.Clamp(transform.position.y, (screenBounds.y * -1), screenBounds.y),
            transform.position.z);
    }
}
