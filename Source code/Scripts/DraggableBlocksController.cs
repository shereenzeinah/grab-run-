using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DraggableBlocksController : MonoBehaviour {
	int blockCount=0;

	public void DuplicateDraggedObject (GameObject draggedObject, int originalSiblingIndex) {
		GameObject duplicateObject = Instantiate(draggedObject, transform) as GameObject;
		blockCount++;
		print (blockCount);
		draggedObject.SendMessageUpwards ("setBlockNumber",blockCount);
		duplicateObject.transform.SetSiblingIndex(originalSiblingIndex);
		duplicateObject.name = draggedObject.name;
	}
}

