using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThings : MonoBehaviour
{
    public float spawnRadius = 6f;
    public Vector3 spawnOrigin = Vector3.zero;

    public List<GameObject> prefabs;

    public Vector2 spawnTimeRange = Vector2.one;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCrt());
    }

    void SpawnObject()
    {
        //La función de Random calcula un punto aleatorio dentro de una esfera de radio 1
        //Para aumentar el radio, se multiplica ese valor por el radio que queremos
        //Para mover la posición de la esfera, se le suma la posición de origen que queremos

        Vector3 spawnPosition = (Random.insideUnitSphere * spawnRadius) + spawnOrigin;
        spawnPosition.y = spawnOrigin.y;

        //Spawnear un objeto aleatorio en la posición calculada
        int prefabIndex = Random.Range(0, prefabs.Count);
        Instantiate(prefabs[prefabIndex], spawnPosition, prefabs[prefabIndex].transform.rotation);
    }

    IEnumerator SpawnCrt()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimeRange.x, spawnTimeRange.y));

            SpawnObject();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnOrigin, spawnRadius);
    }
}
