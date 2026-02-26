using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform leftPoint, rightPoint;
    public bool isActive = false;

    public LayerMask detectLayer;

    private LineRenderer lineRend;

    private void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        //Configurar el line para que una los dos puntos
        lineRend.positionCount = 2;
        lineRend.SetPosition(0, leftPoint.position);
        lineRend.SetPosition(1, rightPoint.position);

    }

    private void Update()
    {
        if (isActive)
        {
            LaserDetect();
        }
    }
    
    void LaserDetect()
    {
        if(Physics.Linecast(leftPoint.position, rightPoint.position, detectLayer))
        {
            Debug.Log("me cago");
        }
    }
}
