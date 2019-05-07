using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class languageController : MonoBehaviour {
	
	public static languageController linstance;
	static string languageName;
	private void Awake()
	{
		linstance = this;
	}

	public void getButton()
	{
		languageName = EventSystem.current.currentSelectedGameObject.name;
		OutputCodeController.instance.UpdateProgramCode();

	}

	public string returnLanguage()
	{
		return (languageName);
	}
}
