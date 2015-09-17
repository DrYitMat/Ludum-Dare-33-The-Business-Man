using UnityEngine;
using System.Collections;

public class Building_HQ : Building {

	 void Start(){
		buildCost = 500;
		buildTime = 10.0f;
		buildingUpkeep = 33.0f;
		buildingName = "Head Quarters";
		canBeDestroyed = true;
		//addUpkeepCost();
	}

	public override void updateValues ()
	{
		base.updateValues ();
		buildCost = 500;
		buildTime = 10.0f;
		buildingUpkeep = 33.0f;
		buildingName = "Head Quarters";
		canBeDestroyed = true;
	}
}
