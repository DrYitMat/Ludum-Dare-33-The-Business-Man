using UnityEngine;
using System.Collections;

public class Drilling_Rig : Building {

	void Start(){
		buildCost = 250;
		buildTime = 5.0f;
		buildingUpkeep = 20.0f;
		buildingName = "Drilling Rig";
		canBeDestroyed = true;
		//addUpkeepCost();
	}
	
	public override void updateValues ()
	{
		base.updateValues ();
		buildCost = 250;
		buildTime = 5.0f;
		buildingUpkeep = 20.0f;
		buildingName = "Drilling Rig";
	}
}
