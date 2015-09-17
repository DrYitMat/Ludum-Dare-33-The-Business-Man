using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThumbnailSelect : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler {

	// Because each thumbnail has this script, all variable need to be private
	private GameObject thumbPrefab;

	private Transform buildingParent;

	private Transform thumbNailUIParent;

	private Builder buildingManager;

	private Text thumbNameUI;
	private Text thumbCostUI;

	void Start(){
		buildingParent = GameObject.FindGameObjectWithTag("BuildingParent").GetComponent<Transform>();
		thumbNailUIParent = GameObject.FindGameObjectWithTag("ThumbnailParent").GetComponent<Transform>();
		thumbPrefab = gameObject.GetComponent<Builder.ThumbnailDataHolder>().prefab;
		buildingManager = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<Builder>();
		thumbNameUI = GameObject.FindGameObjectWithTag("BuildingUIName").GetComponent<Text>();
		thumbCostUI = GameObject.FindGameObjectWithTag("BuildingUICost").GetComponent<Text>();
	}

	#region IPointerEnterHandler implementation

	public void OnPointerEnter (PointerEventData eventData)
	{
		thumbNameUI.text = thumbPrefab.GetComponent<Building>().buildingName;
		thumbCostUI.text = "Cost: " + thumbPrefab.GetComponent<Building>().buildCost;
	}

	#endregion

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		int sibIndex = transform.GetSiblingIndex();
		GameObject newThumbnail = (GameObject) Instantiate(gameObject, thumbNailUIParent.position, Quaternion.identity);
		newThumbnail.transform.SetParent(transform.parent);
		newThumbnail.transform.SetSiblingIndex(sibIndex);
		transform.SetParent(transform.parent.parent.parent);
		newThumbnail.transform.localScale.Scale(Vector3.one);
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		if(buildingManager.currency.BoolBuy(thumbPrefab.GetComponent<Building>().buildCost)){
			Vector3 camToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 pos = new Vector3(camToWorld.x, camToWorld.y, transform.position.z);
			transform.position = pos;
			GameObject newObject = (GameObject) Instantiate(thumbPrefab, pos, Quaternion.identity); 
			newObject.transform.SetParent(buildingParent);
			buildingManager.addNewBuilding(newObject);
		}else{
			Debug.Log("Not enough cash.");
		}
		Destroy(gameObject);
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = eventData.position;
	}

	#endregion


}
