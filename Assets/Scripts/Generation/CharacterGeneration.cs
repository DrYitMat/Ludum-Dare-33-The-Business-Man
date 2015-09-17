using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterGeneration : MonoBehaviour {

	public GameObject baseCharacter;

	public List<string> characterName = new List<string>();

	public List<GameObject> characterHatList = new List<GameObject>();

	public List<GameObject> characterBodyList = new List<GameObject>();

	public List<GameObject> characterHeadList = new List<GameObject>();

	public NameGenerator nameGenerator;

	private Sprite hatSprite, headSprite, bodySprite, legSprite;

	private int gender;

	private int happyNess;

	private int depravity;

	private int religionity;

	// Use this for initialization
	void Start () {

	}

	public void generateNewCharacter(){
		Vector3 spawnLocation = new Vector3(-8f, -.25f, 0f);
		pickGender();
		pickHat();
		pickBody();
		pickHead();
		GameObject newCharacter = (GameObject) Instantiate(baseCharacter, spawnLocation, Quaternion.identity);
		newCharacter.transform.parent = transform;
		string characterNameFromList = characterName[0] + " " + characterName[1];
		newCharacter.name = characterNameFromList;
		Debug.Log(newCharacter.name);
	}

	/// <summary>
	/// Picks the gender, and thus the name of the character.
	/// </summary>
	private void pickGender(){
		gender = Random.Range(0,3);
		if(gender <= 1){
			characterName = nameGenerator.generateName(true);
		} else{
			characterName = nameGenerator.generateName(false);
		}
	}

	/// <summary>
	/// Picks the hat.
	/// </summary>
	private void pickHat(){
		int hatIndex = Random.Range(0, characterHatList.Count);
		hatSprite = characterHatList[hatIndex].GetComponent<SpriteRenderer>().sprite;
		Debug.Log("Hat sprite is: " + characterHatList[hatIndex].name);
		GameObject.FindGameObjectWithTag("Hat").GetComponent<SpriteRenderer>().sprite = hatSprite;
		GameObject.FindGameObjectWithTag("Hat").GetComponent<SpriteRenderer>().color = pickColor();
	}

	/// <summary>
	/// Picks the body.
	/// </summary>
	private void pickBody(){
		int bodyIndex = Random.Range(0, characterBodyList.Count);
		bodySprite = characterBodyList[bodyIndex].GetComponent<SpriteRenderer>().sprite;
		Debug.Log("Body sprite is: " + characterBodyList[bodyIndex].name);
		GameObject.FindGameObjectWithTag("Body").GetComponent<SpriteRenderer>().sprite = bodySprite;
		GameObject.FindGameObjectWithTag("Body").GetComponent<SpriteRenderer>().color = pickColor();
	}

	/// <summary>
	/// Picks the head.
	/// </summary>
	private void pickHead(){
		int headIndex = Random.Range(0, characterHeadList.Count);
		headSprite = characterHeadList[headIndex].GetComponent<SpriteRenderer>().sprite;
		Debug.Log("Head sprite is: " + characterHeadList[headIndex].name);
		GameObject.FindGameObjectWithTag("Head").GetComponent<SpriteRenderer>().sprite = headSprite;
		GameObject.FindGameObjectWithTag("Head").GetComponent<SpriteRenderer>().color = pickColor();
	}

	/// <summary>
	/// Picks the color.
	/// </summary>
	private Color pickColor(){
		float r = Random.Range(0f,1f);
		float g = Random.Range(0f,1f);
		float b = Random.Range(0f,1f);
		return new Color(r,g,b,1f);
	}
}
