using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform leftPoint, rightPoint;
    public bool isActive = false;

    public float delay = 0.5f;
    public float duration = 2f;

    public LayerMask detectLayer;

    private LineRenderer lineRend;

    private void Awake() //Esto necesita usar Awake porque el OnEnable() va antes que Start()
    {
        lineRend = GetComponent<LineRenderer>();
    }
    private void OnEnable()
    {
        StartCoroutine(EnableLaserCRT());
    }

    IEnumerator EnableLaserCRT()
    {
        //Calcular una posición aleatoria para el eje z
        int zPos = Random.Range(-6, 7);
        transform.position = new Vector3(0, transform.position.y, zPos);

        yield return new WaitForSeconds(delay);

        isActive = true;

        //Configurar el line para que una los dos puntos
        lineRend.positionCount = 2;
        lineRend.SetPosition(0, leftPoint.position);
        lineRend.SetPosition(1, rightPoint.position);

        yield return new WaitForSeconds(duration);

        lineRend.positionCount = 0;
        isActive = false;
        gameObject.SetActive(false);
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
        if(Physics.Linecast(leftPoint.position, rightPoint.position, out RaycastHit hit, detectLayer))
        {
            //LLamar a la función de morir del personaje
            hit.collider.GetComponent<BalanceCharacter>().Die();

            isActive = false;
        }
    }
}
