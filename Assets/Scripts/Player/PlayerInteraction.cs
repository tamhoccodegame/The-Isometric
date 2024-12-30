using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public IPickable currentPickable;
    public Transform currentWeaponHolder;
    public Transform meleeWeaponHolder;
    public Transform rangeWeaponHolder;

    // Start is called before the first frame update
    void Start()
    {
        
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
        GameObject w = Instantiate(weapon, meleeWeaponHolder.position, transform.rotation, meleeWeaponHolder);
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
        if (pickable != null)
		{
			currentPickable.HideInform();
			currentPickable = null;
        }
	}
}
