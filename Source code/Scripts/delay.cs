using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class delay : Block
{

	string variable;
	string code;
	public string Name;
	public string language;
	int blockNum;
	int copied=0;
	public Transform dropPanel;
	public string delaytime;
	public override string Getvardeclaration()
	{	
		variable = "";
		return (variable);
	}

	public override int returntype()
	{
		return 1;
	}
	public void getButtonClicked()
	{
		Name = EventSystem.current.currentSelectedGameObject.name;
	}
	public override string GetObjectCode()
	{
		language = languageController.linstance.returnLanguage();
		if (language == "python")
		{

		
			delaytime = GetComponentInChildren<InputField>().text;
			code = "time.sleep(" +delaytime+")";




			print(code);

		}

		else if (language == "Java")

		{

			delaytime = GetComponentInChildren<InputField>().text;
			code = "TimeUnit.SECONDS.sleep(" +delaytime+");";


		}

		return code;

	}
	public void ReuseBlock()
	{	
		GameObject copy = Instantiate(gameObject, dropPanel) as GameObject;
		copy.name = gameObject.name;

		copy.SendMessageUpwards("setBlockNumber",blockNum);
		copy.SendMessageUpwards("setCopy",1);
	}

	public void setCopy(int copy)
	{
		copied = copy;
	}


	public void setBlockNumber (int blockNumber)
	{
		this.blockNum = blockNumber;
	}

	public override int ReturnCopied()
	{
		return copied;
	}




}