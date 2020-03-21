using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncreaser : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            obj.GetComponent<Player>().health += 10f;
            Destroy(obj.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
