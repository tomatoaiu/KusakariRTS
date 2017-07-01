using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = "伐採数 : " + Count.weedCnt + "本";
	}
}
