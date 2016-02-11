using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInfo {
	public static bool IsTest = false;

	int _memSeq;

	public int memSeq {
		get {
			return _memSeq;
		}
		set {
			_memSeq = value;
		}
	}

	int _memberNo;
	public int memberNo {
		get {
			return _memberNo;
		}
		set {
			_memberNo = value;
		}
	}

//: 1000000416,
	string _memberEmail;
	public string memberEmail {
		get {
			return _memberEmail;
		}
		set {
			_memberEmail = value;
		}
	}

//: "gunloves@.",
	string _memberName;
	public string memberName {
		get {
			return _memberName;
		}
		set {
			_memberName = value;
		}
	}

//: "gunloves",
	int _registType;
	public int registType {
		get {
			return _registType;
		}
		set {
			_registType = value;
		}
	}

	private string _imagePath;
	
	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
		}
	}

// 3,
	string _imageName;
	public string imageName {
		get {
			return _imageName;
		}
		set {
			_imageName = value;
		}
	}

// "",
	int _imageWidth;
	public int imageWidth {
		get {
			return _imageWidth;
		}
		set {
			_imageWidth = value;
		}
	}

// 0,
	int _imageHeight;
	public int imageHeight {
		get {
			return _imageHeight;
		}
		set {
			_imageHeight = value;
		}
	}

// 0,
	int _useNotify;
	public int useNotify {
		get {
			return _useNotify;
		}
		set {
			_useNotify = value;
		}
	}

// 1,
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

// "0",
	int _followingCount;
	public int followingCount {
		get {
			return _followingCount;
		}
		set {
			_followingCount = value;
		}
	}

// 0,
	int _followerCount;
	public int followerCount {
		get {
			return _followerCount;
		}
		set {
			_followerCount = value;
		}
	}

// 0,
	int _teamSeq;

	public int teamSeq {
		get {
			return _teamSeq;
		}
		set {
			_teamSeq = value;
		}
	}

	string _teamCode;

	public string teamCode {
		set {
			_teamCode = value;
		}
	}

		//favoBB;// {
		//	int _teamSeq;// 11,
		//	teamName;// "넥센",
		//	teamFullName;// "넥센 히어로즈",
		//	imageName;// "sports_team_baseball_wo.png",
		//	imageWidth;// 200,
		//	imageHeight;// 200,
		//	teamColor;// "#8f0a27",
		//	teamCode;// "WO",
		//	contentsType;// 2001
		//	},
	int _isBlackList;
	public int isBlackList {
		get {
			return _isBlackList;
		}
		set {
			_isBlackList = value;
		}
	}

// 0,
	int _activeAuth;
	public int activeAuth {
		get {
			return _activeAuth;
		}
		set {
			_activeAuth = value;
		}
	}

// 1,
	int _active;
	public int active {
		get {
			return _active;
		}
		set {
			_active = value;
		}
	}

// 1,
	string _phoneNum;
	public string phoneNum {
		get {
			return _phoneNum;
		}
		set {
			_phoneNum = value;
		}
	}

	public string _teamFullName;

	public string teamFullName {
		set {
			_teamFullName = value;
		}
	}

	public string _teamName;
	
	public string teamName {
		set {
			_teamName = value;
		}
	}

	public FavoBB _favoBB;

	public FavoBB favoBB {
		get {
			return _favoBB;
		}
		set {
			_favoBB = value;
		}
	}

	public string GetTeamName(){
		if(_teamName == null || _teamName.Length < 1){
			if(favoBB == null)
				return null;
			else
				return favoBB.teamName;
		}
		return null;
	}

	public string GetTeamCode(){
		if(_teamCode == null || _teamCode.Length < 1){
			if(favoBB == null)
				return null;
			else
				return favoBB.teamCode;
		}
		return null;
	}

	public string GetTeamFullName(){
		if(_teamFullName == null || _teamFullName.Length < 1){
			if(favoBB == null)
				return null;
			else
				return favoBB.teamFullName;
		}
		return null;
	}

	List<ItemStrategyInfo> _item;

	public List<ItemStrategyInfo> item {
		get {
			return _item;
		}
		set {
			_item = value;
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

	Texture2D _Textures;
	
	public Texture2D Textures {
		get {
			return _Textures;
		}
		set {
			_Textures = value;
		}
	}
	string _myEntryFee;
	public string myEntryFee {
		get {
			return _myEntryFee;
		}
		set {
			_myEntryFee = value;
		}
	}

	string _totalRuby;

	public string totalRuby {
		get {
			return _totalRuby;
		}
		set {
			_totalRuby = value;
		}
	}

	string _totalMileage;

	public string totalMileage {
		get {
			return _totalMileage;
		}
		set {
			_totalMileage = value;
		}
	}

	string _memPIN;

	public string memPIN {
		get {
			return _memPIN;
		}
		set {
			_memPIN = value;
		}
	}
}
