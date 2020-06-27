using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag == "Player")
        {healthBar = GameObject.Find("Helath Bar").GetComponent<HealthBar>();}
        healthBar?.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth == 0){
            this.gameObject.SetActive(false);
        }
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar?.SetHealth(currentHealth);
    }
}
