using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BingoRewardInfo {
	int _bingoId;
	public int bingoId {
		get {
			return _bingoId;
		}
		set {
			_bingoId = value;
		}
	}

//;//1,					
	int _bingoCount;
	public int bingoCount {
		get {
			return _bingoCount;
		}
		set {
			_bingoCount = value;
		}
	}

//;//1,
	int _totalRewardGold;
	public int totalRewardGold {
		get {
			return _totalRewardGold;
		}
		set {
			_totalRewardGold = value;
		}
	}
	int _userRewardGold;

	public int userRewardGold {
		get {
			return _userRewardGold;
		}
		set {
			_userRewardGold = value;
		}
	}

//;//5
	int _userBlackBingoReward;
	public int userBlackBingoReward {
		get {
			return _userBlackBingoReward;
		}
		set {
			_userBlackBingoReward = value;
		}
	}

//:0

	int _total;

	public int total {
		get {
			return _total;
		}
		set {
			_total = value;
		}
	}

	float _outPer;

	public float outPer {
		get {
			return _outPer;
		}
		set {
			_outPer = value;
		}
	}

	float _walkPer;

	public float walkPer {
		get {
			return _walkPer;
		}
		set {
			_walkPer = value;
		}
	}

//	int	_userRewardGold;
	int _rewardValue;
	public int rewardValue {
		get {
			return _rewardValue;
		}
		set {
			_rewardValue = value;
		}
	}

//5,max 보상유저수
	int _myTotalBingos;
	public int myTotalBingos {
		get {
			return _myTotalBingos;
		}
		set {
			_myTotalBingos = value;
		}
	}

//10,자신의 빙고수			
	int _myRewarded;
	public int myRewarded {
		get {
			return _myRewarded;
		}
		set {
			_myRewarded = value;
		}
	}

//5,	자신의 빙고 보상받은 수
	int _outCode;
	public int outCode {
		get {
			return _outCode;
		}
		set {
			_outCode = value;
		}
	}

//101,			0:정상, 1이상이면 보상없음.
	int _totalUser;
	public int totalUser {
		get {
			return _totalUser;
		}
		set {
			_totalUser = value;
		}
	}

//7,			빙고 참여자 수
	int _blackBingoReward;
	public int blackBingoReward {
		get {
			return _blackBingoReward;
		}
		set {
			_blackBingoReward = value;
		}
	}

//50,			블랙빙고 보상골드
	string _league;
	public string league {
		get {
			return _league;
		}
		set {
			_league = value;
		}
	}

//"kbo",
	int	_rewardType;
	public int rewardType {
		get {
			return _rewardType;
		}
		set {
			_rewardType = value;
		}
	}

//1,			1:확정골드, 2:퍼센트
	int _rewardCount;
	public int rewardCount {
		get {
			return _rewardCount;
		}
		set {
			_rewardCount = value;
		}
	}

//5,			max 보상유저 수
	string _useYn;
	public string useYn {
		get {
			return _useYn;
		}
		set {
			_useYn = value;
		}
	}

//"Y",
//	int _userBlackBingoReward;//0,			자신의 블랙빙고로 받은 골드
	string _outMessage;
	public string outMessage {
		get {
			return _outMessage;
		}
		set {
			_outMessage = value;
		}
	}

//"죄송합니다.빙고가 늦어 보상을 받을 수 없습니다.(5/5)",
	int _totalRewarded;
	public int totalRewarded {
		get {
			return _totalRewarded;
		}
		set {
			_totalRewarded = value;
		}
	}

//5,			총 보상 유저수			
	int _bingos;
	public int bingos {
		get {
			return _bingos;
		}
		set {
			_bingos = value;
		}
	}

//10,							bingos;//10,				자신의 빙고수
	int _rewardedCount;//5

	public int rewardedCount {
		get {
			return _rewardedCount;
		}
		set {
			_rewardedCount = value;
		}
	}
}
