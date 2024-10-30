
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
     private float health = 100f;
     public Slider health_Bar;
    
     public Player_Health Player_Health;
     public Transform cam;
     public Animator animator;

   // Move_Player Move_Player;
  
  

   
  void Update()
  {
    health_Bar.value = health ;
  }
    public void TakeDamage_villan(float amount)
    {
        health -= amount;
        Debug.Log("enemy health" + health);
        if (health <= 0f)
        {
            Debug.Log("distroy");
            Die1();
        }
    }

    public void Die1()
    {
           animator.SetTrigger("Dying");
           Destroy(this.gameObject, 1.5f);
          
    }

    
    void LateUpdate()
    {
        transform.LookAt(cam);
    }
    
}
