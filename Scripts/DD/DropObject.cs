﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropObject : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image iconImage;
	private Sprite nowSprite;

	public GameObject coreMemberManager;

	void Start()
	{
		nowSprite = null;
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
//		if(pointerEventData.pointerDrag == null) return;
//		Image droppedImage = pointerEventData.pointerDrag.GetComponent<Image>();
//		iconImage.sprite = droppedImage.sprite;
//		iconImage.color = Vector4.one * 0.6f;
//		Debug.Log ("OnPointerEnter");
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
//		if(pointerEventData.pointerDrag == null) return;
//		iconImage.sprite = nowSprite;
//		if(nowSprite == null)
//			iconImage.color = Vector4.zero;
//		else
//			iconImage.color = Vector4.one;
//
//		Debug.Log ("OnPointerExit");

	}
	public void OnDrop(PointerEventData pointerEventData)
	{
		Image droppedImage = pointerEventData.pointerDrag.GetComponent<Image>();
		iconImage.sprite = droppedImage.sprite;
		nowSprite = droppedImage.sprite;
		iconImage.color = Vector4.one;

		Debug.Log (pointerEventData.pointerDrag.name);

//		coreMemberManager.GetComponent<CoreMemberRegistration> ().coreMember [int.Parse(gameObject.name)];
	}
}