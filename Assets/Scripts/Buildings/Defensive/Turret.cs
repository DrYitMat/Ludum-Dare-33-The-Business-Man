using UnityEngine;
using System.Collections;

public class Turret : Building {

	public int attackRadius;

	public int attackSpeed;
	
	public int damage;

	public GameObject target;

	public CombatManager combatManager;

	// Use this for initialization
	void Start () {
		combatManager = GameObject.FindGameObjectWithTag("CombatManager").GetComponent<CombatManager>();
	}

	private IEnumerator Attack(){
		Debug.Log("Turret attack co-routine");
		yield return new WaitForSeconds(attackSpeed);
		target.GetComponent<Enemy>().takeDamage(damage);
	}

	void Update(){
		if(combatManager == null) combatManager = GameObject.FindGameObjectWithTag("CombatManager").GetComponent<CombatManager>();
		if(target != null){
			if(Vector3.Distance(transform.position, target.transform.position) <= attackRadius){
				StartCoroutine("Attack");
			}
		}else{
			if(combatManager.enemyList.Count > 0){
				target = combatManager.enemyList[0];
			}
		}
	}
}
