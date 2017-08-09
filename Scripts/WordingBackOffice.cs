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
		//0
		texts.Add(new String[]{"Enregistrez-vous à bord","Please check-in to get onboard"});
		texts.Add(new String[]{"Votre login ou mail","Your login or email"});
		texts.Add(new String[]{"Votre mot de passe","Your password"});
		texts.Add(new String[]{"Se souvenir de moi","Remember me"});
		texts.Add(new String[]{"Monter à bord","Get onboard"});
		texts.Add(new String[]{"nivARG1","levARG1"});

		errors = new List<string[]>();
		//0
		errors.Add(new String[]{"Problème de récupération de données, veuillez réessayer plus tard","Data collection problem. Please try again later"});

	}
}