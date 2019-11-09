using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    // Start is called before the first frame update
    public int selected=0;
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previous = selected;
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selected = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount>=2)
        {
            selected = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selected = 2;
        }
        if (previous!=selected)
        {
            SelectWeapon();
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selected)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;

        }
    }
}
