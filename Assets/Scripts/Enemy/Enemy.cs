using UnityEngine;

public class Enemy : EnemyController
{

    [SerializeField] private int contactDamage;

    protected override void Start()
    {
        base.Start(); 
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(contactDamage); 
            }
            Destroy(gameObject); 
        }
    }
}
