using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIToggle : MonoBehaviour {

	public List<GameObject> UIObjectList = new List<GameObject>();

	public int toggle = 0;

	public void toggleUI(){
		toggle++;
		if(toggle > 1) toggle = 0;
		if(toggle == 1){
			foreach(GameObject obj in UIObjectList){
				obj.SetActive(false);
			}
			Debug.Log("UI disabled.");
		}
		else{
			foreach(GameObject obj in UIObjectList){
				obj.SetActive(true);
			}
			Debug.Log("UI enabled.");
		}
	}
}
