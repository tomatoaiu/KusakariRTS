/*

unitの元　スーパークラス
unitのステータス決定

*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Unit : MonoBehaviour {

	public int attackPoint; // 攻撃力
	public string unitName; // ユニット名
	public float unitSpeed; // ユニットスピード
	public float life = 100f; //  体力現在値
	public float maxLife = 100f; // 体力最大値
	public float attackInterval; // 攻撃間隔

	protected static int unitCount; // 現在のユニット数

	public Slider meterPrefab; // ライフメーター
	public Vector2 offset; // オフセット
	Slider meter; // スライダー

	public bool isDuringAttack;

	protected UnityEngine.AI.NavMeshAgent agent;
	protected GameObject enemyBoss;
	protected GameObject enemyUnit;
	public GameObject TargetEnemyUnit{ get; set;}
	public bool inEnemyHitArea{ get; set;}


	void Start () {
		
	}

	void Update () {
		
	}

	// ライフメータを作成
	protected void MeterCreate(){
		meter = Instantiate (meterPrefab) as Slider;
		// 親からの相対的な位置、回転、スケールが変更するが、ワールド空間としての位置、回転、スケールは維持。ローカルを保ちたかったらfalse
		meter.transform.SetParent (GameObject.Find ("Canvas").transform);
	}

	// ライフメータのアップデート
	protected void MeterUpdate(){
		// ワールド空間のpositionをスクリーン空間に変換 + オフセットを考慮
		meter.transform.position = Camera.main.WorldToScreenPoint (transform.position) + new Vector3 (offset.x, offset.y);
		meter.value = life / maxLife; // 割合に変換

		// 体力が0になったら削除
		if (meter.value == 0) {
			Destroy (gameObject);
		}
	}
}
