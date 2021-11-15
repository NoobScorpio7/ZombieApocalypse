using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public int selectedWeapon = 0; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int prevoius = selectedWeapon;
        if(Input.GetAxis("Mouse ScrollWheel")>0f)
        {
            if (selectedWeapon >= transform.childCount-1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }

        }
        if (selectedWeapon != prevoius)
        {
            SelectWeapon();
        }

    }

    public void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
