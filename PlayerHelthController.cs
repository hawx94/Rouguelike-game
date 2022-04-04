using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelthController : MonoBehaviour
{
    public static PlayerHelthController instance;

    public int currentHealth, maxHealth;
    public float damageInvincLength = 1f;
    public float invincCount;

    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCount > 0)
        {
            invincCount-= Time.deltaTime; 
            if(invincCount <= 0)
            {
                PlayerControler.instance.bodySr.color = new Color(PlayerControler.instance.bodySr.color.r, PlayerControler.instance.bodySr.color.g, PlayerControler.instance.bodySr.color.b, 1f);
            }
        }
    }

    public void DamagePlayer()
    {
        if(invincCount <= 0){

             currentHealth--;
            invincCount = damageInvincLength;
            PlayerControler.instance.bodySr.color = new Color(PlayerControler.instance.bodySr.color.r, PlayerControler.instance.bodySr.color.g, PlayerControler.instance.bodySr.color.b, .5f);

             if (currentHealth <=  0)
              {
                 PlayerControler.instance.gameObject.SetActive(false);
                 UIController.instance.deathScreen.SetActive(true);
              }

         UIController.instance.healthSlider.value = currentHealth;
         UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    
        }
    }

    public void MakeInvencible(float length)
    {
        invincCount = length;
        PlayerControler.instance.bodySr.color = new Color(PlayerControler.instance.bodySr.color.r, PlayerControler.instance.bodySr.color.g, PlayerControler.instance.bodySr.color.b, 1f);
    }
}
