using UnityEngine;
using System.Collections;

public class ScoreInfo {

	int _gameSeq;

	public int gameSeq {
		get {
			return _gameSeq;
		}
		set {
			_gameSeq = value;
		}
	}

	int _playRound;

	public int playRound {
		get {
			return _playRound;
		}
		set {
			_playRound = value;
		}
	}

	string _score;

	public string score {
		get {
			return _score;
		}
		set {
			_score = value;
		}
	}

	int _teamSeq;

	public int teamSeq {
		get {
			return _teamSeq;
		}
		set {
			_teamSeq = value;
		}
	}

	string _teamName;

	public string teamName {
		get {
			return _teamName;
		}
		set {
			_teamName = value;
		}
	}

	int _homeNAwayType;
	
	public int homeNAwayType {
		get {
			return _homeNAwayType;
		}
		set {
			_homeNAwayType = value;
		}
	}
}
