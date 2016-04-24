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

//: 1,					
	int _bingoCount;
	public int bingoCount {
		get {
			return _bingoCount;
		}
		set {
			_bingoCount = value;
		}
	}

//: 1,
	int _totalRewardGold;
	public int totalRewardGold {
		get {
			return _totalRewardGold;
		}
		set {
			_totalRewardGold = value;
		}
	}

//: 5
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
}
