using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpell : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile; //Default Cold
    public GameObject lightPrefab;
    public GameObject flameProjectile;
    public Transform firePoint;
    public float projectileSpeed = 30f;
    public float distanceRange = 1000f;

    private Vector3 destination;

    public GameObject NE;
    // Start is called before the first frame update
    void Start()
    {
        NE = this.transform.Find("NightEyeFX").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) //Temporary Cast Key
        {
            ShootProjectile();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            TouchProjectile();
        }
        CastNightEye(10f);
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(distanceRange);
        }

        InstantiateProjectile(projectile, projectileSpeed);
    }

    void TouchProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(distanceRange);
        }

        InstantiateProjectile(flameProjectile, 2f);
    }

    void InstantiateProjectile(GameObject projectileType, float spellSpeed)
    {
        var projectileObj = Instantiate(projectileType, firePoint.position, Quaternion.identity) as GameObject;
        var lights = projectileObj.GetComponentInChildren<ParticleSystem>().lights;
        lights.light = lightPrefab.GetComponentInChildren<Light>();
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * spellSpeed;
    }

    void CastNightEye(float duration)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            NE.SetActive(true);
            Invoke("DisableNE", duration);
        }
    }

    void DisableNE()
    {
        NE.SetActive(false);
    }

}
