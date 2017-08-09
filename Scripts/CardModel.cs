using System;

public class CardModel
{
	public int life;
	public int move;
	public int skill0;
	public int skill1;
	public int skill2;
	public int skill3;

	public CardModel (int l, int m, int s0, int s1, int s2, int s3){
		this.life = l;
		this.move = m;
		this.skill0 = s0;
		this.skill1 = s1;
		this.skill2 = s2;
		this.skill3 = s3;
	}

	public int getLevel(){
		return this.life+this.move+this.skill0+this.skill1+this.skill2+this.skill3-2;
	}
}