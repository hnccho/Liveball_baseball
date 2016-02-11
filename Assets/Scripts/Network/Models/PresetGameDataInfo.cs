using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PresetGameDataInfo {
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
