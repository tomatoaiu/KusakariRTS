using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy: MonoBehaviour {

	public int attackPoint;

	public GameObject castle; // 相手のボス

	UnityEngine.AI.NavMeshAgent agent;

	private bool isSoldier;
	private bool isCastle;

	private Status lifeP;

	private bool isAttack;

	private Vector3 castlePos; // 相手のボスの位置
	private Vector3 targetPos;


	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		isSoldier = false;
		isCastle = false;
		isAttack = false;

		castlePos = castle.transform.position;
//		Debug.Log (castlePos);
	}
	
	// Update is called once per frame
	void Update () {

		// 攻撃中
		if (isAttack) {
			agent.speed = 0;
			// 攻撃対象の体力がなくなったら
			if (lifeP.getHitPoint() == null || lifeP.getHitPoint () <= 0) {
				agent.speed = 3.5f;
				isSoldier = false;
				isCastle = false;
				isAttack = false;

			}
		} else {
			agent.destination = castlePos;
		}

		if (isSoldier) {
			agent.destination = targetPos;
		} else {
			agent.destination = castlePos;
		}
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Soldier") {
			targetPos = other.transform.position;
			isSoldier = true;
		} else if(other.gameObject.tag == "MyCastle"){
			isCastle = true;
		}


		if((isSoldier || isCastle) && other.gameObject.tag == "Myphy"){
			isAttack = true;
			agent.speed = 0;
			lifeP = other.GetComponent<Status> ();

			StartCoroutine(attackTime());

		}
	}


	IEnumerator attackTime(){
		while (true) {
			if(lifeP.getHitPoint() > 0){
				lifeP.setHitPoint (lifeP.getHitPoint () - attackPoint);
			}
			yield return new WaitForSeconds (3.0f);
		}

	}
}
