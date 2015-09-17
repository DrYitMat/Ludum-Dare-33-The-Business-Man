using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Builder : MonoBehaviour {

	public class ThumbnailDataHolder : MonoBehaviour{
		public GameObject prefab;
	}

	// All public's set in Unity Editor
	public GameObject ThumbnailUIScrollbar;

	public CombatManager combatManager;

	public Currency currency;

	public List<GameObject> builtObjects = new List<GameObject>();

	public List<GameObject> thumbnailList = new List<GameObject>();

	public GameObject thumbnailPrefab;
	public Transform thumbnailParent;

	// Use this for initialization
	void Start () {
		CreateThumbnails();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void resestUIScrollBar(GameObject UI){
		UI.GetComponent<Scrollbar>().value = 0;
	}

	private void CreateThumbnails(){
		foreach(GameObject obj in thumbnailList){
			GameObject newThumbnail = (GameObject) Instantiate(thumbnailPrefab, thumbnailParent.position, Quaternion.identity);
			newThumbnail.GetComponent<Image>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
			newThumbnail.transform.SetParent(thumbnailParent);
			ThumbnailDataHolder dataHolder = newThumbnail.AddComponent<ThumbnailDataHolder>();
			dataHolder.prefab = obj;
			resestUIScrollBar(ThumbnailUIScrollbar);
		}
	}

	public void addNewBuilding(GameObject obj){
		StartCoroutine(buildNew(obj));
	}

	public IEnumerator buildNew(GameObject obj){
		obj.GetComponent<SpriteRenderer>().color =  new Color(1f,1f,1f,.5f);
		Debug.Log("Building " + obj.GetComponent<Building>().buildingName);
		yield return new WaitForSeconds(obj.GetComponent<Building>().buildTime);
		Debug.Log("Built " + obj.GetComponent<Building>().buildingName);
		obj.GetComponent<SpriteRenderer>().color = Color.white;
		builtObjects.Add(obj);
		float upKeep = obj.GetComponent<Building>().buildingUpkeep;
		float income = obj.GetComponent<Building>().buildingIncome;
		currency.addToUpkeepCost(upKeep);
		currency.addToIncomeRecieved(income);
		combatManager.SetIgnoreCollisions();
	}

	public void destroyBuilding(GameObject obj){
		float upKeep = obj.GetComponent<Building>().buildingUpkeep;
		float income = obj.GetComponent<Building>().buildingIncome;
		currency.addToUpkeepCost(-upKeep);
		currency.addToIncomeRecieved(-income);
		builtObjects.Remove(obj);
		Destroy(obj);
		combatManager.SetIgnoreCollisions();
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "DefensiveBuilding"){
			Debug.Log("Collision Detected!");
		}
		if(col.gameObject.tag == "DrillPad"){
			Debug.Log("Colliding with drill pad!");
		}
	}


}
