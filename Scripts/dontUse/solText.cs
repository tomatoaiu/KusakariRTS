using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class solText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.GetComponent<Text>().text = "疲れた兵士 : " + Count.soldierCnt + "人";
	}
}
