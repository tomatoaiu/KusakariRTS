using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class DropUnitClick : MonoBehaviour {

	UnitData unitData = new UnitData();

	// Use this for initialization
	void Start () {
		unitData.unitName = gameObject.name;
		unitData.attackPoint = 30;
		unitData.unitSpeed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnPointerClick(){
		Debug.Log (gameObject.name);
		Debug.Log ("clickされたオブジェクト説明をしたい");

		string json = JsonUtility.ToJson(unitData);
		unitData = JsonUtility.FromJson<UnitData> (json);

		Debug.Log("unitData name " + unitData.unitName);
		Debug.Log("unitData attackPoint " + unitData.attackPoint);
		Debug.Log("unitData unitSpeed " + unitData.unitSpeed);
	}
}
