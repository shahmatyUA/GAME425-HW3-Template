﻿// ISTA 425 / INFO 525 Algorithms for Games
//
// Sample code file

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour 
{
	MiniMapEntity linkedMiniMapEntity;
	MiniMapController mmc;
	GameObject owner;
	Camera mapCamera;
	Image spr;
	GameObject panelGO;

	Vector2 screenPos;
	RectTransform sprRect;
	RectTransform rt;

	Transform miniMapTarget;

	void FixedUpdate () 
	{
		if (owner == null)
			Destroy (this.gameObject);
		else
			SetTransform ();
	}

	public void SetMiniMapEntityValues(MiniMapController controller, MiniMapEntity mme, 
									   GameObject attachedGO, Camera renderCamera, GameObject parentPanelGO)
	{
		linkedMiniMapEntity = mme;
		owner = attachedGO;
		mapCamera = renderCamera;
		panelGO = parentPanelGO;
		spr = gameObject.GetComponent<Image> ();
		spr.sprite = mme.icon;
		sprRect = spr.gameObject.GetComponent<RectTransform> ();
		sprRect.sizeDelta = mme.size;
		rt = panelGO.GetComponent<RectTransform> ();
		mmc = controller;
		miniMapTarget = mmc.target;
		SetTransform ();
	}

	// TODO: Implement transformation of registered map icons in MiniMap space
	void SetTransform()
	{
		transform.SetParent (panelGO.transform, false);

		// Some useful variables (see definitions in project and in Unity docs):
        //
		//   sprRect.anchoredPosition
        //   sprRect.rotation
        //   linkedMiniMapEntity.rotateWithObject
        //   mapCamera.WorldToScreenPoint

	}
}
