using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
{
    animator = GetComponent<Animator>();
    GetComponent<Health>().onDeath.AddListener(Die);
}

void Die()
{
        animator.SetTrigger("Die");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;

        Destroy(gameObject, 2f); // wait for animation to finish
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
