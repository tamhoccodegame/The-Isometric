using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponOnGround : MonoBehaviour, IPickable
{
	// Dữ liệu của vũ khí
	public string weaponName;      // Tên vũ khí
	public string weaponDescription; //Mô tả vũ khí
	public int weaponDamage;             // Sát thương
	public Sprite weaponSprite;      // Icon vũ khí
	public GameObject weaponPrefab; // Prefab của vũ khí khi trang bị
	[Range(0, 3f)]
	public int weaponType;

	private Canvas infoCanvas;    // Canvas hiển thị thông tin
	private bool isPlayerNearby;  // Kiểm tra người chơi có gần hay không

	public void HideInform()
	{
		infoCanvas.gameObject.SetActive(false);
	}

	public void OnInteract(PlayerInteraction player)
	{
		player.PickUpWeapon(weaponPrefab, weaponType);
		Destroy(gameObject);
	}

	public void ShowInform()
	{
		infoCanvas.gameObject.SetActive(true);
		foreach(Transform child in infoCanvas.transform)
		{
			if (child.name == "WeaponName")
				child.GetComponent<TextMeshProUGUI>().text = weaponName;
			if (child.name == "WeaponDescription")
				child.GetComponent<TextMeshProUGUI>().text = weaponDescription;
			if (child.name == "WeaponImage")
				child.GetComponent<Image>().sprite = weaponSprite;
			if(child.name == "WeaponDamage")
				child.GetComponent<TextMeshProUGUI>().text = weaponDamage.ToString();
		}
	}

	private void Start()
	{
		// Lấy Canvas con
		infoCanvas = GetComponentInChildren<Canvas>();
		if (infoCanvas != null)
		{
			infoCanvas.gameObject.SetActive(false); // Ẩn thông tin ban đầu
		}
	}


	private void Update()
	{

	}

}
