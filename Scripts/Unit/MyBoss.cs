using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBoss : MyUnit {

	// Use this for initialization
	void Start () {
		UnitInit();
	}
	
	// Update is called once per frame
	void Update () {
		UnitSet ();
	}

	protected override void SetUpUnitStatus ()
	{
		unitName = "MyHouse";
		attackPoint = 0;
		unitSpeed = 0;
		life = 300f;
		maxLife = 300f;
		attackInterval = 0;
	}

	void OnTriggerEnter(Collider col){

		//		Debug.Log (unitName + "が検知したタグ : " + col.gameObject.tag);
		if (col.tag == "MyCastle") {
			enemyBoss = col.gameObject;
			agent.SetDestination (enemyBoss.transform.position);
			//			Debug.Log (1);

		} else if (col.tag == "MyUnit") {
			enemyUnit = col.gameObject;
			agent.SetDestination (enemyUnit.transform.position);
			//			Debug.Log (2);

		}
	}

	void OnTriggerStay(Collider col){

		if (isDuringAttack) {
			return;
		}
		if (col.tag == "MyUnit") {
			enemyUnit = col.gameObject;
			agent.SetDestination (enemyUnit.transform.position);
		} else if (col.tag == "MyCastle") {
			enemyBoss = col.gameObject;
			agent.SetDestination (enemyBoss.transform.position);

		}

	}
}
