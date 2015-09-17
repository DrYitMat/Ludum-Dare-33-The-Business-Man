using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mining : MonoBehaviour {

	public float timeToMine;

	public float timeSpentMining;

	public int oreCount;

	private float oreValue;

	public int drillCount;

	public Currency currency;

	public int orePerMine;

	private bool hasHQ;

	private float baseTimeToMine;

	public Text oreUI;

	void Init(){
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
		drillCount = 0;
		timeSpentMining = 0;
		baseTimeToMine = 15.0f;
		timeToMine = baseTimeToMine;
		oreCount = 0;
		oreValue = 24.0f;
		orePerMine = 1;
		hasHQ = false;
		updateOreUI();
		StartCoroutine(drillForOre());
	}

	public void updateOreUI(){
		oreUI.text = "Ore Count: " + oreCount;
	}

	public void drillCountAdd(){
		drillCount++;
		timeToMine = (baseTimeToMine - (drillCount * .25f));
		orePerMine += 3;
		if(drillCount == 1) StartCoroutine(drillForOre());
	}

	public void mineOre(){
		if(timeSpentMining >= timeToMine){
			oreCount += orePerMine;
			timeSpentMining = 0f;
			timeToMine += 0.0025f;
			updateOreUI();
			Debug.Log("Ore mined. Ore count: " + oreCount); 
			Debug.Log("Next time to mine: " + timeToMine);
		} else{
			Debug.Log("Not ready to mine ore!");
		}
	}

	public void sellOre(){
		float a = oreCount * oreValue;
		currency.Sell(a);
		oreCount = 0;
		Debug.Log("Sold ore!");
	}

	private IEnumerator drillForOre(){
		while(drillCount > 0){
			Debug.Log("Mining for ore!");
			yield return new WaitForSeconds(timeToMine);
			mineOre();
		}
	}

	void Update(){
		if(drillCount > 0){
			timeSpentMining += Time.deltaTime; }
	}
}
