using UnityEngine;
using System.Collections;

public class Soldier : MyUnit {

//	MyUnit myUnit;

	// Use this for initialization
	void Start () {
//		myUnit = GetComponent<MyUnit> ();
		UnitInit();
	}

	// Update is called once per frame
	void Update () {
		UnitSet ();
		UnitMove (); // unitを動かす
	}

	protected override void SetUpUnitStatus ()
	{
		unitName = "Soldier";
		attackPoint = 40;
		unitSpeed = 5f;
		life = 100f;
		maxLife = 100f;
		attackInterval = 5f;
	}

	void UnitMove(){
		if (isDuringAttack) {
			GetComponent<Animator> ().SetBool ("run", false);
			GetComponent<Animator> ().SetBool ("idle", true);
		} else {
			GetComponent<Animator> ().SetBool ("idle", false);
			GetComponent<Animator> ().SetBool ("run", true);
		}
	}

	// 敵の検知
	void OnTriggerEnter(Collider col){

		//		Debug.Log (unitName + "が検知したタグ : " + col.gameObject.tag);
		if (col.tag == "EnemyCastle") {
			Debug.Log (col.gameObject);
			enemyBoss = col.gameObject;
			Debug.Log (enemyBoss.transform.position);
			agent.SetDestination (enemyBoss.transform.position);

		} else if (col.tag == "EnemyUnit") {
			enemyUnit = col.gameObject;
			agent.SetDestination (enemyUnit.transform.position);
		}

	}

	// 敵が範囲内にいる間
	void OnTriggerStay(Collider col){

		if (isDuringAttack) {
			return;
		}
		if (col.tag == "EnemyUnit") {
			enemyUnit = col.gameObject;
			agent.SetDestination (enemyUnit.transform.position);
		} else if (col.tag == "EnemyCastle") {
			enemyBoss = col.gameObject;
			agent.SetDestination (enemyBoss.transform.position);

		}
	}
}
