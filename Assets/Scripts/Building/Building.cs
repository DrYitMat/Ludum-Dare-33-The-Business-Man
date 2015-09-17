using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	private GameObject prefab;

	public Vector3 location;

	public string buildingName;

	public int buildCost;

	public float buildTime;

	public float buildingUpkeep;

	public float buildingIncome;

	public float buildingHealth;

	protected float buildingSellValue;

	protected bool canBeDestroyed;

	protected bool canBeSold;

	private Builder buildingManager;

	// Use this for initialization
	void Start () {
		buildingManager = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<Builder>();
		prefab = gameObject;
		buildingName = "Default Building";
		buildCost = 0;
		buildTime = 30.0f;
		buildingUpkeep = 10.0f;
		buildingIncome = 0.0f;
		buildingSellValue = 0.0f;
		canBeDestroyed = false;
		canBeSold = true;
		location = new Vector3(0,0,0);
	}

	public virtual void updateValues(){
		buildingName = "Default Building";
		buildCost = 0;
		buildTime = 30.0f;
		buildingUpkeep = 10.0f;
		buildingIncome = 0.0f;
		buildingSellValue = 0.0f;
		canBeDestroyed = false;
		canBeSold = true;
		location = new Vector3(0,0,0);
	}

	public void sellBuilding(){
		if(canBeSold){

		}
		GameObject.Destroy(this);
	}

	public void damageBuilding(float damage){
		buildingHealth -= damage;
		if(buildingHealth <= 0){
			if(buildingManager == null) buildingManager = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<Builder>();
			buildingManager.destroyBuilding(gameObject);
		}
	}

}
