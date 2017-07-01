using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HitPoint : MonoBehaviour {

	public int hitPoint;

	public GameObject chara;

	private int desCount;


	// Use this for initialization
	void Start () {
		desCount = 0;
	}

	public void setHitPoint(int hitPoint){
		this.hitPoint = hitPoint;
	}

	public int getHitPoint(){
		return this.hitPoint;
	}



	// Update is called once per frame
	void Update () {
		
		if (desCount == 0 && isLose ()) {
			if (this.gameObject.name == "Weed(Clone)" || this.gameObject.name == "Boss") {
				Count.weedCnt++;
			} else {
				Count.soldierCnt++;
			}


//			Debug.Log (this.gameObject.name);
//
//			Debug.Log ("weed "+Count.weedCnt);
//			Debug.Log ("soldier "+Count.soldierCnt);

			if(this.gameObject.name == "Boss"){ // ボスを倒したら結果の画面に
				SceneManager.LoadScene ("Result");
			}

			Destroy (chara);
			desCount++;

		}
	}

	public bool isLose(){
		
		if (hitPoint <= 0) {
			return true;
		} else {
			
			return false;
		}
	}
}
