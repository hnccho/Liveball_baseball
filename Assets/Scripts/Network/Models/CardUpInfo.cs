using UnityEngine;
using System.Collections;

public class CardUpInfo {
	int _memSeq;
	public int memSeq {
		get {
			return _memSeq;
		}
		set {
			_memSeq = value;
		}
	}

//100000,
	int _itemType;
	public int itemType {
		get {
			return _itemType;
		}
		set {
			_itemType = value;
		}
	}

//2,				
	long _itemId;
	public long itemId {
		get {
			return _itemId;
		}
		set {
			_itemId = value;
		}
	}

//1300072436,
	long _itemSeq;
	public long itemSeq {
		get {
			return _itemSeq;
		}
		set {
			_itemSeq = value;
		}
	}

//1456395022,
	int _cardClass;
	public int cardClass {
		get {
			return _cardClass;
		}
		set {
			_cardClass = value;
		}
	}

//3,				
	int _cardLevel;
	public int cardLevel {
		get {
			return _cardLevel;
		}
		set {
			_cardLevel = value;
		}
	}

//0,				
	int _team;
	public int team {
		get {
			return _team;
		}
		set {
			_team = value;
		}
	}

//9817,				
	long _participantFK;
	public long participantFK {
		get {
			return _participantFK;
		}
		set {
			_participantFK = value;
		}
	}

//72436,
//	int _position;
//	public int position {
//		get {
//			return _position;
//		}
//		set {
//			_position = value;
//		}
//	}

//4,				
	string _posCode;
	public string posCode {
		get {
			return _posCode;
		}
		set {
			_posCode = value;
		}
	}

//"DF",
	int _salary;
	public int salary {
		get {
			return _salary;
		}
		set {
			_salary = value;
		}
	}

//4200,				
	int _shirt_number;
	public int shirt_number {
		get {
			return _shirt_number;
		}
		set {
			_shirt_number = value;
		}
	}

//9,
	string _playerName;
	public string playerName {
		get {
			return _playerName;
		}
		set {
			_playerName = value;
		}
	}

//"Troy Deeney",
	string _teamName;
	public string teamName {
		get {
			return _teamName;
		}
		set {
			_teamName = value;
		}
	}

//"Watford",
	int _fppg;
	public int fppg {
		get {
			return _fppg;
		}
		set {
			_fppg = value;
		}
	}

//7,				
	int _useYn;
	public int useYn {
		get {
			return _useYn;
		}
		set {
			_useYn = value;
		}
	}

//0
	float _rate;
	public float rate {
		get {
			return _rate;
		}
		set {
			_rate = value;
		}
	}

//7168,				
	string	_dcRatio;
	public string dcRatio {
		get {
			return _dcRatio;
		}
		set {
			_dcRatio = value;
		}
	}

//"0.01",
//		할인율		
	int _resultValue;
	public int resultValue {
		get {
			return _resultValue;
		}
		set {
			_resultValue = value;
		}
	}

//1,
//			0:강화실패, 1:강화성공		
	long _itemMain;
	public long itemMain {
		get {
			return _itemMain;
		}
		set {
			_itemMain = value;
		}
	}

//1457425167104,
//			메인아이템		
	string _resultMessage;
	public string resultMessage {
		get {
			return _resultMessage;
		}
		set {
			_resultMessage = value;
		}
	}

//"success",
//			결과 메시지		
	long _itemSub;//1457398173897,

	public long itemSub {
		get {
			return _itemSub;
		}
		set {
			_itemSub = value;
		}
	}
}
