﻿using System;
using System.Collections;
using System.Collections.Generic;

public class CardStatsData
{
	public static int[] life;
	public static int[] move;
	public static IList<string[]> unlockTexts;
	public static IList<string[]> nameTexts;

	public static int getLife(int idReference, int idLevel){
		return (life[idReference]*(4+idLevel))/4;
	}

	public static int getMove(int idReference, int idLevel){
		return (move[idReference]+idLevel-1);
	}

	public static string getUnlockText(int idReference, int languageID){
		return unlockTexts[idReference][languageID];
	}

	public static string getNameText(int idReference, int languageID){
		return nameTexts[idReference][languageID];
	}

	static CardStatsData ()
	{
		life = new int[12];
		life[0]=20;
		life[1]=32;
		life[2]=20;
		life[3]=20;
		life[4]=20;
		life[5]=20;
		life[6]=20;
		life[7]=20;
		life[8]=20;
		life[9]=20;
		life[10]=20;
		life[11]=20;

		move = new int[12];
		move[0]=1;
		move[1]=1;
		move[2]=1;
		move[3]=2;
		move[4]=2;
		move[5]=2;
		move[6]=2;
		move[7]=2;
		move[8]=2;
		move[9]=2;
		move[10]=2;
		move[11]=2;

		unlockTexts = new List<string[]>();
		//0
		unlockTexts.Add(new String[]{"",""});
		unlockTexts.Add(new String[]{"",""});
		unlockTexts.Add(new String[]{"",""});
		unlockTexts.Add(new String[]{"",""});
		unlockTexts.Add(new String[]{"Débloque cette unité en disputant ton premier match","Play your first game to unlock this unit"});
		unlockTexts.Add(new String[]{"Atteint la division 9 pour débloquer cette unité","Reach division 9 to unlock this unit"});
		unlockTexts.Add(new String[]{"Obtient 10 points de collection pour débloquer cette unité","Reach 10 collection points to unlock this unit"});
		unlockTexts.Add(new String[]{"Obtient 40 points de collection pour débloquer cette unité","Reach 40 collection points to unlock this unit"});
		unlockTexts.Add(new String[]{"Fait monter une unité au niveau 25 pour débloquer cette unité","Reach level 25 with any unit to unlock this one"});
		unlockTexts.Add(new String[]{"Obtient 100 points de collection pour débloquer cette unité","Reach 100 collection points to unlock this unit"});
		unlockTexts.Add(new String[]{"Atteint la division 5 pour débloquer cette unité","Reach division 5 to unlock this unit"});
		unlockTexts.Add(new String[]{"Atteint la division 1 pour débloquer cette unité","Reach division 1 to unlock this unit"});

		nameTexts = new List<string[]>();
		//0
		nameTexts.Add(new String[]{"Medic","Medic"});
		nameTexts.Add(new String[]{"Prédateur","Predator"});
		nameTexts.Add(new String[]{"Assassin","Assassin"});
		nameTexts.Add(new String[]{"Mitrailleur","Infantry"});
		nameTexts.Add(new String[]{"Virologue","Virologist"});
		nameTexts.Add(new String[]{"Berserk","Berserk"});
		nameTexts.Add(new String[]{"Ninja","Ninja"});
		nameTexts.Add(new String[]{"Pistolero","Pistolero"});
		nameTexts.Add(new String[]{"Infirmière","Nurse"});
		nameTexts.Add(new String[]{"Tank","Tank"});
		nameTexts.Add(new String[]{"Pretresse","Priestess"});
		nameTexts.Add(new String[]{"Gourou","Guru"});
	}
}