using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public void progress(float totalTime, float currentTimeSpend){
		gameObject.GetComponent<Image>().fillAmount = currentTimeSpend/totalTime;
	}
}
