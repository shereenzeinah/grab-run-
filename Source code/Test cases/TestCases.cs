using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class checkTest {

	[Test]
	public void checkTestSimplePasses() {

		Prepare preconditions and inputs
		DraggableBlocksController draggableBlocksController = new GameObject().AddComponentDraggableBlocksController();
		GameObject draggedObject = new GameObject().AddComponentBuzzerBlock().gameObject;
		draggedObject.name = DraggedObject Test;
		int originalSiblingIndex = 0;

		Call the method under test
		draggableBlocksController.DuplicateDraggedObject(draggedObject, originalSiblingIndex);

		Assert occurence of the expected result
		GameObject duplicatedObject = draggableBlocksController.transform.GetChild(originalSiblingIndex).gameObject;

		Assert.AreEqual(duplicatedObject.name, draggedObject.name);

	}

	[Test]
	public void checkTestSimpleePasses()
	{
		Prepare preconditions and inputs
		DraggableBlocksController draggableBlocksController = new GameObject().AddComponentDraggableBlocksController();
		GameObject draggedObject = new GameObject().AddComponentBuzzerBlock().gameObject;
		draggedObject.name = DraggedObject Test;
		int originalSiblingIndex = 0;

		Call the method under test
		draggableBlocksController.DuplicateDraggedObject(draggedObject, originalSiblingIndex);

		Assert occurence of the expected result
		GameObject duplicatedObject = draggableBlocksController.transform.GetChild(1).gameObject;

		Assert.AreEqual(duplicatedObject.name, draggedObject.name);
	}


	[Test]
	public void checkmotorparametersPasses()
	{

		Transform draggablepanel = GameObject.FindGameObjectWithTag(Draggable Content).transform;


		for (int i = 0; i  draggablepanel.childCount; i++)
		{
			Block block = draggablepanel.GetChild(i).GetComponentBlock();
			if (block.name == Motor)
			{
				string expected = motor=  + block.GetComponentInChildrenInputField().text;

				block.GetComponentInChildrenInputField().text = this is a motor ;
				string actual = motor=  ;


				Assert.AreEqual(expected, actual);
			}
		}
	}


	[Test]
	public void dublicatePasses()
	{

		Prepare preconditions and inputs
		MotorBlock draggablemotor = new GameObject().AddComponentMotorBlock();
		var draggedObject = new MotorBlock().ReturnCopied();
		int blockNum = 0;


		Call the method under test
		draggablemotor.ReuseBlock();


		expected result
		draggablemotor.SendMessageUpwards(setBlockNumber, blockNum);
		draggablemotor.setCopy(blockNum);
		int duplicatedObject = draggablemotor.ReturnCopied();
		Assert.AreEqual(duplicatedObject, draggedObject);

	}

	[Test]
	public void dublicateePasses()
	{

		Prepare preconditions and inputs
		MotorBlock draggablemotor = new GameObject().AddComponentMotorBlock();
		var draggedObject = new MotorBlock().ReturnCopied();
		int blockNum = 1;


		Call the method under test
		draggablemotor.ReuseBlock();


		expected result
		draggablemotor.SendMessageUpwards(setBlockNumber, blockNum);
		draggablemotor.setCopy(blockNum);
		int duplicatedObject = draggablemotor.ReturnCopied();
		Assert.AreEqual(duplicatedObject, draggedObject);

	}

	[Test]
	public void languageSelector()
	{
		languageController languageControllerObject = new GameObject ().AddComponentlanguageController ();
		languageControllerObject.setLanguageName (java);

		Call the method under test
		string actualLanguage = languageControllerObject.returnLanguage ();

		Assert occurence of the expected result
		string expectedLanguage = java;
		Assert.AreEqual (expectedLanguage,actualLanguage);
	}

	[Test]
	public void languageeSelector()
	{

		languageController languageControllerObject = new GameObject ().AddComponentlanguageController ();
		languageControllerObject.setLanguageName (java);

		Call the method under test
		string actualLanguage = languageControllerObject.returnLanguage ();

		Assert occurence of the expected result
		string expectedLanguage = python;
		Assert.AreEqual (expectedLanguage,actualLanguage);
	}

	[Test]
	public void codeSaver_test(){

		codeSaver fileObject = new GameObject ().AddComponentcodeSaver ();
		fileObject.setFileName(notExist);

		fileObject.saveCode();
		bool fileFound = File.Exists(DGrab&Run+ fileObject.getFileName4test()+ .txt);

		bool fileFound = File.Exists(E + fileObject.getFileName4test()+ .txt);
		StreamWriter sr = new StreamWriter(DGrab&Run + fileName+ .txt);
		Assert.AreEqual(true,fileFound);
	} 

	[UnityTest]
	public IEnumerator checkTestWithEnumeratorPasses() {
		yield return null;
	}
}
