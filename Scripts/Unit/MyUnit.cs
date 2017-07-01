/*

unitクラスを継承
自分のキャラクターの移動

*/

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;


public class MyUnit : Unit {

	EnemyUnit cEnemyUnit;

	void Start(){
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		inEnemyHitArea = false;
		isDuringAttack = false;
		MeterCreate ();
	}

	void Update(){
		MeterUpdate();


		if (inEnemyHitArea) { // 自分と相手が戦える距離に入る
			StartAttacking ();
		}
	}

	void OnTriggerEnter(Collider col){

//		Debug.Log (unitName + "が検知したタグ : " + col.gameObject.tag);
		if (col.tag == "EnemyCastle") {
			enemyBoss = col.gameObject;
			agent.SetDestination (enemyBoss.transform.position);

		} else if (col.tag == "EnemyUnit") {
			enemyUnit = col.gameObject;
			agent.SetDestination (enemyUnit.transform.position);
		}

	}

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

	void StartAttacking(){
		inEnemyHitArea = false;
		cEnemyUnit = TargetEnemyUnit.GetComponent<EnemyUnit>();
		agent.speed = 0;
		StartCoroutine(attackTime());
	}

	IEnumerator attackTime(){
		Debug.Log("attackTime" + cEnemyUnit);
		isDuringAttack = true;
		while (true) {
			
			if (cEnemyUnit != null && cEnemyUnit.life > 0) {
				cEnemyUnit.life -= attackPoint;
			} else {
				agent.speed = unitSpeed;
//				agent.SetDestination (enemyBoss.transform.position);
				break;
			}
			yield return new WaitForSeconds (attackInterval); // 待つ
		}
		isDuringAttack = false;
	}
}
