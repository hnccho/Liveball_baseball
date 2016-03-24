using UnityEngine;
using System.Collections;

public class CardInfo {
	public enum INVEN_TYPE{
		PACK,
		CARD,
		EXPAND
	}

	INVEN_TYPE _mType;

	public INVEN_TYPE mType {
		get {
			return _mType;
		}
		set {
			_mType = value;
		}
	}

	string _teamName;

	public string teamName {
		get {
			return _teamName;
		}
		set {
			_teamName = value;
		}
	}

	string _city;

	public string city {
		get {
			return _city;
		}
		set {
			_city = value;
		}
	}

	string _dcRatio;

	public string dcRatio {
		get {
			return _dcRatio;
		}
		set {
			_dcRatio = value;
		}
	}

	string _photoUrl;

	public string photoUrl {
		get {
			return _photoUrl;
		}
		set {
			_photoUrl = value;
		}
	}

	string _firstName;

	public string firstName {
		get {
			return _firstName;
		}
		set {
			_firstName = value;
		}
	}

	string _lastName;

	public string lastName {
		get {
			return _lastName;
		}
		set {
			_lastName = value;
		}
	}

	string _fppg;

	public string fppg {
		get {
			return _fppg;
		}
		set {
			_fppg = value;
		}
	}

	string _playerName;

	public string playerName {
		get {
			return _playerName;
		}
		set {
			_playerName = value;
		}
	}

	long _playerFK;

	public long playerFK {
		get {
			return _playerFK;
		}
		set {
			_playerFK = value;
		}
	}

	int _salary_org;

	public int salary_org {
		get {
			return _salary_org;
		}
		set {
			_salary_org = value;
		}
	}

	int _salary;

	public int salary {
		get {
			return _salary;
		}
		set {
			_salary = value;
		}
	}

	int _jersey;

	public int jersey {
		get {
			return _jersey;
		}
		set {
			_jersey = value;
		}
	}

	int _cardClass;

	public int cardClass {
		get {
			return _cardClass;
		}
		set {
			_cardClass = value;
		}
	}

	string _cardImageIcon;

	public string cardImageIcon {
		get {
			return _cardImageIcon;
		}
		set {
			_cardImageIcon = value;
		}
	}

	int _levelSeq;

	public int levelSeq {
		get {
			return _levelSeq;
		}
		set {
			_levelSeq = value;
		}
	}

	int _memSeq;

	public int memSeq {
		get {
			return _memSeq;
		}
		set {
			_memSeq = value;
		}
	}

	long _itemSeq;

	public long itemSeq {
		get {
			return _itemSeq;
		}
		set {
			_itemSeq = value;
		}
	}

	int _itemType;

	public int itemType {
		get {
			return _itemType;
		}
		set {
			_itemType = value;
		}
	}

	long _itemId;

	public long itemId {
		get {
			return _itemId;
		}
		set {
			_itemId = value;
		}
	}

	string _injuryYN;

	public string injuryYN {
		get {
			return _injuryYN;
		}
		set {
			_injuryYN = value;
		}
	}

	int _useYn;

	public int useYn {
		get {
			return _useYn;
		}
		set {
			_useYn = value;
		}
	}

	int _cardXp;

	public int cardXp {
		get {
			return _cardXp;
		}
		set {
			_cardXp = value;
		}
	}

	long _memCardNo;

	public long memCardNo {
		get {
			return _memCardNo;
		}
		set {
			_memCardNo = value;
		}
	}

	int _maxLevel;

	public int maxLevel {
		get {
			return _maxLevel;
		}
		set {
			_maxLevel = value;
		}
	}

	string _teamCode;

	public string teamCode {
		get {
			return _teamCode;
		}
		set {
			_teamCode = value;
		}
	}

	string _teamImageIcon;

	public string teamImageIcon {
		get {
			return _teamImageIcon;
		}
		set {
			_teamImageIcon = value;
		}
	}

	float _needDiaPoint;

	public float needDiaPoint {
		get {
			return _needDiaPoint;
		}
		set {
			_needDiaPoint = value;
		}
	}

	string _cardImagePath;

	public string cardImagePath {
		get {
			return _cardImagePath;
		}
		set {
			_cardImagePath = value;
		}
	}

	int _maxCardXp;

	public int maxCardXp {
		get {
			return _maxCardXp;
		}
		set {
			_maxCardXp = value;
		}
	}

	int _needUpgradePoint;

	public int needUpgradePoint {
		get {
			return _needUpgradePoint;
		}
		set {
			_needUpgradePoint = value;
		}
	}

	int _accrueCardXp;

	public int accrueCardXp {
		get {
			return _accrueCardXp;
		}
		set {
			_accrueCardXp = value;
		}
	}

	long _cardNo;

	public long cardNo {
		get {
			return _cardNo;
		}
		set {
			_cardNo = value;
		}
	}

	string _cardName;

	public string cardName {
		get {
			return _cardName;
		}
		set {
			_cardName = value;
		}
	}

	int _classNo;

	public int classNo {
		get {
			return _classNo;
		}
		set {
			_classNo = value;
		}
	}

	int _teamSeq;

	public int teamSeq {
		get {
			return _teamSeq;
		}
		set {
			_teamSeq = value;
		}
	}

	string _classCode;

	public string classCode {
		get {
			return _classCode;
		}
		set {
			_classCode = value;
		}
	}

	string _cardImageName;

	public string cardImageName {
		get {
			return _cardImageName;
		}
		set {
			_cardImageName = value;
		}
	}

	int _availableHp;

	public int availableHp {
		get {
			return _availableHp;
		}
		set {
			_availableHp = value;
		}
	}

	long _registKey;

	public long registKey {
		get {
			return _registKey;
		}
		set {
			_registKey = value;
		}
	}

	string _className;

	public string className {
		get {
			return _className;
		}
		set {
			_className = value;
		}
	}

	float _rewardRate;

	public float rewardRate {
		get {
			return _rewardRate;
		}
		set {
			_rewardRate = value;
		}
	}

	string _teamImagePath;

	public string teamImagePath {
		get {
			return _teamImagePath;
		}
		set {
			_teamImagePath = value;
		}
	}

	string _teamImageName;

	public string teamImageName {
		get {
			return _teamImageName;
		}
		set {
			_teamImageName = value;
		}
	}

	int _cardLevel;

	public int cardLevel {
		get {
			return _cardLevel;
		}
		set {
			_cardLevel = value;
		}
	}

	int _backNum;

	public int backNum {
		get {
			return _backNum;
		}
		set {
			_backNum = value;
		}
	}

	string _posCode;

	public string posCode {
		get {
			return _posCode;
		}
		set {
			_posCode = value;
		}
	}

	string _position;

	public string position {
		get {
			return _position;
		}
		set {
			_position = value;
		}
	}

	int _team;

	public int team {
		get {
			return _team;
		}
		set {
			_team = value;
		}
	}

}
