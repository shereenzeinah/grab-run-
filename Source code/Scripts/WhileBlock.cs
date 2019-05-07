using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class WhileBlock : Block
{ Transform dropPanel;

	string code;
	int blockNum;
	int copied=0;
	public string language;
	public string Name;
	public string var ;

	void Start() {
		dropPanel = GetComponentInChildren<ExpandableDropZone> ().transform;

	}

	public override int returntype()
	{
		return 1;
	}
	public override string Getvardeclaration()

	{	
		string variable = "int x =0"+"\n";
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
	public void getButtonClicked()
	{
		Name = EventSystem.current.currentSelectedGameObject.name;
	}
	public override string GetObjectCode()
	{	
		
		string body = "";
		string condition = "";

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
			var = GetComponentInChildren<InputField>().text;
			code = "while i <" +var+":\n"+body+"\n\t\t"+"i+=1";
					
			

		}



		else if (language == "Java"){


			for (int i = 0; i < dropPanel.childCount; i++) {

				Block block = dropPanel.GetChild(i).GetComponent<Block>();
				block.indentLevel = indentLevel + 1;

				body += Block.GetIndentForLevel (block.indentLevel) + block.GetObjectCode ();

				print (body);

				if (i < dropPanel.childCount - 1) {
					body += "\n";
				}
			}
			var = GetComponentInChildren<InputField>().text;
			code = "while (i <" +var+")"+"\n"+"{"+"\n"+body+"\n"+"i++;"+"\n"+"}";



	
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


	public void setBlockNumber (int blockNumber)
	{
		this.blockNum = blockNumber;
	}

	public override int ReturnCopied()
	{
		return copied;
	}






}
