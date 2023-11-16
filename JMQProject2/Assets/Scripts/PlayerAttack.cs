using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera fpsCamera;
    public Transform gunPoint;

    public GameObject bullet;
    public float speed;

    private void Start()
    {
        fpsCamera = GetComponentInChildren<Camera>();
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
        Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //a ray through the middle of the screen
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75); //a point far away from the player
        }

        //calculate direction
        Vector3 direction = targetPoint - gunPoint.position;

        //instantiate bullet
        GameObject instance = Instantiate(bullet, gunPoint.position, Quaternion.identity);
        instance.transform.forward = direction.normalized;
        instance.GetComponent<Rigidbody>().AddForce(direction.normalized * speed, ForceMode.Impulse);

    }

}
