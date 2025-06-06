using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;

        rb.linearVelocity = moveDir * moveSpeed;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 lookDir = hitInfo.point - transform.position;
            lookDir.y = 0; 
            transform.forward = lookDir;

            if (Input.GetMouseButtonDown(0)) 
            {
                Shoot(lookDir.normalized);
            }
        }
    }

    void Shoot(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        bullet.GetComponent<PlayerBullet>().SetDirection(direction);
    }
}
