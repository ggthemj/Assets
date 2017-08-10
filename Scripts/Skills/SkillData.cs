using System;

public class SkillData
{
	int[] arg1;
	int[] arg2;
	int[] arg3;
	string[] names;
	string[] descriptions;

	public SkillData ()
	{
		this.initValues();
	}

	public virtual void initValues(){
		this.arg1 = new int[5]{1,2,3,4,5};
		this.arg2 = new int[5]{12,14,16,18,20};
		this.arg3 = new int[5]{1,2,3,4,5};
		this.names = new string[2];
		this.names[0] = "ExempleNom";
		this.names[1] = "ExampleName";
		this.descriptions = new string[2];
		this.descriptions[0] = "Descriptif de la compétence avec un niveau de ARG1 et une force de ARG2";
		this.descriptions[1] = "Skill description with level ARG1 and force ARG2";
	}

	public string getDescription(int level, int languageID){
		string text = this.descriptions[languageID];

		text = text.Replace("ARG1",""+arg1[level]);
		text = text.Replace("ARG2",""+arg2[level]);
		text = text.Replace("ARG3",""+arg3[level]);

		return text;
	}

	public string getName(int languageID){
		string text = this.names[languageID];
		return text;
	}

	public int getArg(int level, int argIndex){
		if(argIndex==1){
			return this.arg1[level];
		}
		else if(argIndex==2){
			return this.arg2[level];
		}
		else{
			return this.arg3[level];
		}
	}
}