using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject initialWeapon;
    public IPickable currentPickable;
    public Transform currentWeaponHolder;
    public Transform meleeWeaponHolder;
    public Transform rangeWeaponHolder;

    // Start is called before the first frame update
    void Start()
    {
        int weaponType = initialWeapon.GetComponent<Weapon>().weaponType;
        PickUpWeapon(initialWeapon, weaponType);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPickable != null && Input.GetKeyDown(KeyCode.F))
        {
            currentPickable.OnInteract(this);
        } 

    }

    public void PickUpWeapon(GameObject weapon, int weaponType)
    {
        switch (weaponType)
        {
            case 1:
                currentWeaponHolder = meleeWeaponHolder;
                break;
            case 2:
                currentWeaponHolder = rangeWeaponHolder;
                break;
        }
        GameObject w = Instantiate(weapon, meleeWeaponHolder.position, transform.rotation, currentWeaponHolder);
        w.transform.localRotation = weapon.transform.rotation;
		GetComponent<PlayerCombat>().EquipWeapon(w, weaponType);
        currentPickable = null;
	}

	private void OnTriggerEnter(Collider other)
	{
		IPickable pickable = other.GetComponent<IPickable>();
        if (pickable != null)
        {
            currentPickable = pickable;
            currentPickable.ShowInform();
        }
	}

	private void OnTriggerExit(Collider other)
	{
		IPickable pickable = other.GetComponent<IPickable>();
        if (pickable != null && pickable == currentPickable)
		{
			currentPickable.HideInform();
			currentPickable = null;
        }
	}
}
