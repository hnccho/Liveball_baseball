using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExpandInvenInfo {
	string _increaseMsg;
	public string increaseMsg {
		get {
			return _increaseMsg;
		}
		set {
			_increaseMsg = value;
		}
	}

//"card expand, success",
//	응답 메시지	
	int _isOK;
	public int isOK {
		get {
			return _isOK;
		}
		set {
			_isOK = value;
		}
	}

//1,
//		성공	
	int	_outCode;
	public int outCode {
		get {
			return _outCode;
		}
		set {
			_outCode = value;
		}
	}

//0,
	int _gold;
	public int gold {
		get {
			return _gold;
		}
		set {
			_gold = value;
		}
	}

//103320,
//			보유 골드	
	int _userInvenOfCard;
	public int userInvenOfCard {
		get {
			return _userInvenOfCard;
		}
		set {
			_userInvenOfCard = value;
		}
	}

//70,
	int _userInvenOfSkill;//30

	public int userInvenOfSkill {
		get {
			return _userInvenOfSkill;
		}
		set {
			_userInvenOfSkill = value;
		}
	}
}
