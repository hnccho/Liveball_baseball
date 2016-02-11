using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ContestDataInfo {
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

	
}
