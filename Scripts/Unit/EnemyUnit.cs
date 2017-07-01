using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyUnit : Unit {

	MyUnit cMyUnit;

	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		MeterCreate ();
		inEnemyHitArea = false;
		isDuringAttack = false;
		agent.speed = unitSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		MeterUpdate();
		if (inEnemyHitArea) {
			StartAttacking ();
		}

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

	void StartAttacking(){
		inEnemyHitArea = false;
		cMyUnit = TargetEnemyUnit.GetComponent<MyUnit>();
		agent.speed = 0;
		StartCoroutine(attackTime());
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

	IEnumerator attackTime(){
		isDuringAttack = true;

		while (true) {
			if(cMyUnit.life > 0){
				cMyUnit.life -= attackPoint;
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
