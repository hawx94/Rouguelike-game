using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelthController : MonoBehaviour
{
    public static PlayerHelthController instance;

    public int currentHealth, maxHealth;


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
        
    }

    public void DamagePlayer()
    {
        currentHealth--;
        if (currentHealth <=  0)
        {
            PlayerControler.instance.gameObject.SetActive(false);
        }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

}
