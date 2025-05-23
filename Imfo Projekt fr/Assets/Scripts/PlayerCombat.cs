using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 25;
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;

    public float swordCooldown = 1f;
    public float fireballCooldown = 10f;

    private float nextSwordTime = 0f;
    private float nextFireballTime = 0f;

    // UI references (assign in inspector)
    public Image swordCooldownImage;
    public Image fireballCooldownImage;

    private int attackIndex = 0;

    void Update()
    {
        float time = Time.time;

        // Sword attack (LMB)
        if (Input.GetMouseButtonDown(0) && time >= nextSwordTime)
        {
            nextSwordTime = time + swordCooldown;
            attackIndex = (attackIndex + 1) % 2;
            animator.SetTrigger("Attack" + attackIndex);

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>()?.TakeDamage(attackDamage);
            }
        }

        // Fireball (RMB)
        if (Input.GetMouseButtonDown(1) && time >= nextFireballTime)
        {
            nextFireballTime = time + fireballCooldown;
            animator.SetTrigger("Fireball");

            Instantiate(fireballPrefab, fireballSpawnPoint.position, transform.rotation);
        }

        UpdateCooldownUI();
    }

    void UpdateCooldownUI()
    {
        float time = Time.time;

        if (swordCooldownImage)
        {
            float swordRemaining = Mathf.Clamp01((nextSwordTime - time) / swordCooldown);
            swordCooldownImage.fillAmount = swordRemaining;
        }

        if (fireballCooldownImage)
        {
            float fireballRemaining = Mathf.Clamp01((nextFireballTime - time) / fireballCooldown);
            fireballCooldownImage.fillAmount = fireballRemaining;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
