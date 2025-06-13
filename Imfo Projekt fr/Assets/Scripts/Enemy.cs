using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // play hurt animation

        animator.SetTrigger("Hurt"); 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Debug.Log("Enemy died!");
        // Death animation
        animator.SetBool("isDead", true);

        //disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }
}
