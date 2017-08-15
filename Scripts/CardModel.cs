using System;

public class CardModel
{
	public int life;
	public int move;
	public int skill0;
	public int skill1;
	public int skill2;
	public int skill3;

	public CardModel (int m, int l, int s0, int s1, int s2, int s3){
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

	public int getCarac(int i){
		if(i==0){
			return move;
		}
		else if(i==1){
			return life;
		}
		else if(i==2){
			return skill0;
		}
		else if(i==3){
			return skill1;
		}
		else if(i==4){
			return skill2;
		}
		else{
			return skill3;
		}
	}

	public void setCarac(int i, int j){
		if(i==0){
			move=j;
		}
		else if(i==1){
			life=j;
		}
		else if(i==2){
			skill0=j;
		}
		else if(i==3){
			skill1=j;
		}
		else if(i==4){
			skill2=j;
		}
		else{
			skill3=j;
		}
	}
}