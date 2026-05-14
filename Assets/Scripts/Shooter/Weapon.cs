using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponStats weaponStats;
    [SerializeField] protected float range = 5f;
    [SerializeField] protected float fireRate = 10f; //Balas por segundo
    [SerializeField] protected float bulletDamage = 10f;
    [SerializeField] protected Vector3 spread = Vector3.zero;

    [SerializeField] protected ParticleSystem shootPS; //Partículas que se verán cada vez que dispare

    private float timeToShoot;
    protected Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;

        ReadStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeToShoot)
        {
            timeToShoot = Time.time + 1 / fireRate;

            Shoot();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopShooting();
        }
    }

    //Las variables protected solo pueden ser llamadas desde scripts que hereden de este
    protected virtual void Shoot()
    {
        Debug.Log("Disparo");
        if(shootPS != null)
        {
            shootPS.Play();
        }
    }

    protected virtual void StopShooting()
    {
        
    }

    //Lee y asigna las estadísticas del Scriptable Object
    protected virtual void ReadStats()
    {
        range = weaponStats.Range;
        fireRate = weaponStats.FireRate;
        bulletDamage = weaponStats.Damage;
        spread = weaponStats.Spread;
    }

    protected Vector3 GetRandomSpread()
    {
        float x = Random.Range(-spread.x, spread.x);
        float y = Random.Range(-spread.y, spread.y);
        float z = Random.Range(-spread.z, spread.z);

        return new Vector3(x, y, z);
    }
}
