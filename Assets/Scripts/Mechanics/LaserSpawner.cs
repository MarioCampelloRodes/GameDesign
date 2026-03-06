using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public Laser laser;
    public Vector2 minMaxTime = Vector2.one;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaserSpawnCRT());
    }

    IEnumerator LaserSpawnCRT()
    {
        while (true)
        {
            //Sumar la duración del tiempo aleatorio para que de tiempo a que se desactive
            yield return new WaitForSeconds(Random.Range(minMaxTime.x, minMaxTime.y) + laser.duration);
            laser.gameObject.SetActive(true);
        }
    }
}
