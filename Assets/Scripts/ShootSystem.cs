using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public GameObject[] weaponsPrefabs;
    public GameObject[] projectilesPrefab;
    public int[] bulletType;
    int indexWeapon = 0;
    public GameObject target;
    public GameObject laserpoint;
    public bool useOffset = false;

    public float bulletForce = 1000;

    void Start()
    {
        DesactivateWeapons(0); 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            indexWeapon = 0;
            DesactivateWeapons(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            indexWeapon = 1;
            DesactivateWeapons(1);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            indexWeapon = 2;
            DesactivateWeapons(2);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            indexWeapon = 3;
            DesactivateWeapons(3);
        }
        if(Input.GetKey(KeyCode.Alpha5))
        {
            indexWeapon = 4;
            DesactivateWeapons(4);
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            indexWeapon = 5;
            DesactivateWeapons(5);
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            indexWeapon = 6;
            DesactivateWeapons(6);
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            indexWeapon = 7;
            DesactivateWeapons(7);
        }

        if (bulletType[indexWeapon] == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
            }
        }        

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            laserpoint.transform.position = hit.point;
        }
        else
        {
            laserpoint.transform.position = transform.position + transform.forward * 100;
        }

    }

    void Shoot()
    {        
        if (useOffset == false)
        {
            GameObject myprojectile = Instantiate(projectilesPrefab[indexWeapon], new Vector3(transform.position.x + 0.5f, transform.position.y + 0.1f, transform.position.z) + transform.forward, transform.rotation);
            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
        }
        else if (useOffset == true)
        {
            Vector3 offsetVector = target.transform.position;
            GameObject myprojectile = Instantiate(projectilesPrefab[indexWeapon], offsetVector + target.transform.forward, target.transform.rotation);            
            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
        }
        weaponsPrefabs[indexWeapon].GetComponent<Animation>().Play();
    }

    void DesactivateWeapons(int whichActivate)
    {
        foreach(GameObject aux in weaponsPrefabs)
        {
            aux.SetActive(false);
        }
        weaponsPrefabs[whichActivate].SetActive(true);
    }
}

