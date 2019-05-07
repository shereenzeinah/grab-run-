using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandableDropZone : droppable {

	float emptyHeight = 37;
	float minimumHeight = 30;
	float spacing = -4;
	Transform parent;

	public override void OnDrop (UnityEngine.EventSystems.PointerEventData eventData) {
		if (GetComponentInParent<DraggableBlocksController> () == null) {
			base.OnDrop (eventData);
		}
	}

	public override void UpdateContentSize () {
		parent = gameObject.transform.parent.parent.parent.parent;

		RectTransform blockRectTransform = GetComponentInParent<Block> ().GetComponent<RectTransform> ();

		float preferredHeight = minimumHeight;
		if (transform.childCount == 0) {
			preferredHeight = emptyHeight;
		} else {
			for (int i = 0; i < transform.childCount; i++) {
				RectTransform childRectTransform = transform.GetChild(i).GetComponent<RectTransform>();
				preferredHeight += childRectTransform.sizeDelta.y + spacing;
			}
		}
		if (parent.name!="Draggable Content")
		{
		blockRectTransform.sizeDelta = new Vector2 (blockRectTransform.sizeDelta.x, preferredHeight);
		}

		droppable[] parentDropZones = GetComponentsInParent<droppable> ();
		foreach (droppable parentDropZone in parentDropZones) {
			if (parentDropZone != this as droppable) {
				parentDropZone.UpdateContentSize ();
			}
		}
	}
}
