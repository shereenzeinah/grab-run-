using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class inputText : Block
{
	
	string variable;
	string code;
	public string Name;
	public string language;
	int blockNum;
	int copied=0;
	public Transform dropPanel;
	public string  inputtext;
	public override string Getvardeclaration()
	{    
		variable = "String variable " + blockNum + ";\n";
		return (variable);
	}

	public override int returntype()
	{
		if (language == "python") {

			return 0;
		} 
		else {
			return 1;
		}
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

			inputtext = GetComponentInChildren<InputField>().text;

			code = " variable" + blockNum +"=input(\""+inputtext+"\");";



			print(code);

		}

		else if (language == "Java")

		{



			code ="Scanner scan = new Scanner (system.in);"+"\n"+"variable"+blockNum +"=scan.next();";

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



