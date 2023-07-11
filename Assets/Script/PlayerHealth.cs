using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;


    [SerializeField] private Animator animator;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Rigidbody2D rigidbody;
   private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
   private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    TakeDamageForPlayer(20);
        //}
    }

    public void TakeDamageForPlayer(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        animator.SetBool("deaded", true);

        GetComponent<Collider2D>().enabled = false;
        rigidbody.gravityScale = 0f;
        this.enabled = false;
    }
}
