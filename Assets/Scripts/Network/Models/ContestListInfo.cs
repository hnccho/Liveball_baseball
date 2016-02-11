using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ContestListInfo {
	int _contestSeq;

	public int contestSeq {
		get {
			return _contestSeq;
		}
		set {
			_contestSeq = value;
		}
	}

	int _metaSeq;
	
	public int metaSeq {
		get {
			return _metaSeq;
		}
		set {
			_metaSeq = value;
		}
	}

	int _gameSeq;
	
	public int gameSeq {
		get {
			return _gameSeq;
		}
		set {
			_gameSeq = value;
		}
	}

	int _featured;
	
	public int featured {
		get {
			return _featured;
		}
		set {
			_featured = value;
		}
	}

	int _guaranteed;
	
	public int guaranteed {
		get {
			return _guaranteed;
		}
		set {
			_guaranteed = value;
		}
	}

	int _contestReward;
	
	public int contestReward {
		get {
			return _contestReward;
		}
		set {
			_contestReward = value;
		}
	}

	int _entryFee;
	//MaxEntry
	public int entryFee {
		get {
			return _entryFee;
		}
		set {
			_entryFee = value;
		}
	}

	int _totalEntry;
	//MaxEntry
	public int totalEntry {
		get {
			return _totalEntry;
		}
		set {
			_totalEntry = value;
		}
	}
	int _contestType;
	// 1 :  50/50
	// 2 : ranking
	public int contestType {
		get {
			return _contestType;
		}
		set {
			_contestType = value;
		}
	}
	int _multiEntry;
	
	public int multiEntry {
		get {
			return _multiEntry;
		}
		set {
			_multiEntry = value;
		}
	}
	int _myPreset;
	// preset game have
	public int myPreset {
		get {
			return _myPreset;
		}
		set {
			_myPreset = value;
		}
	}

	int _totalPreset;
	// preset game have
	public int totalPreset {
		get {
			return _totalPreset;
		}
		set {
			_totalPreset = value;
		}
	}

	int _contestStatus;
	// preset game have
	public int contestStatus {
		get {
			return _contestStatus;
		}
		set {
			_contestStatus = value;
		}
	}

	string _contestName;
	
	public string contestName {
		get {
			return _contestName;
		}
		set {
			_contestName = value;
		}
	}
	string _creatTime;

	public string creatTime {
		get {
			return _creatTime;
		}
		set {
			_creatTime = value;
		}
	}
	int _contentsType;
	
	public int contentsType {
		get {
			return _contentsType;
		}
		set {
			_contentsType = value;
		}
	}
	string _gameName;
	
	public string gameName {
		get {
			return _gameName;
		}
		set {
			_gameName = value;
		}
	}
	string _startTime;
	
	public string startTime {
		get {
			return _startTime;
		}
		set {
			_startTime = value;
		}
	}
	int _rewardCount;
	
	public int rewardCount {
		get {
			return _rewardCount;
		}
		set {
			_rewardCount = value;
		}
	}
	int _rewardValue;
	
	public int rewardValue {
		get {
			return _rewardValue;
		}
		set {
			_rewardValue = value;
		}
	}
	int _rewardItem;
	
	public int rewardItem {
		get {
			return _rewardItem;
		}
		set {
			_rewardItem = value;
		}
	}
	string _itemName;
	
	public string itemName {
		get {
			return _itemName;
		}
		set {
			_itemName = value;
		}
	}
	string _totalReward;
	
	public string totalReward {
		get {
			return _totalReward;
		}
		set {
			_totalReward = value;
		}
	}
	string _aTeamScore;
	
	public string aTeamScore {
		get {
			return _aTeamScore;
		}
		set {
			_aTeamScore = value;
		}
	}
	string _hTeamScore;
	
	public string hTeamScore {
		get {
			return _hTeamScore;
		}
		set {
			_hTeamScore = value;
		}
	}
	string _aTeamName;
	
	public string aTeamName {
		get {
			return _aTeamName;
		}
		set {
			_aTeamName = value;
		}
	}
	string _hTeamName;
	
	public string hTeamName {
		get {
			return _hTeamName;
		}
		set {
			_hTeamName = value;
		}
	}

	List<RankRewardInfo> _rankReward;
	
	public List<RankRewardInfo> rankReward {
		get {
			return _rankReward;
		}
		set {
			_rankReward = value;
		}
	}

	public string GetRewardText(){
		string value = "";
		if(rankReward == null)
			return value;

		foreach(RankRewardInfo info in rankReward){
			value += info.rankDesc + " : " + info.rewardDesc + "\n";
		}
		return value;
	}
}
