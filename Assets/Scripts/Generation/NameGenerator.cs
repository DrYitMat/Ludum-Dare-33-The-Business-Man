using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NameGenerator : MonoBehaviour {

	/// <summary>
	/// Holds list of potential first names, male.
	/// </summary>
	private List<string> firstNameListMale = new List<string>();
	/// <summary>
	/// Holds list of potential first names, female.
	/// </summary>
	private List<string> firstNameListFemale = new List<string>();
	/// <summary>
	/// Holds list of potential last names.
	/// </summary>
	private List<string> lastNameList = new List<string>();

	// Use this for initialization
	/// <summary>
	/// Start this instance.
	/// 
	/// Populates our list of names. 
	/// </summary>
	void Start () {
		firstNameListMale.Add("Joe");
		firstNameListMale.Add("Bilbo");
		firstNameListMale.Add("Jeramiah");
		firstNameListMale.Add("Moe");
		firstNameListMale.Add("Fri");
		firstNameListMale.Add("George");
		firstNameListMale.Add("Kavinsky");
		firstNameListMale.Add("Thadd");
		firstNameListMale.Add("Wyatt");
		firstNameListMale.Add("Andres");
		firstNameListMale.Add("Morgan");
		firstNameListMale.Add("Daniel");

		firstNameListFemale.Add("Lee-La");
		firstNameListFemale.Add("Maggie");
		firstNameListFemale.Add("Stephanie");
		firstNameListFemale.Add("Bree-Ann");
		firstNameListFemale.Add("Kerry");
		firstNameListFemale.Add("Daphnie");
		firstNameListFemale.Add("Velma");
		firstNameListFemale.Add("Stacy");
		firstNameListFemale.Add("Cindy");
		firstNameListFemale.Add("Quincy");
		firstNameListFemale.Add("Hailey");

		lastNameList.Add(" Turner");
		lastNameList.Add(" Clarkson");
		lastNameList.Add(" Johnson");
		lastNameList.Add(" Smith");
		lastNameList.Add(" Baggins");
		lastNameList.Add(" Van-Sickle");
		lastNameList.Add(" Hammond");
		lastNameList.Add(" May");
		lastNameList.Add(" Olsen");
		lastNameList.Add(" Dunlap");
		lastNameList.Add(" Lopez");
		lastNameList.Add(" Garcia");
		lastNameList.Add(" Plainview");
	}

	/// <summary>
	/// Generates the name.
	/// </summary>
	/// <returns>The name. First name at index 0, last name at index 1</returns>
	/// <param name="male">If set to <c>true</c> male.</param>
	public List<string> generateName(bool male){
		List<string> generatedName = new List<string>();
		string firstName = ("Kody (Default)!");
		string lastName = ("DeMarco (Default)!");
		if(male){
			int a = Random.Range(0, firstNameListMale.Count);
			firstName = firstNameListMale[a];
		} else if (!male){
			int a = Random.Range(0, firstNameListFemale.Count);
			firstName = firstNameListFemale[a];
		}
		int b = Random.Range(0, lastNameList.Count);
		lastName = lastNameList[b];
		generatedName.Add(firstName);
		generatedName.Add (lastName);
		return generatedName;
	}
}
