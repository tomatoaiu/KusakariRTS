
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour {
	
	[SerializeField]
	GameObject btnPref;  //ボタンプレハブ

	const int BUTTON_COUNT = 10; //ボタン表示数

	ToNextScene toNextScene;

	void Start ()
	{
		//Content取得(ボタンを並べる場所)
		RectTransform content = GameObject.Find("Canvas/ScrollStage/Viewport/Content").GetComponent<RectTransform>();

		//Contentの高さ決定
		//(ボタンの高さ+ボタン同士の間隔)*ボタン数
		float btnSpace = content.GetComponent<HorizontalLayoutGroup>().spacing;
		float btnWidth = btnPref.GetComponent<LayoutElement>().preferredWidth;
		content.sizeDelta = new Vector2(0, (btnWidth + btnSpace) * BUTTON_COUNT);

		for (int i = 0; i < BUTTON_COUNT; i++)
		{
			int no = i;
			//ボタン生成
			GameObject btn = (GameObject)Instantiate(btnPref);
			//ボタンをContentの子に設定
			btn.transform.SetParent(content, false);

			toNextScene = btn.GetComponent<ToNextScene> ();

			toNextScene.scene = "Stage" + (i + 1).ToString();
			btn.transform.GetComponentInChildren<Text>().text = toNextScene.scene;

			//ボタンのテキスト変更
			//btn.transform.GetComponentInChildren<Text>().text = "Btn_"+no.ToString();
			//ボタンのクリックイベント登録
			//btn.transform.GetComponent<Button>().onClick.AddListener(() => OnClick(no));
		}
	}
	public void OnClick(int no)
	{
		Debug.Log(no);
	}
}
