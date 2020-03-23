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

    public float health;

    bool spawnsCollectable = false;
    public GameObject collectable;

    // Start is called before the first frame update
    void Start()
    {
        //health = Random.Range(2.4f, 5.3f);
        damage = Random.Range(2, 4f);
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

        if(Random.value < 0.1)
        {
            spawnsCollectable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0)
        {
            if(spawnsCollectable)
            {
                Instantiate(collectable, transform.position, Quaternion.identity);
            }
            ScoreScript.scoreValue += 10;
            Destroy(gameObject);
        }

        if(player != null)
        {
            // Enemy will move toward the player target, until it reaches them
            if(Vector2.Distance(transform.position, player.transform.position) > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Random.Range(minspeed, maxspeed)*Time.deltaTime);
            }
            
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
        else
        {
            Time.timeScale = 0;
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
        player.GetComponent<Player>().health -= damage;
    }
}
