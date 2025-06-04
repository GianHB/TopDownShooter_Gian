using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private float shootTime;

    [SerializeField] private int numeroBalas;
    [SerializeField] private float tiempoEntreBalas;

    private float timer;

    private void Start()
    {
        timer = shootTime;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(DispararBalas());
            timer = shootTime;
        }
    }


    private IEnumerator DispararBalas()
    {
        for (int i = 0; i < numeroBalas; i++)
        {
            Disparar1Bala();
            yield return new WaitForSeconds(tiempoEntreBalas);
        }
    }

    private void Disparar1Bala()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        Vector3 direccion = new Vector3(jugador.transform.position.x - transform.position.x, 0f, jugador.transform.position.z - transform.position.z);

        Transform bala = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bala.GetComponent<EnemyBullet>().SetDirection(direccion);
    }
}
