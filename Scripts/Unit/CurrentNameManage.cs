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


	RaycastHit hit; // 衝突したオブジェクトを取得 レイを飛ばした際に、衝突したオブジェクトの情報を得る

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

	/// <summary>
	/// ユニットの操作
	/// raycastを行いユニットを動かすか生成するか決める
	/// </summary>
	void ManipulationUnit(){

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); // レイは原点 ( origin ) から、設定した方向に向けて光線 ( direction ) を無限に飛ばす スクリーンの点を通してカメラからレイを通す

		if(GetCollisionTerrain(ray)){ // 画面からrayを打って地面に当たったら地面をhitに格納、当たらなかったら何もしない
			if(!EventSystem.current.IsPointerOverGameObject()) // Check if the mouse was clicked over a UI element UIをクリックしていない場合
			{
				DoMoveOrBorn (hit); // 動かすか生成をする
			} else if (Input.touchCount > 0 
						&& EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) { // UIをタップしていない場合
				DoMoveOrBorn (hit);
			}
		}
	}

	/// <summary>
	/// 生成するか動かすか判定し実行
	/// </summary>
	/// <param name="h">The height.</param>
	void DoMoveOrBorn(RaycastHit h){
		// 生成モードかどうか
		if(ModeBorn){ // 生成
			GeneratingUnit (h);
		}else{ // 動かす
			MoveUnit(h);
		}
	}

	// 画面から光線を打って地面にヒットしたらtureを返し、hitに格納
	bool GetCollisionTerrain(Ray ray){
		RaycastHit[] hits  = Physics.RaycastAll(ray, 200f);
		foreach(var h in hits){
			if (h.collider.tag == "Terrain") {
				hit = h;
				return true;
			} else {
				
			}
		}
		return false; // 地面に当たらなかった
	}

	// ユニットをクリックした場所に動かす
	void MoveUnit(RaycastHit h){

		for(int i = 0; i < maxUnitBornCount[currentUnitNumber]; i++){
			var unit = existUnits [currentUnitNumber, i];
			if (unit != null) { // ユニットがnullなことがあるため
				agent = unit.GetComponent<UnityEngine.AI.NavMeshAgent> ();
				agent.SetDestination (h.point);
			}
		}

		Debug.Log (198746);
	}

	/// <summary>
	/// ユニットをクリックした場所に生成
	/// </summary>
	/// <param name="h">RaycastHitのposition</param>
	void GeneratingUnit(RaycastHit h){
		
		if(unitCount[currentUnitNumber] < maxUnitBornCount[currentUnitNumber]){
//			Debug.Log (hit.point);
			Vector3 bornPosition = h.point;
			bornPosition.y = 0.5f;
			GameObject createUnit = Instantiate (Unit, bornPosition, transform.rotation) as GameObject; // 選択したユニットを複製
			existUnits [currentUnitNumber, unitCount[currentUnitNumber]] = createUnit;
			unitCount[currentUnitNumber]++;

//			string name = createUnit.GetComponent<Unit> ().unitName + unitCount[currentUnitNumber];
//			createUnit.GetComponent<Unit> ().unitName = name;
//			Debug.Log (name);
//			Debug.Log ("GeneratingUnit");

		}
	}

	// 生成とムーブの切り替え
	void ChangeOfBornAndMove(){
		
		if (Input.GetKeyUp(KeyCode.Space)) {
			ModeBorn = !ModeBorn;
			if (ModeBorn) {
				text.text = "Born"; // 右上の文字
			} else {
				text.text = "Move";
			}

		}
	}
}
