using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private int damage = 40;
    [SerializeField] private float explosionRadius = 3;
    [SerializeField] private float delay = 2;
    private bool canExplode = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (canExplode)
        {
            canExplode = false;
            StartCoroutine(ExplodeCrt());
        }
    }

    IEnumerator ExplodeCrt()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("boom");

        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider target in targets)
        {
            //Calcular dirección hacia el objetivo
            Vector3 direction = target.transform.position - transform.position;

            //Almacenar la distancia (al cuadrado) hacia el objetivo
            float distance = direction.sqrMagnitude;

            //Multiplicador de daño, por defecto equivale a 1
            float damageMultiplier = 1f;

            if(distance > 1 && distance <= (explosionRadius * explosionRadius) * 0.5f)
            {
                damageMultiplier = 0.5f;
            }
            else if (distance > (explosionRadius * explosionRadius) * 0.5f)
            {
                damageMultiplier = 0.25f;
            }
        }
        
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
