using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public static PlayerControler instance;

    // variaveis
    public float moveSpeed;
    private Vector2 moveInput;
    public Rigidbody2D theRB;
    public Transform gunArm;
    private Camera theCam;
    public Animator anim;
    public GameObject bulletToFire;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;
    public SpriteRenderer bodySr;
    public float activeMoveSpeed;
    public float dashSpeed = 8f, dashLength = 5f, dashCooldawn = 1f,dashInvencibility = 5f ;
    private float  dashCoolCounter;
    [HideInInspector]
    public float dashCounter;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        theCam = Camera.main;
        activeMoveSpeed = moveSpeed;
    }

   
    void Update()
    {
        Movimento();
        moveInput.Normalize();    
    }

    public void Movimento()
    {
        // MOVIMENTO
        moveInput.x = Input.GetAxisRaw("Horizontal");  
        moveInput.y = Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed , moveInput.y * Time.deltaTime * moveSpeed , 0f);
        theRB.velocity = moveInput * activeMoveSpeed;

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);

        //Flip do personagem
        if(mousePos.x  < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one; 
            gunArm.localScale = Vector3.one; 
        }



        // rotacao da arma
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos .y - screenPoint.y  );
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0, 0, angle);


        // ATIRAR
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            shotCounter = timeBetweenShots;
        }

        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter<= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                anim.SetTrigger("dash");
                anim.SetBool("finishDash", false);

                PlayerHelthController.instance.MakeInvencible(dashInvencibility);

            }
            
        }

        if(dashCounter > 0)
        {
            dashCounter-= Time.deltaTime;
            if(dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldawn;
                anim.SetBool("finishDash", true);
            }
        }
        
        if(dashCoolCounter > 0)
        {
            dashCoolCounter-= Time.deltaTime;
        }

            //Anima��o
        
        if(moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }


}
