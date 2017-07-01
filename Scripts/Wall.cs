using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// コライダー同士の重なり
	void OnTriggerStay(Collider other){
		// コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
		Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody> ();


		// ボールがどの方向にあるかを計算
		Vector3 direction = transform.position - other.gameObject.transform.position; // ボールの方向の計算
		direction.Normalize ();

		if(other.CompareTag("CameraBall")){

			// 中心点でボールを止めるため速度を減速させる
			rigidbody.velocity *= 0.9f;

			rigidbody.AddForce (direction * rigidbody.mass * 20.0f);


		}
	}
}
