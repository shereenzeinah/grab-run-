using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class draggable : MonoBehaviour ,IBeginDragHandler,IDragHandler ,IEndDragHandler {

    public Transform draggablePanel;
	static int blockCount=0;
	public static draggable linstance;


	 

    
	public Transform originalParent;
	int originalIndex;

   

	public Sprite originalimage;
	public Sprite dropimage;
	public static int x = 0;









	[HideInInspector]
	public Transform parentToReturnTo = null;

	public void OnBeginDrag(PointerEventData eventData)

	{
		
		DraggableBlocksController draggableBlocksController = GetComponentInParent<DraggableBlocksController> ();
		if (draggableBlocksController != null) {
			draggableBlocksController.DuplicateDraggedObject (gameObject, transform.GetSiblingIndex ());

		} 
		else {
			parentToReturnTo = transform.parent;
		}
		Transform originalParent = transform.parent;
		transform.SetParent (GetComponentInParent<Canvas> ().transform);
		GetComponent<CanvasGroup>().blocksRaycasts = false;
		if (this.name == "Loop" || this.name == "If" || this.name == "While"||this.name == "Button"|| this.name == "Mic") {

			dropimage = Resources.Load<Sprite> ("expandedblock");
			gameObject.GetComponent<Image>().sprite = dropimage;
			gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (250,  37);

		} else {

			dropimage =Resources.Load<Sprite>("unexpandedblock");
			gameObject.GetComponent<Image>().sprite = dropimage;
			gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (250,  30);
		}	

		if (originalParent.GetComponent<droppable> () != null) {
			
			OutputCodeController.instance.updatevariable();
			OutputCodeController.instance.UpdateProgramCode ();
			originalParent.GetComponent<droppable> ().UpdateContentSize ();
			print("yesssss");
		}

                                   
	}
	public void OnDrag(PointerEventData eventData)
	{
		this.transform.position=eventData.position;

	}

	public void OnEndDrag(PointerEventData eventData)
	{


		
		if (parentToReturnTo != null) {
			if (parentToReturnTo.name=="Delete") {
				Destroy (gameObject);
			}
			this.transform.SetParent (parentToReturnTo);
			GetComponent<CanvasGroup> ().blocksRaycasts = true;

			for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).gameObject.SetActive (true);
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
			}
			if (this.name == "Input text" && languageController.linstance.returnLanguage () == "Java") {

				transform.GetChild (1).gameObject.SetActive (false);



			} 


			if (GetComponentInParent<droppable> () != null) {
				
				
				OutputCodeController.instance.updatevariable();
				OutputCodeController.instance.UpdateProgramCode ();
				GetComponentInParent<droppable> ().UpdateContentSize ();

		
			}





		} else {
			Destroy (gameObject);
		}

		 

	}




				



	} 



