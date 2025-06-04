using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    private Vector3 direction;
    private Rigidbody rb;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}