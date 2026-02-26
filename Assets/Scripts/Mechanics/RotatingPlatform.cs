using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public Vector2 timeToRotate = new Vector2(5, 10);

    public Vector2 rotationRange = new Vector2(-10, 10);

    private Quaternion rot; //Rotación que debe tener la plataforma
    public float rotationSpeed = 4f;

    void Start()
    {
        StartCoroutine(RotateCrt());

        rot = Quaternion.Euler(0, 180, 0);
    }

    private void Update()
    {
        //Interpolar la rotación de la plataforma (Slerp interpora haciendo curva: empieza acelerado y termina lento)
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
    }

    IEnumerator RotateCrt()
    {
        while (true)
        {
            yield return new WaitForSeconds (Random.Range(timeToRotate.x, timeToRotate.y));

            float rotX = Random.Range(rotationRange.x, rotationRange.y);
            float rotZ = Random.Range(rotationRange.x, rotationRange.y);

            //Asignar la rotación de la plataforma
            rot = Quaternion.Euler(rotX, 180, rotZ);
        }
    }
}
