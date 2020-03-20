using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Animator anim;
    public float minspeed;
    public float maxspeed;
    public float minDistance;
    SpriteRenderer sprite;
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public float health;


    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(2.4f, 5.3f);
        damage = Random.Range(5f, 10f);
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy will move toward the player target
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Random.Range(minspeed, maxspeed)*Time.deltaTime);

        if(Vector2.Distance(transform.position, player.transform.position) < minDistance)
        {
            anim.Play("Attack");
        }

        if(transform.position.x - player.transform.position.x > 0)
        {
            sprite.flipX = true;
        }

        if(transform.position.x - player.transform.position.x < 0)
        {
            sprite.flipX = false;
        }
        
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag == "Bullet")
        {
            Destroy(obj.gameObject);
            health -= 1f;
        }
    }

    public void DamagePlayer()
    {
        //player.GetComponent<Player>().health -= damage;
    }
}
