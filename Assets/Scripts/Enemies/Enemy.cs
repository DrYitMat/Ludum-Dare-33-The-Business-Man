using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public Builder buildingManager;

	private CombatManager combatManager;

	public GameObject targetBuilding;
	public Building preferredBuilding;

	public List<GameObject> buildingAttackList = new List<GameObject>();

	public int health;

	public int damage;

	public float attackSpeed;

	public int speed;

	public float rarity;

	public float attackRadius;

	void Start(){
		combatManager = GameObject.FindGameObjectWithTag("CombatManager").GetComponent<CombatManager>();
	}

	public void buildAttackList(){
		if(buildingAttackList != null){
			buildingAttackList.Clear();
			foreach(GameObject obj in buildingManager.builtObjects){
				Debug.Log("Checking Buildings...");
				if(obj.GetComponent<Building>().buildingName == preferredBuilding.buildingName){
					buildingAttackList.Insert(0, obj);
				}else{ 
					buildingAttackList.Add(obj);
				}
			}
		}else{ Debug.Log("Error found."); }
	}

	public void selectTargetBuilding(){
		if(buildingAttackList.Count > 0) targetBuilding = buildingAttackList[0];
	}

	public IEnumerator Attack(){
		Debug.Log ("Reached attack Co-Routine");
		yield return new WaitForSeconds(attackSpeed);
		Debug.Log ("Attacking...");
		targetBuilding.GetComponent<Building>().damageBuilding(damage);
	}

	void Update(){
		if(targetBuilding != null){
			if(Vector3.Distance(transform.position, targetBuilding.transform.position) <= attackRadius){
				StartCoroutine("Attack");
			}else{
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, targetBuilding.transform.position, step);
			}
		}else{
			buildAttackList();
			selectTargetBuilding();
		}
	}

	public void takeDamage(int d){
		health -= d;
		if(health < 0){
			if(combatManager == null) combatManager = GameObject.FindGameObjectWithTag("CombatManager").GetComponent<CombatManager>();
			combatManager.destroyEnemy(gameObject);
		}
	}
}
