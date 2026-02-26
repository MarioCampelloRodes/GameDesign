using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceCharacter : MonoBehaviour
{
    public Rigidbody ball;
    public Vector3 offset;
    private Animator anim;
    [SerializeField] private Rigidbody[] ragdollParts;

    public float growDuration = 10f;
    private float growTimer;

    private void Start()
    {
        TryGetComponent(out anim);

        //Buscar todas las partes del cuerpo del Ragdoll
        ragdollParts = GetComponentsInChildren<Rigidbody>();

        //De inicio el ragdoll tiene que estar desactivado
        EnableRagdoll(false);
    }

    void Update()
    {
        transform.position = ball.transform.position + offset;
        anim.SetFloat("Direction", Mathf.Sign(ball.velocity.z));

        //Ha terminado el temporizador del tamaño (Time.time cuenta el tiempo que ha pasado desde que se ha iniciado el juego)
        if(Time.time >= growTimer && transform.localScale.x > 1)
        {
            transform.localScale = Vector3.one;
        }
    }

    public void Die()
    {
        EnableRagdoll(true);
        this.enabled = false;
    }

    void EnableRagdoll(bool enable)
    {
        anim.enabled = !enable; //Si quiero activar el ragdoll, se desactiva el animator y viceversa

        foreach (Rigidbody part in ragdollParts)
        {
            part.isKinematic = !enable; //Si es kinemático, no se puede mover y viceversa
        }
    }

    public void Grow()
    {
        //Aumentar la escala del personaje
        transform.localScale *= 1.1f;

        //Reiniciar el temporizador de volver al tamaño normal
        growTimer = growDuration + Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kill"))
        {
            Die();
        }

        if (other.CompareTag("Mushroom"))
        {
            Grow();

            Destroy(other.gameObject);
        }
    }


}
