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
        
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
