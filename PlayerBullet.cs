using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D theRb2d;
    public GameObject impactEffct;
    public GameObject impactEffct2;
    public int damageToGive = 50;

    

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRb2d.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "enemy") 
        {
            Instantiate(impactEffct, transform.position, transform.rotation); 
        }
        Destroy(gameObject);
       if(other.tag == "Enemy") 
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);
            Instantiate(impactEffct2, transform.position, transform.rotation);
        }
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
