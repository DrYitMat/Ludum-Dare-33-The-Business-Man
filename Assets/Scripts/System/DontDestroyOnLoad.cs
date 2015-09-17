using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {
	void Init(){
		DontDestroyOnLoad(this);
	}
}
