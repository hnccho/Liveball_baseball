using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardInvenInfo {

//	int _memberNo;
	List<CardClassInfo> _cardClass;

	public List<CardClassInfo> cardClass {
		get {
			return _cardClass;
		}
		set {
			_cardClass = value;
		}
	}

	List<CardInfo> _pitcher;

	public List<CardInfo> pitcher {
		get {
			return _pitcher;
		}
		set {
			_pitcher = value;
		}
	}

	List<CardInfo> _hitter;

	public List<CardInfo> hitter {
		get {
			return _hitter;
		}
		set {
			_hitter = value;
		}
	}
}
