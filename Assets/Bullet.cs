using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(transform.eulerAngles.y == 0)
        {
            rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
        }
        if(transform.eulerAngles.y == 180f)
        {
            rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        }
        
    }
}
