using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectDrillPad : MonoBehaviour, IPointerClickHandler {

	private BuyDrill buyDrill;
	
	private GameObject drillShadow;

	void Start(){
		buyDrill = GameObject.FindGameObjectWithTag("DrillManager").GetComponent<BuyDrill>();
		drillShadow = GameObject.FindGameObjectWithTag("DrillShadow");
	}

	#region IPointerClickHandler implementation
	
	public void OnPointerClick (PointerEventData eventData)
	{
		if(!buyDrill.buildingDrill){
			buyDrill.setDrillPad(gameObject);
			if(drillShadow != null) drillShadow.transform.position = eventData.pointerPress.transform.position;
		}else{
			Debug.Log("Can not select pad at the moment, already building drill.");
		}
	}
	
	#endregion
}
