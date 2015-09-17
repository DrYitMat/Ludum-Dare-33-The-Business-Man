using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingThumbnail : MonoBehaviour, IPointerClickHandler{

	private GameObject buildingUI;
	private GameObject buildingNameUI;
	private GameObject buildingCostUI;

	public void pointerEnter(){
	
	}

	#region IPointerClickHandler implementation

	public void OnPointerClick (PointerEventData eventData)
	{

	}

	#endregion

	// Use this for initialization
	void Start () {
		buildingUI = GameObject.FindGameObjectWithTag("BuildingUI");
		buildingNameUI = GameObject.FindGameObjectWithTag("BuildingUI_Name");
		buildingCostUI = GameObject.FindGameObjectWithTag("BuildingUI_Cost");
	}
}
