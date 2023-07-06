using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private CapsuleCollider2D capsuleCollider;

    private int enemyDamage = 20;
    [SerializeField] private PlayerHealth playerHealth;
    private int currentHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamageForPlayer(20);
        }
    }

    private void Start()
    {
        rigidbody.isKinematic = true;
        currentHealth = maxHealth;
    }

    public void TakeDamageForEnemies(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        rigidbody.gravityScale = 0f;
        this.enabled = false;
    }

}
