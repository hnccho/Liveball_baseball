using UnityEngine;
using System.Collections;

public class HEBInfo {
	string _countOfH;

	public string countOfH {
		get {
			return _countOfH;
		}
		set {
			_countOfH = value;
		}
	}

	string _countOfE;

	public string countOfE {
		get {
			return _countOfE;
		}
		set {
			_countOfE = value;
		}
	}

	string _countOfB;

	public string countOfB {
		get {
			return _countOfB;
		}
		set {
			_countOfB = value;
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
