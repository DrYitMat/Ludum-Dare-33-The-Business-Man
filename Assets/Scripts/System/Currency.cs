using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Currency : MonoBehaviour {

	public Mining mining;

	public float ammount;

	public float incomePerMinute;

	public float upkeepPerMinute;

	public bool autoOreSellEnabled;

	public GameObject currencyUI;

	private string baseString;

	void Init() {
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
		ammount = 1000;
		incomePerMinute = 0;
		upkeepPerMinute = 10;
		autoOreSellEnabled = true;
		StartCoroutine("PayUpkeep");
		StartCoroutine("RecieveIncome");
		StartCoroutine("AutoSell");
		baseString = "Credits: ";
		updateCurrencyString();
	}

	public void updateCurrencyString(){
		currencyUI.GetComponent<Text>().text = baseString + ammount.ToString();
	}

	public void Buy(float a){
		if((ammount - a) >= 0){
			ammount -= a;
			updateCurrencyString();
		}else { Debug.Log("Error: Not enough dosh for that one m8"); }
	}

	public bool BoolBuy(float a){
		if((ammount - a) >= 0){
			ammount -= a;
			updateCurrencyString();
			return true;
		} else { Debug.Log ("Error: Not enough dosh, kimwasabe"); return false; }
	}

	public void Sell(float a){
		ammount += a;
		updateCurrencyString();
	}

	private IEnumerator RecieveIncome(){
		while(true){
			yield return new WaitForSeconds(45.0f);
			Sell(incomePerMinute);
			updateCurrencyString();
			Debug.Log("Recieved Income!");
		}
	}

	private IEnumerator PayUpkeep(){
		while(true){
			yield return new WaitForSeconds(45.0f);
			Buy(upkeepPerMinute);
			updateCurrencyString();
			Debug.Log("Paid upkeep!");
		}
	}

	private IEnumerator AutoSell(){
		while(autoOreSellEnabled){
			yield return new WaitForSeconds(35.0f);
			Debug.Log("Selling ore...");
			mining.sellOre();
			updateCurrencyString();
		}
	}

	public void addToUpkeepCost(float cost){
		upkeepPerMinute += cost;
	}

	public void addToIncomeRecieved(float income){
		incomePerMinute += income;
	}
	
}
