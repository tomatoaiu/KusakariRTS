/*

canvasの子要素buttonクリック
ユニットを生み出すか、移動させるか

*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ClickButtonSender : MonoBehaviour {

	public string UnitName{ get; set;} // ユニットの名前
	public GameObject targetUnit; // このUIに対応しているユニット

	public int MaxCount{ get; set;}
	public int UnitCount{ get; set;}

	public int unitNumber;

	public string targetName; // このボタンに対応しているユニットの名前

	CurrentNameManage currentNameManage; // 現在なにが選択されているか管理するクラス

	Text text;

	void Start () {
		UnitName = targetName;
		text = GetComponentInChildren<Text> ();
		currentNameManage = transform.parent.Find("CurrentNameManager").GetComponent<CurrentNameManage>(); // CurrentNameManagerオブジェクトからCurrentNameManageクラスをもってくる
		MaxCount = 10;
		UnitCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentNameManage.CurrentUnitName == targetName) { // 今選択中なら
			text.text = "selecting";
		} else {
			text.text = "";
		}
	}

	// ユニットの画像がクリックされたとき
	public void Selected() {

		currentNameManage.CurrentUnitName = UnitName; // このユニットの名前を現在選択中の名前に変更
		currentNameManage.Unit = targetUnit; // このユニットを選択中にする
		currentNameManage.currentUnitNumber = unitNumber;
	}


}
