using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckMailbox {
	int _memSeq;
	public int memSeq {
		get {
			return _memSeq;
		}
		set {
			_memSeq = value;
		}
	}
	float _memberNo;
	public float memberNo {
		get {
			return _memberNo;
		}
		set {
			_memberNo = value;
		}
	}
	string _memberEmail;
	public string memberEmail {
		get {
			return _memberEmail;
		}
		set {
			_memberEmail = value;
		}
	}
	string _memberName;
	public string memberName {
		get {
			return _memberName;
		}
		set {
			_memberName = value;
		}
	}


	int _registType;
	public int registType {
		get {
			return _registType;
		}
		set {
			_registType = value;
		}
	}

	string _imagePath;
	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
		}
	}

	
	string _userGoldenBall;
	public string userGoldenBall {
		get {
			return _userGoldenBall;
		}
		set {
			_userGoldenBall = value;
		}
	}
	
	// "775296",
	string _userDiamond;
	public string userDiamond {
		get {
			return _userDiamond;
		}
		set {
			_userDiamond = value;
		}
	}
	
	// "982892",
	string _userRuby;
	public string userRuby {
		get {
			return _userRuby;
		}
		set {
			_userRuby = value;
		}
	}
	
	// "9432",
	string _useActiveDiamond;
	public string useActiveDiamond {
		get {
			return _useActiveDiamond;
		}
		set {
			_useActiveDiamond = value;
		}
	}
	int _isBlackList;
	public int isBlackList {
		get {
			return _isBlackList;
		}
		set {
			_isBlackList = value;
		}
	}
	int _activeAuth;
	public int activeAuth {
		get {
			return _activeAuth;
		}
		set {
			_activeAuth = value;
		}
	}
	int _active;
	public int active {
		get {
			return _active;
		}
		set {
			_active = value;
		}
	}

	string _phoneNum;
	public string phoneNum {
		get {
			return _phoneNum;
		}
		set {
			_phoneNum = value;
		}
	}
	int _ppCount;
	public int ppCount {
		get {
			return _ppCount;
		}
		set {
			_ppCount = value;
		}
	}
	GachaInfo _gacha;
	public GachaInfo gacha {
		get {
			return _gacha;
		}
		set {
			_gacha = value;
		}
	}
	private string _limitDateTime;
	public string limitDateTime {
		get {
			return _limitDateTime;
		}
		set {
			_limitDateTime = value;
		}
	}
}
