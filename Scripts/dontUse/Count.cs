using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Count : MonoBehaviour {

	public static int soldierCnt;
	public static int weedCnt;

	// Use this for initialization
	void Start () {
		int soliderCnt = 0;
		int weedCnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = "雑草 : " + Count.weedCnt + "本" + "   " + "兵士 : " + Count.soldierCnt + "人";
	}
}
