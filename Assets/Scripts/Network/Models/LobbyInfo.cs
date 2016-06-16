using UnityEngine;
using System.Collections;

public class LobbyInfo {
	int _myCardCount;

	public int myCardCount {
		get {
			return _myCardCount;
		}
		set {
			_myCardCount = value;
		}
	}

	int _upContestCount;

	public int upContestCount {
		get {
			return _upContestCount;
		}
		set {
			_upContestCount = value;
		}
	}

	int _myContestCount;

	public int myContestCount {
		get {
			return _myContestCount;
		}
		set {
			_myContestCount = value;
		}
	}

	int _contestCountS;

	public int contestCountS {
		get {
			return _contestCountS;
		}
		set {
			_contestCountS = value;
		}
	}

	int _contestCount50;

	public int contestCount50 {
		get {
			return _contestCount50;
		}
		set {
			_contestCount50 = value;
		}
	}

	int _contestCountR;

	public int contestCountR {
		get {
			return _contestCountR;
		}
		set {
			_contestCountR = value;
		}
	}
	int _expandUnitOfCard;
	public int expandUnitOfCard {
		get {
			return _expandUnitOfCard;
		}
		set {
			_expandUnitOfCard = value;
		}
	}

//10,
//	카드인벤 확장단위		
	int _expandUnitOfSkill;
	public int expandUnitOfSkill {
		get {
			return _expandUnitOfSkill;
		}
		set {
			_expandUnitOfSkill = value;
		}
	}

//10,
//		스킬인벤 확장단위		
	int _maxInvenOfCard;
	public int maxInvenOfCard {
		get {
			return _maxInvenOfCard;
		}
		set {
			_maxInvenOfCard = value;
		}
	}

//200,
//			최대 확장 가능 수		
	int _maxInvenOfSkill;
	public int maxInvenOfSkill {
		get {
			return _maxInvenOfSkill;
		}
		set {
			_maxInvenOfSkill = value;
		}
	}

//100,
//			최대 확장 가능 수		
	int _expandPriceOfCard;
	public int expandPriceOfCard {
		get {
			return _expandPriceOfCard;
		}
		set {
			_expandPriceOfCard = value;
		}
	}

//100,
//			확장 가격		
	int _expandPriceOfSkill;
	public int expandPriceOfSkill {
		get {
			return _expandPriceOfSkill;
		}
		set {
			_expandPriceOfSkill = value;
		}
	}

//100,
//			확장 가격		
	int _userGold;
	public int userGold {
		get {
			return _userGold;
		}
		set {
			_userGold = value;
		}
	}

//103320,
//			보유 골드		
	int _userTicket;
	public int userTicket {
		get {
			return _userTicket;
		}
		set {
			_userTicket = value;
		}
	}

//1080,
//			보유 티켓		
	int _userRankPoint;
	public int userRankPoint {
		get {
			return _userRankPoint;
		}
		set {
			_userRankPoint = value;
		}
	}

//0
//			보유 RP		
	int _userInvenOfSkill;
	public int userInvenOfSkill {
		get {
			return _userInvenOfSkill;
		}
		set {
			_userInvenOfSkill = value;
		}
	}

//30,
//			보유 스킬 보관 수량		
	int _userInvenOfCard;//70,

	public int userInvenOfCard {
		get {
			return _userInvenOfCard;
		}
		set {
			_userInvenOfCard = value;
		}
	}
}
