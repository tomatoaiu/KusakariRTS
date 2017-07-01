/*

今現在選択中のユニットを管理するクラス

*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CurrentNameManage : MonoBehaviour {

	public string CurrentUnitName{ get; set;} // 選択中のユニット名前
	public bool ModeBorn{ get; set;} // ユニットを生成するかどうか
	public GameObject Unit {get; set;} // 選択中ユニット
	GameObject[,] existUnits; // ユニットの配列

	public int maxUnitCount = 10; // 最大のユニット数

	public int currentUnitNumber{ get; set;} // 今選択しているUI番目

	public int maxUnitUiTable; // uiにせっとされているユニット種類数

	public int[] maxUnitBornCount; // uiにせっとされているそれぞれのユニット出撃数

	int[] unitCount; // ユニットそれぞれの生成数を保存  現在のユニットの個数


	UnityEngine.AI.NavMeshAgent agent;
	public Text text; // Born or Moveを表示する

	float rayDistance = 200; // 飛ばす&表示するRayの長さ
	float rayDuration = 3;   // 表示期間（秒）

	void Start(){
		ModeBorn = false; // 初期か移動からできるようにする
		Unit = null;

		initUnit ();
	}

	void Update () {
		
		if(Unit != null){
			if (Input.GetMouseButtonDown(0)) {
				ManipulationUnit (); // ユニットの操作
			}
		}
		ChangeOfBornAndMove (); // 生成とムーブの切り替え
	}

	void initUnit(){
		existUnits = new GameObject[maxUnitUiTable, maxUnitCount]; // ユニットの数分の配列を確保

		unitCount = new int[maxUnitUiTable]; // 
		for(int i = 0; i < maxUnitUiTable; i++){
			unitCount [i] = 0;
		}
	}

	// ユニットを操作
	void ManipulationUnit(){

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); // レイは原点 ( origin ) から、設定した方向に向けて光線 ( direction ) を無限に飛ばす スクリーンの点を通してカメラからレイを通す。
		RaycastHit hit; // レイを飛ばした際に、衝突したオブジェクトの情報を得る

		if (Physics.Raycast (ray, out hit, 200f)) {
			Debug.DrawRay (ray.origin, ray.direction * rayDistance, Color.red, rayDuration, false);

			if(!EventSystem.current.IsPointerOverGameObject()) // Check if the mouse was clicked over a UI element UIをクリックしていない場合
			{
				// 生成モードかどうか
				if(ModeBorn){ // 生成
					GeneratingUnit (hit);
				}else{ // 動かす
					MoveUnit(hit);
				}
			} else if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
				
				// 生成モードかどうか
				if(ModeBorn){ // 生成
					GeneratingUnit (hit);
				}else{ // 動かす
					MoveUnit(hit);
				}
			}
		}
	}

	// ユニットをクリックした場所に動かす
	void MoveUnit(RaycastHit hit){

		for(int i = 0; i < maxUnitBornCount[currentUnitNumber]; i++){
			var unit = existUnits [currentUnitNumber, i];
			if (unit != null) { // ユニットがnullなことがあるため
				agent = unit.GetComponent<UnityEngine.AI.NavMeshAgent> ();
				agent.SetDestination (hit.point);
			}
		}


	}

	// ユニットをクリックした場所に生成
	void GeneratingUnit(RaycastHit hit){
		
		if(unitCount[currentUnitNumber] < maxUnitBornCount[currentUnitNumber]){
			Debug.Log (hit.point);
			Vector3 bornPosition = hit.point;
			bornPosition.y = 0.5f;
			existUnits [currentUnitNumber, unitCount[currentUnitNumber]] = Instantiate (Unit, bornPosition, transform.rotation) as GameObject;
			unitCount[currentUnitNumber]++;
		}
	}

	// 生成とムーブの切り替え
	void ChangeOfBornAndMove(){
		if (Input.GetKeyUp(KeyCode.Space)) {
			ModeBorn = !ModeBorn;

			if (ModeBorn) {
				text.text = "Born";
			} else {
				text.text = "Move";
			}

		}
	}
}
