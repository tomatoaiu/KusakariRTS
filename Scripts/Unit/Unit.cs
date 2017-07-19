/*

unitの元　スーパークラス
unitのステータス決定

*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;


public class Unit : MonoBehaviour {

	/// <summary>
	/// ユニット名
	/// </summary>
	public string unitName;
	/// <summary>
	/// ユニットの攻撃力
	/// </summary>
	public int attackPoint;
	/// <summary>
	/// ユニットスピード
	/// </summary>
	public float unitSpeed;
	/// <summary>
	/// 体力の現在値
	/// </summary>
	public float life = 100f;
	/// <summary>
	///  体力最大値
	/// </summary>
	public float maxLife = 100f;
	/// <summary>
	/// 攻撃間隔
	/// </summary>
	public float attackInterval;

	/// <summary>
	/// 現在のユニット数
	/// </summary>
	protected static int unitCount;

	/// <summary>
	/// ライフメーター
	/// </summary>
	public Slider meterPrefab;
	/// <summary>
	/// ライフメーターのオフセット
	/// </summary>
	public Vector2 offset;
	/// <summary>
	/// スライダー
	/// </summary>
	Slider meter;

	/// <summary>
	/// 攻撃中か?
	/// </summary>
	protected bool isDuringAttack;

	/// <summary>
	/// 同一オブジェクトにあるNavMeshAgetnt
	/// </summary>
	protected NavMeshAgent agent;
	/// <summary>
	/// コライダーで取得したボスオブジェクト
	/// </summary>
	protected GameObject enemyBoss;
	/// <summary>
	/// コライダーで取得した敵ユニット
	/// </summary>
	protected GameObject enemyUnit;
	/// <summary>
	/// Gets or sets 接触している敵
	/// </summary>
	/// <value>The target enemy unit.</value>
	public GameObject TargetEnemyUnit{ get; set;}
	/// <summary>
	/// Gets or sets 敵に接触している
	/// </summary>
	/// <value><c>true</c> if in enemy hit area; otherwise, <c>false</c>.</value>
	public bool inEnemyHitArea{ get; set;} // 敵に接触している

	/// <summary>
	/// 今戦っているユニット
	/// </summary>
	Unit unit;

	protected List<Collider> targets = new List<Collider>(); // 見つけた敵リスト

	protected float sphereColliderRadius; //探知範囲


	protected void Start () {
		UnitInit ();
	}

	protected void Update () {
		UnitSet ();
	}

	/// <summary>
	/// ユニットのステータスをセット
	/// </summary>
	protected virtual void SetUpUnitStatus(){
		unitName = "unko";
		attackPoint = 0;
		unitSpeed = 0;
		life = 100f;
		maxLife = 100f;
		attackInterval = 4f;
		sphereColliderRadius = 15f;
	}
		
	/// <summary>
	/// ライフメータを作成
	/// </summary>
	protected void MeterCreate(){
		meter = Instantiate (meterPrefab) as Slider;
		// 親からの相対的な位置、回転、スケールが変更するが、ワールド空間としての位置、回転、スケールは維持。ローカルを保ちたかったらfalse
		meter.transform.SetParent (GameObject.Find ("Canvas").transform);
	}

	/// <summary>
	/// ライフメータのアップデート
	/// </summary>
	protected void MeterUpdate(){
		// ワールド空間のpositionをスクリーン空間に変換 + オフセットを考慮
		meter.transform.position = Camera.main.WorldToScreenPoint (transform.position) + new Vector3 (offset.x, offset.y);
		meter.value = life / maxLife; // 割合に変換

		// 体力が0になったら削除
		if (meter.value == 0) {
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// ユニットの初期化
	/// agentの取得
	/// 敵と接触しているかをfalse
	/// 攻撃中にfalse
	/// ユニットのステータスを初期化
	/// agentにユニットのスピードを代入
	/// targtsリストのクリア
	/// </summary>
	protected void UnitInit(){
		agent = GetComponent<NavMeshAgent>();
		inEnemyHitArea = false;
		isDuringAttack = false;
		MeterCreate ();
		SetUpUnitStatus (); // ユニットステータスの初期化
		agent.speed = unitSpeed;
		targets.Clear ();
	}
		
	/// <summary>
	/// ユニットの毎フレーム行う処理
	/// ライフメータの反映
	/// 自分と相手が戦える距離に入っているかを確認
	/// </summary>
	protected void UnitSet(){
//		agent.speed = unitSpeed;
		MeterUpdate();
		if (inEnemyHitArea) { // 自分と相手が戦える距離に入る
//			Debug.Log(12476);
			StartAttacking ();
		}
	}
		
	/// <summary>(void)
	/// 攻撃開始
	/// 接触している敵から情報を取得
	/// ユニットのスピードを０に
	/// </summary>
	protected void StartAttacking(){
		inEnemyHitArea = false;
		unit = TargetEnemyUnit.GetComponent<Unit>();

		agent.speed = 0; // 攻撃中は停止
//		Debug.Log (agent.speed);
		StartCoroutine(attackTime()); // 攻撃中
	}

	/// <summary>
	/// 攻撃中
	/// </summary>
	/// <returns>The time.</returns>
	IEnumerator attackTime(){
//		Debug.Log("attackTime" + unit);
		isDuringAttack = true; // 攻撃中にする
		while (true) {

			if (unit != null && unit.life > 0) {
				unit.life -= attackPoint;
			} else {
				agent.speed = unitSpeed;
				//				agent.SetDestination (enemyBoss.transform.position);
				break;
			}
			yield return new WaitForSeconds (attackInterval); // 待つ
		}
		isDuringAttack = false;
	}


	/************************************** AI *****************************/

	/// <summary>
	/// 一番最初に見つけた敵を攻撃するAI
	/// </summary>
	protected void AIAttackFirstTarget(){
		if (!hasErrorTragetsList ()) {
			GetFirstTarget ();
		}
	}

	/// <summary>
	/// AIs the attack nearest target.
	/// 一番近い敵を攻撃するAI
	/// </summary>
	protected void AIAttackNearestTarget(){
		if (!hasErrorTragetsList ()) {
			TargetEnemyUnit = GetNearestTarget ().gameObject;
		}
	}

	/// <summary>
	/// ターゲットリストにある一番近いターゲットを取得
	/// </summary>
	/// <returns>オブジェクト</returns>
	protected Collider GetNearestTarget(){
		Collider obj  = targets[0];
		float nearPosition;
		float nearestPosition = 9999f;
		if (targets.Count == 1) { // ターゲットリスト内に１ユニットしかいなかったら
			return obj;
		} else {
			foreach(var target in targets){
				// 接触した相手と自分の距離の取得
				nearPosition = (target.transform.position - gameObject.transform.position).sqrMagnitude; 
				Debug.Log (nearPosition);
				// 距離が０か、より距離が近い場合
				if (nearPosition == 0 || (nearestPosition * nearestPosition) > nearPosition) {
					nearestPosition = nearPosition;
					obj = target;
				}
			}
			return obj;
		}
	}

	/// <summary>
	/// ターゲットリストから順番（接敵順）に取得
	/// </summary>
	/// <returns>The first target.</returns>
	protected void GetFirstTarget(){
		foreach(Collider target in targets){
			if (target is Collider) { // 取得したターゲットが生きている（デストロイされていない場合）
				TargetEnemyUnit = target.gameObject; // targets [0]; // ターゲットリストの中から一番目を取得
			} else {
				continue;
			}
		}
	}

	/***************** TargetsListのエラーチェック ***********************/


	/// <summary>
	/// ターゲットリストに何もないか判定
	/// </summary>
	/// <returns><c>true</c>, if targets count zero was ised, <c>false</c> otherwise.</returns>
	protected bool isTargetsCountZero(){
		if (targets.Count == 0) {
			return true;
		} else {
			return false;
		}
	}

	/// <summary>
	/// ターゲットリストのサイズが０だったらtrue
	/// リストにnullが含まれていたらtrueとリストから除外
	/// </summary>
	/// <returns><c>true</c>, if error tragets list was hased, <c>false</c> otherwise.</returns>
	protected bool hasErrorTragetsList(){
		
		if (isTargetsCountZero()) {
			return true;
		}

		TargetsNullCheck ();
		return false;
	}

	/// <summary>
	/// ターゲットリストのnull判定
	/// </summary>
	protected void TargetsNullCheck(){
		//		targets.RemoveAll(null);
//		int cnt = 0;
//		foreach(Collider target in targets){
//			Debug.Log ("target : " + target);
//			if(target.gameObject.GetComponent<Unit>().life <= 0){
////				targets.RemoveAt (cnt);
//			}
//			cnt++;
//		}
		targets.RemoveAll(target => target == null); // ターゲットリストからnullを除外
	}

}
