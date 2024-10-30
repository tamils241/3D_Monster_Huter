using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public Slider health_Bar;
    public float health = 200;       // Player's starting health
    public Enemy_Health Enemy_Health;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         health_Bar.value = health;
    }

    // void OnTriggerStay(Collider other) enemy damage 
    
    


    public void TakeDamage_Player(float damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        // Check if health has reached 0 or below
        if (health <= 0)
        {
            Die();
        }
    }

      void Die()
    {
        // Code to handle player death
        Debug.Log("Player has died!");
        animator.SetTrigger("Dying");
        Destroy(gameObject, 2f); // Destroy the player object
       

    }
}
