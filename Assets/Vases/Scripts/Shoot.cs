using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shoot : MonoBehaviour {
    private Transform camera1;
    public Rigidbody[] projectails;    

    private float time = 0;
    
    void Start()
    {
        if (GetComponentInChildren<Camera>())
            camera1 = GetComponentInChildren<Camera>().transform;
    }

    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > time)
            {
                Attack();
                time = Time.time + 0.1f;
            }
           

        }
    }

    void Attack()
    {
        Rigidbody projectile = Instantiate(projectails[Random.Range(0, projectails.Length)]);

        projectile.transform.position = camera1.position + camera1.forward *2f;
        projectile.transform.rotation = Random.rotation;

        projectile.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50)));
        projectile.GetComponent<Rigidbody>().velocity = 
        gameObject.GetComponent<Rigidbody>().velocity + camera1.TransformDirection(new Vector3(0, 0, 15f));

        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), transform.GetComponent<Collider>());
    }
}
