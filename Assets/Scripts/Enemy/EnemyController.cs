using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int currentHealth;

    [SerializeField] protected float moveSpeed;
    protected Transform player;


    protected virtual void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        MoveTowardsPlayer();
    }

    protected void MoveTowardsPlayer()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public virtual void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        GameManager.Instance.AddKill();
        Destroy(gameObject);
    }
}
