using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Weapon
{
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private Transform projectileOrigin;

    protected override void Shoot()
    {
        base.Shoot();
        //Para que el proyectil vaya al centro de la pantalla, lanzamos un rayo para calcular la posición exacta
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f,0.5f, mainCamera.nearClipPlane));

        //Asumimos que el rayo no golpea nada y se usa el forward de la cámara
        Vector3 shootDirection = mainCamera.transform.forward;

        //Si el rayo golpea, actualizamos la dirección de disparo
        if(Physics.Raycast(ray, out RaycastHit hit, range))
        {
            shootDirection = hit.point - projectileOrigin.position;
        }

        Rigidbody projectile = Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
        projectile.velocity = shootDirection.normalized * projectileSpeed;
        
    }

}
