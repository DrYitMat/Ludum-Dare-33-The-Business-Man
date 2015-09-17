using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour {

	public void TakeScreenShot(){
		Application.CaptureScreenshot("/Assets/Screenshots/AwesomeScreenShot.png");
		Debug.Log("Screenshot taken.");
	}
}
