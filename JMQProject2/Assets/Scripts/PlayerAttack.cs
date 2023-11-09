using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera fpsCamera;

    public GameObject gunPoint;
    public GameObject bullet;
    private float speed;

    private Vector3 rayOrigin;
    private void Start()
    {
        fpsCamera = GetComponentInParent<Camera>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject instance = Instantiate(bullet, gunPoint.transform.position, bullet.transform.rotation);
        instance.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * speed);


        //rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)); //center of camera viewport aka center of screen
        //RaycastHit hit;
        //if (Physics.Raycast(rayOrigin,fpsCamera.transform.forward, out hit)) //no range means no limit to how far bullet can shoot
        //{
        //    GameObject instance = Instantiate(bullet,gunPoint.transform.position, gunPoint.transform.rotation);
        //    instance.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, speed));

        //} 

    }

}
