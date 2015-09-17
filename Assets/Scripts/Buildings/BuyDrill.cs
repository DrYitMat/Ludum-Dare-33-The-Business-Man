using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuyDrill : MonoBehaviour {

	// All public's are set in Unity Editor
	public Currency currency;

	public Builder buildingManager;

	public Mining miningManager;

	public Transform buildingMaster;

	public GameObject drillPrefab;
	private Building drill;

	public GameObject drillPadSelected;

	private GameObject UIObj;
	
	public bool buildingDrill;

	public List<Transform> drillPadsBuiltOn = new List<Transform>(); 

	// Use this for initialization
	void Start () {
		drill = drillPrefab.GetComponent<Building>();
		UIObj = GameObject.FindGameObjectWithTag("BuyDrillUI");
		buildingDrill = false;
	}

	public void buttonBuy(){
		StartCoroutine(buyDrillCoRoutine());
	}

	public IEnumerator buyDrillCoRoutine(){
		if(drillPadSelected == null){
			drillPadSelected = GameObject.FindGameObjectWithTag("DrillPad");
		}
		if(!buildingDrill){
			bool padAlreadyBuiltOn = false;
			if(drillPadsBuiltOn !=null){
				foreach(Transform t in drillPadsBuiltOn){
					if(t == drillPadSelected.transform){
						padAlreadyBuiltOn = true;
					}
				}
			}
			if(!padAlreadyBuiltOn){
				if(currency.BoolBuy(drill.buildCost) && drillPadSelected!=null){
					Debug.Log("Buying drill");
					addPadToList(drillPadSelected);
					buildingDrill = true;
					yield return new WaitForSeconds(drill.buildTime);
					GameObject newDrill = (GameObject) Instantiate(drillPrefab, drillPadSelected.transform.position, Quaternion.identity);
					newDrill.transform.SetParent(buildingMaster);
					miningManager.drillCountAdd();
					buildingDrill = false;
					addDrillToBuildingList(newDrill);
					Debug.Log("Built Drill!");
				}else{ 
					Debug.Log("Earn more $$ to build.");
				}
			}else{
				Debug.Log("Error: Pad already built on. Please pick another pad.");
			}
		}else { 
			Debug.Log("Can't do that right now, currently building drill.");
		}
	}

	private void addPadToList(GameObject toAdd){
		Transform tToAdd = toAdd.transform;
		drillPadsBuiltOn.Add(tToAdd);
	}

	public void setDrillPad(GameObject drillPad){
		drillPadSelected = drillPad;
	}

	private void addDrillToBuildingList(GameObject obj){
		buildingManager.builtObjects.Add(obj);
	}
}
