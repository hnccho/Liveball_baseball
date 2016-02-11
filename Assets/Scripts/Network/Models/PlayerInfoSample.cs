using UnityEngine;
using System.Collections;

public class PlayerInfoSample : PlayerInfo{
	public PlayerInfoSample(int index){
		if (index == 0) {
			gameSeq= 0;
			homeNawayType= 0;
			playerNumber= 29;
			playerType= 2;
			teamCode= "SK";
			playerName= "김광현";
			playerNick= "김광현";
			position= "P";
			ERA= " 3.42";
			WIN= "7";
			WAVG= "0";
			INNING= "81 2/3";
			LOSS= "5";
			HR= "0";
			AVG= "0";
			RBI= "0";
			HIT= "0";
			imageName= "baseball_SK_77829.jpg";
			imagePath= "spos/player/baseball/";
		} else{
			gameSeq= 0;
			homeNawayType= 0;
			playerNumber= 6;
			playerType= 1;
			teamCode= "NC";
			playerName= "강민국";
			playerNick= "강민국";
			position= "H";
			ERA= "0";
			WIN= "0";
			WAVG= "0";
			INNING= "0";
			LOSS= "0";
			HR= "0";
			AVG= "0";
			RBI= "0";
			HIT= "0";
			imageName= "baseball_NC_64906.jpg";
			imagePath= "spos/player/baseball/";
		}
	}
}
