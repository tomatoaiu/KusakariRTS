using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Status : MonoBehaviour {

	public float life = 100f; //  体力現在値
	public float maxLife = 100f; // 体力最大値

	public float power = 10f; // 攻撃力
	public float attackInterval = 3f; // 攻撃間隔

	public GameObject lastAttackTarget = null; // 最後に攻撃した対象

	public string characterName = "Soldier";

	// 状態
	public bool attacking = false;
	public bool died = false;

	public Slider meterPrefab; // ライフメーター
	public Vector2 offset; // オフセット

	Slider meter; // スライダー

	void Start () {
		meter = Instantiate (meterPrefab) as Slider;
		// 親からの相対的な位置、回転、スケールが変更するが、ワールド空間としての位置、回転、スケールは維持。ローカルを保ちたかったらfalse
		meter.transform.SetParent (GameObject.Find ("Canvas").transform);
	}

	void Update () {
		// ワールド空間のpositionをスクリーン空間に変換 + オフセットを考慮
		meter.transform.position = Camera.main.WorldToScreenPoint (transform.position) + new Vector3 (offset.x, offset.y);
		meter.value = life / maxLife; // 割合に変換

		// 体力が0になったら削除
		if (meter.value == 0) {
			Destroy (gameObject);
		}

	}

	public void setHitPoint(float life){
		this.life = life;
	}
	public float getHitPoint(){
		return this.life;
	}

	public bool isLose(){

		if (life <= 0) {
			return true;
		} else {
			return false;
		}
	}
}
