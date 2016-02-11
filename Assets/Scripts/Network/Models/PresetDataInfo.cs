using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PresetDataInfo {
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
	int _presetSeq;
	
	public int presetSeq {
		get {
			return _presetSeq;
		}
		set {
			_presetSeq = value;
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

	int _rewardCount;
	// preset game have
	public int rewardCount {
		get {
			return _rewardCount;
		}
		set {
			_rewardCount = value;
		}
	}
	
	int _rewordScore;
	// preset game have
	public int rewordScore {
		get {
			return _rewordScore;
		}
		set {
			_rewordScore = value;
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
	int _myRank;
	
	public int myRank {
		get {
			return _myRank;
		}
		set {
			_myRank = value;
		}
	}
	
}
