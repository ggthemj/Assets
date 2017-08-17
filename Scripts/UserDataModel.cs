using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataModel
{
	public int credits;
	public int division;
	public int divisionwins;
	public int divisiongames;
	public int loss;
	public int wins;
	public int ranking;
	public int rankingpoints;
	public int rowwins;
	public int stars;
	public string name;
	public int iconid;
	public int classementfighter;
	public int classementcollec;
	public int haslaunchedgame;
	public int card0_0;
	public int card0_1;
	public int card0_2;
	public int card0_3;
	public int card0_4;
	public int card0_5;
	public int card1_0;
	public int card1_1;
	public int card1_2;
	public int card1_3;
	public int card1_4;
	public int card1_5;
	public int card2_0;
	public int card2_1;
	public int card2_2;
	public int card2_3;
	public int card2_4;
	public int card2_5;
	public int card3_0;
	public int card3_1;
	public int card3_2;
	public int card3_3;
	public int card3_4;
	public int card3_5;
	public int card4_0;
	public int card4_1;
	public int card4_2;
	public int card4_3;
	public int card4_4;
	public int card4_5;
	public int card5_0;
	public int card5_1;
	public int card5_2;
	public int card5_3;
	public int card5_4;
	public int card5_5;
	public int card6_0;
	public int card6_1;
	public int card6_2;
	public int card6_3;
	public int card6_4;
	public int card6_5;
	public int card7_0;
	public int card7_1;
	public int card7_2;
	public int card7_3;
	public int card7_4;
	public int card7_5;
	public int card8_0;
	public int card8_1;
	public int card8_2;
	public int card8_3;
	public int card8_4;
	public int card8_5;
	public int card9_0;
	public int card9_1;
	public int card9_2;
	public int card9_3;
	public int card9_4;
	public int card9_5;
	public int card10_0;
	public int card10_1;
	public int card10_2;
	public int card10_3;
	public int card10_4;
	public int card10_5;
	public int card11_0;
	public int card11_1;
	public int card11_2;
	public int card11_3;
	public int card11_4;
	public int card11_5;
	public List<CardModel> cards;

	public UserDataModel ()
	{
		
	}

	public void fillCards(){
		this.cards = new List<CardModel>();
		this.cards.Add(new CardModel(card0_0, card0_1, card0_2, card0_3, card0_4, card0_5));
		this.cards.Add(new CardModel(card1_0, card1_1, card1_2, card1_3, card1_4, card1_5));
		this.cards.Add(new CardModel(card2_0, card2_1, card2_2, card2_3, card2_4, card2_5));
		this.cards.Add(new CardModel(card3_0, card3_1, card3_2, card3_3, card3_4, card3_5));
		this.cards.Add(new CardModel(card4_0, card4_1, card4_2, card4_3, card4_4, card4_5));
		this.cards.Add(new CardModel(card5_0, card5_1, card5_2, card5_3, card5_4, card5_5));
		this.cards.Add(new CardModel(card6_0, card6_1, card6_2, card6_3, card6_4, card6_5));
		this.cards.Add(new CardModel(card7_0, card7_1, card7_2, card7_3, card7_4, card7_5));
		this.cards.Add(new CardModel(card8_0, card8_1, card8_2, card8_3, card8_4, card8_5));
		this.cards.Add(new CardModel(card9_0, card9_1, card9_2, card9_3, card9_4, card9_5));
		this.cards.Add(new CardModel(card10_0, card10_1, card10_2, card10_3, card10_4, card10_5));
		this.cards.Add(new CardModel(card11_0, card11_1, card11_2, card11_3, card11_4, card11_5));
	}

	public void fillPlayerPrefs(){
		PlayerPrefs.SetInt("credits",credits);
		PlayerPrefs.SetInt("division",division);
		PlayerPrefs.SetInt("divisionwins",divisionwins);
		PlayerPrefs.SetInt("divisiongames",divisiongames);
		PlayerPrefs.SetInt("loss",loss);
		PlayerPrefs.SetInt("wins",wins);
		PlayerPrefs.SetInt("ranking",ranking);
		PlayerPrefs.SetInt("rankingpoints",rankingpoints);
		PlayerPrefs.SetInt("rowwins",rowwins);
		PlayerPrefs.SetInt("stars",stars);
		PlayerPrefs.SetString("name",name);
		PlayerPrefs.SetInt("iconid",iconid);
		PlayerPrefs.SetInt("classementfighter",classementfighter);
		PlayerPrefs.SetInt("classementcollec",classementcollec);
		PlayerPrefs.SetInt("haslaunchedgame",haslaunchedgame);

		PlayerPrefs.SetInt("card0_0",card0_0);
		PlayerPrefs.SetInt("card0_1",card0_1);
		PlayerPrefs.SetInt("card0_2",card0_2);
		PlayerPrefs.SetInt("card0_3",card0_3);
		PlayerPrefs.SetInt("card0_4",card0_4);
		PlayerPrefs.SetInt("card0_5",card0_5);
		PlayerPrefs.SetInt("card1_0",card1_0);
		PlayerPrefs.SetInt("card1_1",card1_1);
		PlayerPrefs.SetInt("card1_2",card1_2);
		PlayerPrefs.SetInt("card1_3",card1_3);
		PlayerPrefs.SetInt("card1_4",card1_4);
		PlayerPrefs.SetInt("card1_5",card1_5);
		PlayerPrefs.SetInt("card2_0",card2_0);
		PlayerPrefs.SetInt("card2_1",card2_1);
		PlayerPrefs.SetInt("card2_2",card2_2);
		PlayerPrefs.SetInt("card2_3",card2_3);
		PlayerPrefs.SetInt("card2_4",card2_4);
		PlayerPrefs.SetInt("card2_5",card2_5);
		PlayerPrefs.SetInt("card3_0",card3_0);
		PlayerPrefs.SetInt("card3_1",card3_1);
		PlayerPrefs.SetInt("card3_2",card3_2);
		PlayerPrefs.SetInt("card3_3",card3_3);
		PlayerPrefs.SetInt("card3_4",card3_4);
		PlayerPrefs.SetInt("card3_5",card3_5);
		PlayerPrefs.SetInt("card4_0",card4_0);
		PlayerPrefs.SetInt("card4_1",card4_1);
		PlayerPrefs.SetInt("card4_2",card4_2);
		PlayerPrefs.SetInt("card4_3",card4_3);
		PlayerPrefs.SetInt("card4_4",card4_4);
		PlayerPrefs.SetInt("card4_5",card4_5);
		PlayerPrefs.SetInt("card5_0",card5_0);
		PlayerPrefs.SetInt("card5_1",card5_1);
		PlayerPrefs.SetInt("card5_2",card5_2);
		PlayerPrefs.SetInt("card5_3",card5_3);
		PlayerPrefs.SetInt("card5_4",card5_4);
		PlayerPrefs.SetInt("card5_5",card5_5);
		PlayerPrefs.SetInt("card6_0",card6_0);
		PlayerPrefs.SetInt("card6_1",card6_1);
		PlayerPrefs.SetInt("card6_2",card6_2);
		PlayerPrefs.SetInt("card6_3",card6_3);
		PlayerPrefs.SetInt("card6_4",card6_4);
		PlayerPrefs.SetInt("card6_5",card6_5);
		PlayerPrefs.SetInt("card7_0",card7_0);
		PlayerPrefs.SetInt("card7_1",card7_1);
		PlayerPrefs.SetInt("card7_2",card7_2);
		PlayerPrefs.SetInt("card7_3",card7_3);
		PlayerPrefs.SetInt("card7_4",card7_4);
		PlayerPrefs.SetInt("card7_5",card7_5);
		PlayerPrefs.SetInt("card8_0",card8_0);
		PlayerPrefs.SetInt("card8_1",card8_1);
		PlayerPrefs.SetInt("card8_2",card8_2);
		PlayerPrefs.SetInt("card8_3",card8_3);
		PlayerPrefs.SetInt("card8_4",card8_4);
		PlayerPrefs.SetInt("card8_5",card8_5);
		PlayerPrefs.SetInt("card9_0",card9_0);
		PlayerPrefs.SetInt("card9_1",card9_1);
		PlayerPrefs.SetInt("card9_2",card9_2);
		PlayerPrefs.SetInt("card9_3",card9_3);
		PlayerPrefs.SetInt("card9_4",card9_4);
		PlayerPrefs.SetInt("card9_5",card9_5);
		PlayerPrefs.SetInt("card10_0",card10_0);
		PlayerPrefs.SetInt("card10_1",card10_1);
		PlayerPrefs.SetInt("card10_2",card10_2);
		PlayerPrefs.SetInt("card10_3",card10_3);
		PlayerPrefs.SetInt("card10_4",card10_4);
		PlayerPrefs.SetInt("card10_5",card10_5);
		PlayerPrefs.SetInt("card11_0",card11_0);
		PlayerPrefs.SetInt("card11_1",card11_1);
		PlayerPrefs.SetInt("card11_2",card11_2);
		PlayerPrefs.SetInt("card11_3",card11_3);
		PlayerPrefs.SetInt("card11_4",card11_4);
		PlayerPrefs.SetInt("card11_5",card11_5);
	}

	public void reverseFillCards(){
		this.card0_0 = this.cards[0].move ;
		this.card0_1 = this.cards[0].life ;
		this.card0_2 = this.cards[0].skill0 ;
		this.card0_3 = this.cards[0].skill1 ;
		this.card0_4 = this.cards[0].skill2 ;
		this.card0_5 = this.cards[0].skill3 ;
		this.card1_0 = this.cards[1].move ;
		this.card1_1 = this.cards[1].life ;
		this.card1_2 = this.cards[1].skill0 ;
		this.card1_3 = this.cards[1].skill1 ;
		this.card1_4 = this.cards[1].skill2 ;
		this.card1_5 = this.cards[1].skill3 ;
		this.card2_0 = this.cards[2].move ;
		this.card2_1 = this.cards[2].life ;
		this.card2_2 = this.cards[2].skill0 ;
		this.card2_3 = this.cards[2].skill1 ;
		this.card2_4 = this.cards[2].skill2 ;
		this.card2_5 = this.cards[2].skill3 ;
		this.card3_0 = this.cards[3].move ;
		this.card3_1 = this.cards[3].life ;
		this.card3_2 = this.cards[3].skill0 ;
		this.card3_3 = this.cards[3].skill1 ;
		this.card3_4 = this.cards[3].skill2 ;
		this.card3_5 = this.cards[3].skill3 ;
		this.card4_0 = this.cards[4].move ;
		this.card4_1 = this.cards[4].life ;
		this.card4_2 = this.cards[4].skill0 ;
		this.card4_3 = this.cards[4].skill1 ;
		this.card4_4 = this.cards[4].skill2 ;
		this.card4_5 = this.cards[4].skill3 ;
		this.card5_0 = this.cards[5].move ;
		this.card5_1 = this.cards[5].life ;
		this.card5_2 = this.cards[5].skill0 ;
		this.card5_3 = this.cards[5].skill1 ;
		this.card5_4 = this.cards[5].skill2 ;
		this.card5_5 = this.cards[5].skill3 ;
		this.card6_0 = this.cards[6].move ;
		this.card6_1 = this.cards[6].life ;
		this.card6_2 = this.cards[6].skill0 ;
		this.card6_3 = this.cards[6].skill1 ;
		this.card6_4 = this.cards[6].skill2 ;
		this.card6_5 = this.cards[6].skill3 ;
		this.card7_0 = this.cards[7].move ;
		this.card7_1 = this.cards[7].life ;
		this.card7_2 = this.cards[7].skill0 ;
		this.card7_3 = this.cards[7].skill1 ;
		this.card7_4 = this.cards[7].skill2 ;
		this.card7_5 = this.cards[7].skill3 ;
		this.card8_0 = this.cards[8].move ;
		this.card8_1 = this.cards[8].life ;
		this.card8_2 = this.cards[8].skill0 ;
		this.card8_3 = this.cards[8].skill1 ;
		this.card8_4 = this.cards[8].skill2 ;
		this.card8_5 = this.cards[8].skill3 ;
		this.card9_0 = this.cards[9].move ;
		this.card9_1 = this.cards[9].life ;
		this.card9_2 = this.cards[9].skill0 ;
		this.card9_3 = this.cards[9].skill1 ;
		this.card9_4 = this.cards[9].skill2 ;
		this.card9_5 = this.cards[9].skill3 ;
		this.card10_0 = this.cards[10].move ;
		this.card10_1 = this.cards[10].life ;
		this.card10_2 = this.cards[10].skill0 ;
		this.card10_3 = this.cards[10].skill1 ;
		this.card10_4 = this.cards[10].skill2 ;
		this.card10_5 = this.cards[10].skill3 ;
		this.card11_0 = this.cards[11].move ;
		this.card11_1 = this.cards[11].life ;
		this.card11_2 = this.cards[11].skill0 ;
		this.card11_3 = this.cards[11].skill1 ;
		this.card11_4 = this.cards[11].skill2 ;
		this.card11_5 = this.cards[11].skill3 ;

	}

	public int getTotalLevel(){
		int level = 0 ; 
		for (int i = 0 ; i < this.cards.Count ; i++){
			level+=this.cards[i].getLevel();
		}
		return Mathf.FloorToInt(100*level/(this.cards.Count*25f));
	}

	public List<int> getRandom4Units(){
		List<int> listeBase = new List<int>();
		List<int> liste = new List<int>();
		int temp ;
		for(int i = 0 ; i < AppModel.instance.userData.cards.Count ; i++){
			if(AppModel.instance.userData.cards[i].skill1>0){
				listeBase.Add(i);
			}
		}

		for(int i = 0 ; i < 4 ; i++){
			temp = UnityEngine.Random.Range(0,listeBase.Count-1);
			liste.Add(listeBase[temp]);
			listeBase.RemoveAt(temp);
		}

		return liste;
	}

	public int getRandomUnitLeft(List<int> usedUnits){
		List<int> listeBase = new List<int>();
		for(int i = 0 ; i < AppModel.instance.userData.cards.Count ; i++){
			if(AppModel.instance.userData.cards[i].skill1>0){
				listeBase.Add(i);
			}
		}

		for(int i = 0 ; i < 4 ; i++){
			listeBase.Remove(usedUnits[i]);
		}

		return listeBase[UnityEngine.Random.Range(0,listeBase.Count-1)];
	}
}