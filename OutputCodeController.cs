using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Text;

public class OutputCodeController : MonoBehaviour
{

    public static OutputCodeController instance;

    public Transform dropPannel;
    public Text outputCodeText;
    string variable = "";
    string myCode;
    //public string variable="";

	void Start()
	{
		UpdateProgramCode ();	
	}
    private void Awake()
    {
        instance = this;
    }
   
	public string returnCode()
	{
		return myCode;
	}
	 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            UpdateProgramCode();
    }


    public void UpdateProgramCode()
    {
        string code = "";

        for (int i = 0; i < dropPannel.childCount; i++)
        {
            Block block = dropPannel.GetChild(i).GetComponent<Block>();
            // Debug.Log(block.name);
			block.indentLevel=1;
			if (i < dropPannel.childCount - 1) {
				code += "\n";
			}
            code += block.GetObjectCode() + "\n";
        }

        ShowProgramCode(code);
    }

    public void updatevariable()
    {
        variable = "";
        for (int i = 0; i < dropPannel.childCount; i++)
        {
            Block block = dropPannel.GetChild(i).GetComponent<Block>();
			if (block.returntype() == 1 && block.ReturnCopied()==0)
            {
                variable += block.Getvardeclaration() + "\n";
               
            }
        }


    }

	void ShowProgramCode(string code)
	{	
		string language=languageController.linstance.returnLanguage ();
		if(language=="Java")
			{
		myCode = "public static void main(String [] args){\n" + variable + "\n" + code + "\n}";

			outputCodeText.text = myCode;
			}
			else{
			myCode = "def main():\n\t"+ code + "\n";

			outputCodeText.text = "def main():\n\t" + code + "\n";

				
			}
    }
}