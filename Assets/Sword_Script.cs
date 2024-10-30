using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Script : MonoBehaviour
{
    int damageAmount = 10;
    public Animator animator;
    public Enemy_Health Enemy_Health;
     public GameObject bloodEffect; // Drag your blood effect prefab here


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Villan"))
        {
            // Trigger animation
            animator.SetTrigger("React");
             // Apply damage
            Enemy_Health.TakeDamage_villan(damageAmount);
            // Spawn blood effect
             SpawnBloodEffect(other);
        }
    }

     private void SpawnBloodEffect(Collider villan)
    {
        // Get the collision point (approximate)
        Vector3 spawnPosition = villan.ClosestPoint(transform.position);

        // Instantiate blood effect at the point of contact with the villan
        Instantiate(bloodEffect, spawnPosition, Quaternion.identity);
    }
}
