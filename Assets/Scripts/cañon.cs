using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShooter : MonoBehaviour
{
    public GameObject bulletPrefab; // El prefab de la bala
    public Transform firePoint; // El punto desde donde se dispara la bala
    public float fireRate = 1.0f; // Intervalo entre disparos
    public float bulletSpeed = 10.0f; // Velocidad inicial de la bala
    public float bulletLifetime = 5.0f; // Tiempo despu�s del cual la bala desaparece
    public LayerMask targetLayer; // Capas a las que reaccionar� el raycast

    private float nextFireTime = 0.0f; // Tiempo para el pr�ximo disparo

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            if (Shoot()) // Disparar la bala si el raycast no golpea un obst�culo
            {
                nextFireTime = Time.time + fireRate; // Configurar el tiempo del pr�ximo disparo
            }
        }
    }

    bool Shoot()
    {
        // Disparar la bala directamente, sin chequear raycast
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false; // Asegurarse de que la bala no sea afectada por la gravedad
            rb.velocity = firePoint.forward * bulletSpeed; // Mover la bala hacia adelante
        }

        // Destruir la bala despu�s de un tiempo espec�fico
        Destroy(bullet, bulletLifetime);

        return true; // Disparo exitoso
    }
}







