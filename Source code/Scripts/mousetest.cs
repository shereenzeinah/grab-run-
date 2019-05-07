using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mousetest : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler {


public bool isOver = false;


public void OnPointerEnter(PointerEventData eventData)
{
	Debug.Log("Mouse enter");

	isOver = true;




		if (isOver == true ) {
			
			destroy ();
		}


}
public void OnPointerExit(PointerEventData eventData)
	{   

	
}
	public void destroy(){
		droppable d = new droppable ();
		droppable.returnobject ();



	}
}

	
