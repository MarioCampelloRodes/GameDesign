using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    [SerializeField] private float damageRadius = 0.5f;

    //Capas a las que el fuego afecta
    [SerializeField] private LayerMask damageLayer;
    //Capas de cobertura que bloquean el daño del fuego
    [SerializeField] private LayerMask obstacleLayer;
    protected override void Shoot()
    {
        //Para que use las partículas
        base.Shoot(); 

        Collider[] targets = Physics.OverlapCapsule(mainCamera.transform.position, 
            mainCamera.transform.position + mainCamera.transform.forward * range, damageRadius, damageLayer);

        foreach (Collider target in targets)
        {
            //Calcular la dirección hacia el objetivo
            Vector3 targetDirection = target.transform.position - mainCamera.transform.position;

            //Lanzar el rayo en esa dirección
            if (!Physics.Raycast(mainCamera.transform.position, targetDirection.normalized, targetDirection.sqrMagnitude, obstacleLayer))
            {
                Debug.Log($"{target}, a la parrilla sabe mejor");
            }
        }
        
    }

    protected override void StopShooting()
    {
        if (shootPS != null)
        {
            shootPS.Stop();
        }
    }

    private void OnDrawGizmos()
    {
        if (mainCamera == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mainCamera.transform.position, damageRadius);
        Gizmos.DrawWireSphere(mainCamera.transform.position + mainCamera.transform.forward * range, damageRadius);
    }
}
