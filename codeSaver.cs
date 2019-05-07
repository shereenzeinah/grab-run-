using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Text;

public class codeSaver : MonoBehaviour {
	static string fileName;
	public string myCode;
	public static OutputCodeController instance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void getFileName()
	{	
		fileName = GetComponentInChildren<InputField>().text;
		print (fileName);
	}
	public void getCode()
	{
		myCode = OutputCodeController.instance.returnCode ();
		saveCode();
	}

	public void saveCode()
	{
		StreamWriter sr = new StreamWriter("D:\\Grab&Run\\" + fileName+ ".txt");
		sr.Write(myCode);
		sr.Close();

	}

}
