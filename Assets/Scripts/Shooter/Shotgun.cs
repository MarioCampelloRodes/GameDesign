using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int numberOfProjectiles = 27;
    protected override void Shoot()
    {
        for (int i = 0;  i < numberOfProjectiles; i++)
        {
            //Generar rayo al centro de la cámara
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, mainCamera.nearClipPlane));

            //Dispersar el rayo
            ray.direction += GetRandomSpread();

            //Disparar con Raycast
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Debug.Log($"Shot: {hit.collider}");
            }

            Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 0.5f);
        }
    }
}
