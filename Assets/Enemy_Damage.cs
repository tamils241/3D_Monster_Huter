using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
     
    public float damageAmount = 10f;        // Amount of damage to apply
    public float attackInterval = 1f;       // Time between attacks (seconds)

    private float nextAttackTime = 0f;      // Time when the next attack should happen
    public Animator animator; 

    // public Player_Health Player_Health;
    // Start is called before the first frame update


    // Damage Player

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
             Player_Health playerHealth = other.GetComponent<Player_Health>();

            if (playerHealth != null && Time.time >= nextAttackTime)
            {
                animator.SetTrigger("React");
                playerHealth.TakeDamage_Player(damageAmount);
                nextAttackTime = Time.time + attackInterval; // Set time for the next attack
            }
          
        }
    }
}
