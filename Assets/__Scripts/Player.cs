using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement
    public float speed;
    public GameObject bullet;
    public float timeBetweenSpawn;
    public Transform bulletPosition;
    bool called = false;

    Vector2 movePosition;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        movePosition = new Vector2(Input.GetAxis("Horizontal")*speed*Time.deltaTime, Input.GetAxis("Vertical")*speed*Time.deltaTime);
        movePosition = (rb.position + movePosition);
        movePosition.x = Mathf.Clamp(movePosition.x, -12f, 12f);
        movePosition.y = Mathf.Clamp(movePosition.y, -4.7f, 4.15f);

        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(!called)
            {
                called = true;
                StartCoroutine(SpawnBullet());
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            called = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(movePosition);
    }

    IEnumerator SpawnBullet()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);// waits for time to spawn
        Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);

        if(called)
        {
            StartCoroutine(SpawnBullet());
        }
        
    }
}
