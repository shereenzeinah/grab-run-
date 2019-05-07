using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forBlock : Block


{
	Transform dropPanel;
	string numOfIterations;
	string code;
	public string language;

	void Start() {
		dropPanel = GetComponentInChildren<ExpandableDropZone> ().transform;

	}
   
    public override int returntype()
    {
        return 1;
    }
	public override string Getvardeclaration()

	{	
		string variable = "";
		for (int i = 0; i < dropPanel.childCount; i++) {

			Block block = dropPanel.GetChild(i).GetComponent<Block>();
			block.indentLevel = indentLevel + 1;

			variable += Block.GetIndentForLevel (block.indentLevel) + block.Getvardeclaration ();


			if (i < dropPanel.childCount - 1) {
				variable += "\n";
			}
		}
		print (variable);
		return (variable);
	}

    public override string GetObjectCode()
	{	string body = "";
		
		language = languageController.linstance.returnLanguage();

        if (language == "python")
        {
			for (int i = 0; i < dropPanel.childCount; i++) {
				
				Block block = dropPanel.GetChild(i).GetComponent<Block>();
				block.indentLevel = indentLevel + 1;

				body += Block.GetIndentForLevel (block.indentLevel) + block.GetObjectCode ();

				print (body);

				if (i < dropPanel.childCount - 1) {
					body += "\n";
				}
			}
            code = "for i in range " + numOfIterations + ":\n\t" +
           "\n" + body + "\n";
        }

        else if (language == "Java")

        {
			for (int i = 0; i < dropPanel.childCount; i++) {
				Block block = dropPanel.GetChild(i).GetComponent<Block>();
				block.indentLevel = indentLevel + 1;

				body += Block.GetIndentForLevel (block.indentLevel) + block.GetObjectCode ();

				if (i < dropPanel.childCount - 1) {
					body += "\n";
				}
			}
            code = "for( int i=0;i<" + numOfIterations + ";i++)" + "\n\t" +
         "{\n" + body + "\n}" + ";";
        }
        
        numOfIterations = GetComponentInChildren<InputField>().text;


        return (code);
    }
}
