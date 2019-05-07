using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MotorBlock : Block
{
  //  public static MotorBlock instance;
    public string motorSpeed;
    string code;
    string variable = "";
    public string language;
   // bool found = false;
    //static int type;
	static int counter;
	int blockNum;
	int copied=0;
	public Transform dropPanel;

	public void setBlockNumber (int blockNumber)
	{
		this.blockNum = blockNumber;
	}

    public override int returntype()
    {
        return 1;
    }
    public override string Getvardeclaration()
    
	{        
		variable = "int motor"+blockNum+";\n";
        return (variable);
      
    }


    public override string GetObjectCode()
    {
		language = languageController.linstance.returnLanguage();

        if (language == "python")
        {


            motorSpeed = GetComponentInChildren<InputField>().text;
			code = "motor"+blockNum+"=" + motorSpeed;
        }
        else if (language == "Java")

        {

            motorSpeed = GetComponentInChildren<InputField>().text;
			code = "motor"+blockNum+"=" + motorSpeed + ";";
        }
      
        return (code);
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

	public override int ReturnCopied()
	{
		return copied;
	}
}





