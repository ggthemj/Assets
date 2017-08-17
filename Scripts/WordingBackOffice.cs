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
		texts.Add(new String[]{"Ajoute ARG1 points de déplacement","Adds ARG1 move points"});
		texts.Add(new String[]{"Ajoute ARG1 point de déplacement","Adds ARG1 move point"});
		texts.Add(new String[]{"Votre vitesse a déjà été augmentée au maximum!","Your speed has already reached its maximum level!"});
		texts.Add(new String[]{"Ajoute ARG1 points de vie","Adds ARG1 health points"});
		texts.Add(new String[]{"Vos points de vie ont été augmentés au maximum","Your health has already reached its maximum level!"});
		texts.Add(new String[]{"Cette compétence a déjà atteint son niveau maximum","this skill has already reached its maximum level!"});
		texts.Add(new String[]{"Acheter","Buy"});
		texts.Add(new String[]{"Cliquez ici pour débloquer cette compétence active","Click here to unlock this active skill"});
		texts.Add(new String[]{"Cliquez ici pour débloquer cette compétence passive","Click here to unlock this passive skill"});
		texts.Add(new String[]{"Verrouillée","Locked"});
		texts.Add(new String[]{"Mes unités","My units"});
		texts.Add(new String[]{"Clique sur une unité pour voir ou améliorer ses compétences","Click on a character to access to its skills and improve them"});
		texts.Add(new String[]{"Retour","Back"});
		texts.Add(new String[]{"Collection","Collection"});
		texts.Add(new String[]{"Achat effectué","Purchase made"});
		texts.Add(new String[]{"La compétence ARG2 de l'unité ARG1 a été augmentée au niveau ARG3","ARG1's ARG2 skill has been improved to level ARG3"});
		texts.Add(new String[]{"OK!","OK !"});
		texts.Add(new String[]{"L'unité ARG1 possède désormais ARG2 points de vie","ARG1 unit has now ARG2 health points"});
		texts.Add(new String[]{"L'unité ARG1 peut désormais se déplacer de ARG2 cases par tour","ARG1 unit can now move up to ARG2 tiles per turn"});
		texts.Add(new String[]{"move","move"});
		texts.Add(new String[]{"life","life"});
		texts.Add(new String[]{"skill0","skill0"});
		texts.Add(new String[]{"skill1","skill1"});
		texts.Add(new String[]{"skill2","skill2"});
		texts.Add(new String[]{"skill3","skill3"});
		texts.Add(new String[]{"Compétence verrouillée. Achetez la pour la débloquer!","This skill is locked. Buy it to discover its u"});
		texts.Add(new String[]{"Ma cagnotte : ","My money : "});
		texts.Add(new String[]{"Achat impossible","Missing cristals"});
		texts.Add(new String[]{"Vous n'avez pas assez de cristaux pour compléter cette transaction","You do not have enough cristals to buy this"});
		texts.Add(new String[]{"Boutique","Store"});
		texts.Add(new String[]{"Pas de connexion","No internet"});
		texts.Add(new String[]{"Nous n'avons pas pu contacter le serveur, vous êtes désormais en mode hors-ligne. Veuillez cliquer sur l'icone de connexion sur la page d'accueil pour vous reconnecter","We were not able to connect to distant server, you are now offline. Please reconnect by clicking on the wifi button on Home Page"});
		texts.Add(new String[]{"Mode connecté","Online mode"});
		texts.Add(new String[]{"Mode déconnecté","Offline mode"});
		texts.Add(new String[]{"Souhaitez-vous synchroniser vos données locales vers le cloud ou récupérer vos données en ligne ?","Would you rather use this device's data or your online data ?"});
		texts.Add(new String[]{"En passant en mode déconnecté vous ne pourrez plus disputer de matchs officiels!","You will be unable to do official fights. However you will still be able to manage your units and do practice fights"});
		texts.Add(new String[]{"Annuler","Cancel"});
		texts.Add(new String[]{"Données locales","Use local data"});
		texts.Add(new String[]{"Données en ligne","Use online data"});
		texts.Add(new String[]{"Echec","Sync failed"});
		texts.Add(new String[]{"Nous n'avons pas pu synchroniser vos données, veuillez vérifier l'état de votre connexion internet et réessayez","We were not able to synchronize your data online. Please check your internet connection and try again"});
		texts.Add(new String[]{"Match officiel","Official fight"});
		texts.Add(new String[]{"Match amical","Practice fight"});
		texts.Add(new String[]{"Statistiques","Statistics"});
		texts.Add(new String[]{"Maintien","Avoid relegation"});
		texts.Add(new String[]{"Promotion","Promotion"});
		texts.Add(new String[]{"Jouer!","Play !"});
		texts.Add(new String[]{"ARG1 match restant","ARG1 fight left"});
		texts.Add(new String[]{"ARG1 matchs restants","ARG1 fights left"});
		texts.Add(new String[]{"division","division"});
		texts.Add(new String[]{"Vous devez nécessairement vous connecter à Internet pour pouvoir disputer des matchs officiels. Cliquez sur l'icone Wifi ci dessus","You must be connected to Internet to fight against ranked opponents. Please click on the wifi button above"});
		texts.Add(new String[]{"Les matchs amicaux rapportent moins de cristaux!","Practice fights will make you earn less cristals than official ones"});
		texts.Add(new String[]{"victoire","win"});
		texts.Add(new String[]{"victoires","wins"});
		texts.Add(new String[]{"Collection","Collection"});
		texts.Add(new String[]{"défaite","loss"});
		texts.Add(new String[]{"loss","loss"});
		texts.Add(new String[]{"Nous n'avons pas pu vous connecter au serveur, veuillez vous reconnecter","We were not able to connect to the server, please try to reconnect"});
		texts.Add(new String[]{"Préparation du combat","Fight preparation"});
		texts.Add(new String[]{"Vos points de manoeuvre vous permettent de modifier l'équipe aléatoirement composée ou de changer l'ordre des unités. Le joueur ayant conservé le plus de points de manoeuvre à l'issue de cette phase sera le premier à jouer pendant le combat","You can use your techtical points to modify your randomly generated team or to change its units order. The player with the most techtical points left at the end of this phase will start the fight"});

		errors = new List<string[]>();
		//0
		errors.Add(new String[]{"Problème de récupération de données, veuillez réessayer plus tard","Data collection problem. Please try again later"});

	}

	public static string getText(int idReference, List<string> args, int languageID){
		string text = texts[idReference][languageID];
		for(int i = 0;i<args.Count;i++){
			text = text.Replace("ARG"+(i+1),args[i]);
		}
		return text;
	}

}