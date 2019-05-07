using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BuzzerBlock : Block
{
    string variable;
    string code;
    public string Name;
    public string language;
	int blockNum;
	int copied=0;
	public Transform dropPanel;

	public void setBlockNumber (int blockNumber)
	{
		this.blockNum = blockNumber;
	}

	public override int ReturnCopied()
	{
		return copied;
	}

	public override string Getvardeclaration()
	{	
		variable = "int Buzzer"+blockNum+ ";\n";
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
            if (Name == "ButtonON")
            {
				code = "Buzzer"+blockNum+"=1";

            }
            else if (Name == "ButtonOFF")

            {
				code = "Buzzer"+blockNum+"=0";

            }

        }
	
        else if (language == "Java")

        {
			if (Name == "ButtonON")
			{
				code = "Buzzer"+blockNum+"=1";

			}
			else if (Name == "ButtonOFF")

			{
				code = "Buzzer"+blockNum+"=0";

			}

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

}