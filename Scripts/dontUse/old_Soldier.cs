using UnityEngine;
using System.Collections;

public class old_Soldier : MonoBehaviour {

	public int attackPoint;

	// モーションブール変数
	bool motionWalk;
	bool motionRun;
	bool motionIdle;
	bool motionAttack;

	public GameObject castle;
	UnityEngine.AI.NavMeshAgent agent;

	private bool isEnemy;
	private bool isCastle;

	private bool isAttack;

	private Status lifeP = null; // 相手のヒットポイント

	private Vector3 castlePos; // 相手のボスの位置
	private Vector3 targetPos;

	public float runSpeed; // スピード
	public float attackInterval; // 攻撃間隔

	Status status;

	void Start () {
		motionWalk = false;
		motionRun = false;
		motionIdle = false;
		motionAttack = false;

		status = GetComponent<Status> ();

		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();

		isEnemy = false;
		isCastle = false;
		isAttack = false;

		castlePos = castle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		// 攻撃中
//		if (isAttack) {
//			agent.speed = 0; // 攻撃中は移動0
//			motionRun = false;
//			motionAttack = true;
//
//			// 攻撃対象の体力がなくなったら走らせる
//			if(lifeP.getHitPoint() == null || lifeP.getHitPoint() <= 0){
//				motionRun = true;
//				motionAttack = false;
//				agent.speed = runSpeed;
//				isEnemy = false;
//				isCastle = false;
//				isAttack = false;
//			}
//		} else {
//			motionRun = true;
//			motionAttack = false;
//			agent.destination = castlePos;
//		}

		float step = runSpeed * Time.deltaTime;

		// 相手に向かって走るかどうか
		if (isEnemy) { // 相手のコマの検知範囲に触れた場合
			motionRun = true;
			motionAttack = false;
			transform.LookAt (targetPos);
			transform.position =  Vector3.MoveTowards (transform.position, targetPos, step);
//			agent.destination = targetPos;
		} else if(isCastle){ // 相手のボスの検知範囲に触れた場合
			motionRun = true;
			motionAttack = false;
			transform.LookAt (castlePos);
			transform.position =  Vector3.MoveTowards (transform.position, castlePos, step);
//			agent.destination = castlePos;
		}

		// モーション
		GetComponent<Animator>().SetBool("run",motionRun); // 走る
		GetComponent<Animator>().SetBool("idle",motionIdle); // 待機
		GetComponent<Animator>().SetBool("walk",motionWalk); // 歩く
		GetComponent<Animator>().SetBool("attack",motionAttack); // 攻撃
	}

	// 相手の範囲（検知とあたり判定）と自分の範囲が重なった時の判定
	void OnTriggerEnter(Collider other) {
		// 相手のあたり判定に入る
//		if((isEnemy || isCastle) && other.gameObject.tag == "Enemyphy"){
//			isEnemy = false;
//			isCastle = false;
//			isAttack = true;
//			agent.stoppingDistance = 1;
//			motionAttack = true;
//			lifeP = other.GetComponent<Status> ();
//
//			StartCoroutine(attackTime());
//		}

		// 相手を検知
		if (other.gameObject.tag == "Enemy") { // 相手のコマが攻撃範囲内
			targetPos = other.transform.position;
			isEnemy = true;
			Debug.Log ("enemyを発見しました");
		} else if(other.gameObject.tag == "EnemyCastle"){ // 相手のボスが攻撃範囲内
			castlePos = other.transform.position;
			isCastle = true;
			Debug.Log ("bossを発見しました");
		}


	}

	void Damage(Attack.AttackInfo attackinfo){
		isEnemy = false;
		isCastle = false;
		Debug.Log (attackinfo);
		isAttack = true;
		status.life -= attackinfo.attackPower;
	}

	IEnumerator attackTime(){
		while (true) {
			if(lifeP.getHitPoint() > 0){
				lifeP.setHitPoint (lifeP.getHitPoint () - attackPoint);
			}
			yield return new WaitForSeconds (attackInterval); // 待つ
		}
	}
}
