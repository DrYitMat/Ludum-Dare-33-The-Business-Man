using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatManager : MonoBehaviour {

	public Builder bManager;

	public Transform spawnPoint;

	public List<GameObject> enemyList = new List<GameObject>();

	public List<GameObject> prefabList = new List<GameObject>();

	public int mobsWanted;

	private bool spawning;

	void Start(){
		SetIgnoreCollisions();
		spawning = false;
		foreach(GameObject obj in prefabList){
			Debug.Log(obj.name);
		}
		StartCoroutine("mobSpawner");
	}

	private IEnumerator mobSpawner(){
		while(true){
			float a = Random.Range(0, 15.0f);
			yield return new WaitForSeconds(a);
			spawnMob();
		}
	}

	public void spawnMob(){
		Debug.Log("Spawning mob...");
		GameObject newEnemy = (GameObject) Instantiate(prefabList[0].gameObject, spawnPoint.position, Quaternion.identity);
		newEnemy.GetComponent<Enemy>().buildingManager = bManager;
		newEnemy.GetComponent<Enemy>().buildAttackList();
		newEnemy.GetComponent<Enemy>().selectTargetBuilding();
		newEnemy.transform.SetParent(transform);
		enemyList.Add(newEnemy);
		Debug.Log("Mob spawned...");
		SetIgnoreCollisions();
	}

	public void destroyEnemy(GameObject obj){
		enemyList.Remove(obj);
		Destroy(obj);
		SetIgnoreCollisions();
	}

	public void SetIgnoreCollisions(){
		foreach(GameObject obj in enemyList){
			foreach(GameObject bObj in bManager.builtObjects){
				Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), bObj.GetComponent<Collider2D>());
			}
		}
	}
}
