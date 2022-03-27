using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRb;
    public float moveSpeed;
    public float rangeToChasePlayer;
    private Vector3 moveDirection;

  //  public Animator anim;

    public int health = 150;

    public GameObject[] deathSplatters;

    
    public bool shoudShoot;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    public float fireCounter;
    public float shootRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerControler.instance.transform.position)< rangeToChasePlayer)// distancia para entrar na zona de perseguicao
        {
            moveDirection = PlayerControler.instance.transform.position - transform.position;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
        moveDirection.Normalize();
     
        theRb.velocity = moveDirection * moveSpeed;
       
       

        if (shoudShoot && Vector3.Distance(transform.position,PlayerControler.instance.transform.position)<shootRange)
        {
            fireCounter -= Time.deltaTime;
            if(fireCounter <= 0)
            {
                fireCounter = fireRate;
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                fireCounter = 3;
            }
        }
       
        
       /* if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        } */

    }

    public void DamageEnemy(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            int selectedSplatter = Random.Range(0, deathSplatters.Length);
            int rotation = Random.Range(0, 4);
           Instantiate(deathSplatters[selectedSplatter], transform.position, Quaternion.Euler(0f,0f,rotation*90));
        }

    }
   
     
}
