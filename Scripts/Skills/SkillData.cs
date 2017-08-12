using System;

public class SkillData
{
	int[] arg1;
	int[] arg2;
	int[] arg3;
	string[] names;
	string[] descriptions;
	string[] bonus;

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
		this.bonus = new string[2];
		this.bonus[0] = "Ajoute un bonus de ARG1 bonus";
		this.bonus[1] = "Adds a ARG1 bonus to bonus";
	}

	public string getDescription(int level, int languageID){
		string text = this.descriptions[languageID];

		text = text.Replace("ARG1",""+arg1[level-1]);
		text = text.Replace("ARG2",""+arg2[level-1]);
		text = text.Replace("ARG3",""+arg3[level-1]);

		return text;
	}

	public string getBonus(int levelBonus, int languageID){
		string text = this.bonus[languageID];

		text = text.Replace("ARG1",""+levelBonus*(arg1[1]-arg1[0]));
		text = text.Replace("ARG2",""+levelBonus*(arg2[1]-arg2[0]));
		text = text.Replace("ARG3",""+levelBonus*(arg3[1]-arg3[0]));

		return text;
	}

	public string getName(int languageID){
		string text = this.names[languageID];
		return text;
	}
}