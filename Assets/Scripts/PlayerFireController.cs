using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float period = 1.0f;
    private float _cooldown = 0.0f;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_cooldown <= 0) 
            {
                _cooldown = period;
                Shoot();

            }
            
        }
        _cooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Projectile.Projectile>().Velocity = new Vector3(0, 3);
    }
}