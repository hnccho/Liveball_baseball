using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ContestListInfo {

	public static int FEATURED_ALL = 0;
	public static int FEATURED_SPECIAL = 1;
	public static int FEATURED_NONESP = 2;

	public static int TYPE_ALL = 0;
	public static int TYPE_FIFTY = 1;
	public static int TYPE_RANK = 2;

	public static int STATUS_ALL = 0;
	public static int STATUS_UP = 1;
	public static int STATUS_LIVE = 2;
	public static int STATUS_RECENT = 3;

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

	string _lineupName;

	public string lineupName {
		get {
			return _lineupName;
		}
		set {
			_lineupName = value;
		}
	}

	int _entrySeq;

	public int entrySeq {
		get {
			return _entrySeq;
		}
		set {
			_entrySeq = value;
		}
	}

	long _roundDate;

	public long roundDate {
		get {
			return _roundDate;
		}
		set {
			_roundDate = value;
		}
	}

	string _entryPlayers;

	public string entryPlayers {
		get {
			return _entryPlayers;
		}
		set {
			_entryPlayers = value;
		}
	}

	int _entryTicket;

	public int entryTicket {
		get {
			return _entryTicket;
		}
		set {
			_entryTicket = value;
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

	string _totalMileage;

	public string totalMileage {
		get {
			return _totalMileage;
		}
		set {
			_totalMileage = value;
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

	int _totalJoin;

	public int totalJoin {
		get {
			return _totalJoin;
		}
		set {
			_totalJoin = value;
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

	int _myRank;

	public int myRank {
		get {
			return _myRank;
		}
		set {
			_myRank = value;
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

	int _gameOverPlayers;

	public int gameOverPlayers {
		get {
			return _gameOverPlayers;
		}
		set {
			_gameOverPlayers = value;
		}
	}

	float _totalFantasy;

	public float totalFantasy {
		get {
			return _totalFantasy;
		}
		set {
			_totalFantasy = value;
		}
	}

	string _gameDayString;

	public string gameDayString {
		get {
			return _gameDayString;
		}
		set {
			_gameDayString = value;
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

	int _myEntry;

	public int myEntry {
		get {
			return _myEntry;
		}
		set {
			_myEntry = value;
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

	int _itemID;

	public int itemID {
		get {
			return _itemID;
		}
		set {
			_itemID = value;
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

	int _organ;

	public int organ {
		get {
			return _organ;
		}
		set {
			_organ = value;
		}
	}

	int _firstRewardRP;

	public int firstRewardRP {
		get {
			return _firstRewardRP;
		}
		set {
			_firstRewardRP = value;
		}
	}

	int _firstRewardGold;

	public int firstRewardGold {
		get {
			return _firstRewardGold;
		}
		set {
			_firstRewardGold = value;
		}
	}

	int _myRewardGold;

	public int myRewardGold {
		get {
			return _myRewardGold;
		}
		set {
			_myRewardGold = value;
		}
	}

	int _myRewardRP;

	public int myRewardRP {
		get {
			return _myRewardRP;
		}
		set {
			_myRewardRP = value;
		}
	}

	long _earnedPoint;

	public long earnedPoint {
		get {
			return _earnedPoint;
		}
		set {
			_earnedPoint = value;
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

	long _slot1;

	public long slot1 {
		get {
			return _slot1;
		}
		set {
			_slot1 = value;
		}
	}

	long _slot2;

	public long slot2 {
		get {
			return _slot2;
		}
		set {
			_slot2 = value;
		}
	}

	long _slot3;

	public long slot3 {
		get {
			return _slot3;
		}
		set {
			_slot3 = value;
		}
	}

	long _slot4;

	public long slot4 {
		get {
			return _slot4;
		}
		set {
			_slot4 = value;
		}
	}

	long _slot5;

	public long slot5 {
		get {
			return _slot5;
		}
		set {
			_slot5 = value;
		}
	}

	long _slot6;

	public long slot6 {
		get {
			return _slot6;
		}
		set {
			_slot6 = value;
		}
	}

	long _slot7;

	public long slot7 {
		get {
			return _slot7;
		}
		set {
			_slot7 = value;
		}
	}

	long _slot8;

	public long slot8 {
		get {
			return _slot8;
		}
		set {
			_slot8 = value;
		}
	}

	long _slot9;

	public long slot9 {
		get {
			return _slot9;
		}
		set {
			_slot9 = value;
		}
	}

	long _item1;

	public long item1 {
		get {
			return _item1;
		}
		set {
			_item1 = value;
		}
	}

	long _item2;

	public long item2 {
		get {
			return _item2;
		}
		set {
			_item2 = value;
		}
	}

	long _item3;

	public long item3 {
		get {
			return _item3;
		}
		set {
			_item3 = value;
		}
	}

	long _item4;

	public long item4 {
		get {
			return _item4;
		}
		set {
			_item4 = value;
		}
	}

	long _item5;

	public long item5 {
		get {
			return _item5;
		}
		set {
			_item5 = value;
		}
	}

	long _item6;

	public long item6 {
		get {
			return _item6;
		}
		set {
			_item6 = value;
		}
	}

	long _item7;

	public long item7 {
		get {
			return _item7;
		}
		set {
			_item7 = value;
		}
	}

	long _item8;

	public long item8 {
		get {
			return _item8;
		}
		set {
			_item8 = value;
		}
	}

	long _item9;

	public long item9 {
		get {
			return _item9;
		}
		set {
			_item9 = value;
		}
	}

	int _salaryLimit;

	public int salaryLimit {
		get {
			return _salaryLimit;
		}
		set {
			_salaryLimit = value;
		}
	}
}
