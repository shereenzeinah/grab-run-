using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Block : MonoBehaviour

{

	public int indentLevel = 1;
	public virtual int ReturnCopied()
	{
		return(0);
	}


    public virtual int returntype()
    {

        
        return (0);
    }


    public virtual string Getvardeclaration()
    {


        return (null);
    }

    public virtual string GetObjectCode()
    {


        return (null);
    }
	public static string GetIndentForLevel(int level) {
		string indent = "";
		for (int j = 0; j < level; j++) {
			indent += "\t";
		}

		return indent;
	}


    /* public virtual string GetObjectCodeP()
     {


         return (null);
     }

     public virtual string GetObjectCodeJ()
     {


         return (null);
     }*/


}
