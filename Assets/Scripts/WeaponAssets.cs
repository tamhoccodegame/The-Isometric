using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[System.Serializable]
public class WeaponWorldInform
{
	public string itemName;
	public string itemDescription;
	public Sprite itemSprite;
    public GameObject itemPrefab;
}

public class WeaponAssets : MonoBehaviour 
{
    public static WeaponAssets instance;
    public WeaponWorldInform[] itemAssets;
    public Transform pfItem;
	// Start is called before the first frame update
	void Start()    
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
