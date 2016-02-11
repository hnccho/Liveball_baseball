using UnityEngine;
using System.Collections;

public class RankRewardInfo {
	int _rewardItem;
	public int rewardItem {
		get {
			return _rewardItem;
		}
		set {
			_rewardItem = value;
		}
	}

//: 1,
	string _totalReward;
	public string totalReward {
		get {
			return _totalReward;
		}
		set {
			_totalReward = value;
		}
	}

//: "1,750,000",
	string _itemName;
	public string itemName {
		get {
			return _itemName;
		}
		set {
			_itemName = value;
		}
	}

//: "마일리지",
	int _sRank;
	public int sRank {
		get {
			return _sRank;
		}
		set {
			_sRank = value;
		}
	}

//: 1,
	int _eRank;
	public int eRank {
		get {
			return _eRank;
		}
		set {
			_eRank = value;
		}
	}

//: 1,
	string _rewardDesc;
	public string rewardDesc {
		get {
			return _rewardDesc;
		}
		set {
			_rewardDesc = value;
		}
	}

//: "1,750,000 마일리지",
	string _unit;
	public string unit {
		get {
			return _unit;
		}
		set {
			_unit = value;
		}
	}

//: "M",
	string _rankDesc;//: "1위"

	public string rankDesc {
		get {
			return _rankDesc;
		}
		set {
			_rankDesc = value;
		}
	}
}
