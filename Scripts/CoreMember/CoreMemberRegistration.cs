using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreMemberRegistration : MonoBehaviour {
	
	public int maxCoreMember; // 最大コアメンバー数

	public GameObject dropUnit; // ドロップされるユニット
	public GameObject unitArea; // DropUnitの親　uiのパネル

	public GameObject[] coreMember; // コアメンバー

	// Use this for initialization
	void Start () {
		CreateDropUnit (); // パネルにドロップできる画像を配置
		coreMember = new GameObject[maxCoreMember];
	}

	
	// Update is called once per frame
	void Update () {
		
	}


	void CreateDropUnit(){
		RectTransform content = unitArea.GetComponent<RectTransform> ();

		for (int i = 0; i < maxCoreMember; i++)
		{
			int number = i;
			GameObject dropUnitButton = (GameObject)Instantiate(dropUnit);
			dropUnitButton.transform.SetParent (content, false);
			dropUnitButton.name = number.ToString();
		}
	}

}
