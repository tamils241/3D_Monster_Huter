using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player; // Reference to the player's position
    public float moveSpeed = 4.0f; // Speed at which the enemy moves towards the player
    public float attackRange = 3.0f; // Distance at which the enemy will stop and attack
    public float attackCooldown = 0.5f; // Cooldown time between attacks

    private bool hasAttacked = false; // To check if the enemy has attacked
    public Animator ani; 
    public float chasingDistance=20f;
    public AudioSource Audio;
    public AudioClip Attack_Sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        // Make the enemy look at the player
         LookAtPlayer();
        if (hasAttacked)
        {
            // Enemy has already attacked, so stop moving
            return;
        }
        else if (distanceToPlayer <= attackRange)
        {
            // Enemy is close enough to attack
            AttackPlayer();
        }
        else
        {
            // Move towards the player
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        if(Vector3.Distance(transform.position,player.position) < chasingDistance)
        {
          // Move enemy towards the player at the specified speed
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
         ani.SetBool("Attack",false);
         ani.SetBool("Walk",true);
        }
       
    }

    void AttackPlayer()
    {
        // Placeholder for the attack logic
        Debug.Log("Enemy attacks the player!");

        // Set hasAttacked to true to prevent further movement
        hasAttacked = true;
         ani.SetBool("Attack",true);
         ani.SetBool("Walk",false);
         Audio.PlayOneShot(Attack_Sound);

        // Optionally, you can reset `hasAttacked` after some cooldown
        Invoke("ResetAttack", attackCooldown);
    }

    void ResetAttack()
    {
        hasAttacked = false;
    
    }

    void LookAtPlayer()
    {
        // Only rotate if player is within chasing distance
        if (Vector3.Distance(transform.position, player.position) <= chasingDistance)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Create a rotation based on the direction to look at the player
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            // Smoothly rotate the enemy towards the player over time
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
    }

