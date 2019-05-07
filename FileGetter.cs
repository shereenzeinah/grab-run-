using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Text;



public class FileGetter : MonoBehaviour {
	public Text fileNames;
	public string fileName;
	// Use this for initialization
	void Start () {
		string [] files=Directory.GetFiles("D:\\Grab&Run");
		foreach (string file in files) {
			//newButton.name = Path.GetFileName (file);
			fileNames.text += Path.GetFileName (file) + "\n";
	}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void getFileName()
	{
		fileName = GetComponentInChildren<InputField>().text;
		System.Diagnostics.Process.Start ("explorer.exe","D:\\Grab&Run\\"+fileName);
	}
	
}
