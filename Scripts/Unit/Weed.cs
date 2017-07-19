using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : EnemyUnit {

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
		attackPoint = 10;
		attackInterval = 4f;
		unitName = "Weed";
		life = 60f;
		maxLife = 60f;
		unitSpeed = 2f;
	}

	void OnTriggerEnter(Collider col){
//		Debug.Log (col.tag);
		//		Debug.Log (unitName + "が検知したタグ : " + col.gameObject.tag);
		if (col.tag == "MyCastle") {
			enemyBoss = col.gameObject;
			agent.SetDestination (enemyBoss.transform.position);
//						Debug.Log (1);

		} else if (col.tag == "MyUnit") {
			enemyUnit = col.gameObject;
			agent.SetDestination (enemyUnit.transform.position);
//			Debug.Log (2);

		}
	}

	void OnTriggerStay(Collider col){

//		if (isDuringAttack) {
//			return;
//		}
//		if (col.tag == "MyUnitHitArea") {
//			agent.speed = 0;
//		}

		if (col.tag == "MyUnit") {
			enemyUnit = col.gameObject;
			agent.SetDestination (enemyUnit.transform.position);
		} else if (col.tag == "MyCastle") {
			enemyBoss = col.gameObject;
			agent.SetDestination (enemyBoss.transform.position);

		}
	}
}
