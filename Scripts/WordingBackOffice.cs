using System;
using System.Collections;
using System.Collections.Generic;

public class WordingBackOffice
{
	public static IList<string[]> texts;
	public static IList<string[]> errors;

	public static string getText(int idReference, int languageID){
		return texts[idReference][languageID];
	}

	public static string getErrorText(int idReference, int languageID){
		return errors[idReference][languageID];
	}

	public static string getText(int idReference, List<int> args, int languageID){
		string text = texts[idReference][languageID];
		for(int i = 0;i<args.Count;i++){
			text = text.Replace("ARG"+(i+1),""+args[i]);
		}
		return text;
	}

	static WordingBackOffice ()
	{
		texts = new List<string[]>();
		//Enlever 30 au numéro de ligne pour obtenir l'index
		texts.Add(new String[]{"Enregistrez-vous à bord","Please check-in to get onboard"});
		texts.Add(new String[]{"Votre login ou mail","Your login or email"});
		texts.Add(new String[]{"Votre mot de passe","Your password"});
		texts.Add(new String[]{"Se souvenir de moi","Remember me"});
		texts.Add(new String[]{"Monter à bord","Get onboard"});
		texts.Add(new String[]{"nivARG1","levARG1"});
		texts.Add(new String[]{"niveau","level"});
		texts.Add(new String[]{"Choisissez la compétence à améliorer ou à découvrir!","You can choose the skill you want to improve!"});
		texts.Add(new String[]{"Retour","Back"});
		texts.Add(new String[]{"Vitalité","Health"});
		texts.Add(new String[]{"Rapidité","Speed"});
		texts.Add(new String[]{"Compétence active","Active skill"});
		texts.Add(new String[]{"Compétence passive","Passive skill"});
		texts.Add(new String[]{"cases/tour","tiles/turn"});
		texts.Add(new String[]{"case/tour","tile/turn"});
		texts.Add(new String[]{"PV","HP"});

		errors = new List<string[]>();
		//0
		errors.Add(new String[]{"Problème de récupération de données, veuillez réessayer plus tard","Data collection problem. Please try again later"});

	}
}