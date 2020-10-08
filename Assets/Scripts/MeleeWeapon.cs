using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public Transform WeaponStart;
    public GameObject WeaponPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log("Insert Weapon swing");
        }
    }

    void Shoot()
    {
        // shooting logic
        Instantiate(WeaponPrefab, WeaponStart.position, WeaponStart.rotation);
    }
}
