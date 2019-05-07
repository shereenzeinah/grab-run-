﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class droppable : MonoBehaviour ,IDropHandler {

	public RectTransform referenceRectTransform;
	float minimumWidth=1000;
	public  static GameObject Referencegameobject;
	void Start(){
	
		UpdateContentSize();
	
	}

	public  virtual void OnDrop(PointerEventData eventData)
	{  
		draggable d=eventData.pointerDrag.GetComponent<draggable>();


		if(d!=null)
		{
			d.parentToReturnTo=this.transform;
		}
		Referencegameobject=gameObject;
		
	}
	public virtual void UpdateContentSize(){
		
		RectTransform rectTransform = GetComponent<RectTransform> ();
		Vector2 preferredSize = new Vector2 (0, 0);
		for (int i = 0; i < transform.childCount; i++) {

			RectTransform childRectTransform = transform.GetChild (i).GetComponent<RectTransform> ();
			preferredSize.x = Mathf.Max (new float [] { minimumWidth, preferredSize.x, childRectTransform.rect.size.x });
			preferredSize.y += childRectTransform.rect.size.y;
		}

		//rectTransform.sizeDelta = Vector2.Max (preferredSize, referenceRectTransform.rect.size);
		}
	public  static void  returnobject()
	{
		Destroy (Referencegameobject);
	}
	}





        
