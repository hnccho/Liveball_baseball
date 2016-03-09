using UnityEngine;
using System.Collections;

public class LobbyInfo {
	int _myCardCount;

	public int myCardCount {
		get {
			return _myCardCount;
		}
		set {
			_myCardCount = value;
		}
	}

	int _upContestCount;

	public int upContestCount {
		get {
			return _upContestCount;
		}
		set {
			_upContestCount = value;
		}
	}

	int _myContestCount;

	public int myContestCount {
		get {
			return _myContestCount;
		}
		set {
			_myContestCount = value;
		}
	}

	int _contestCountS;

	public int contestCountS {
		get {
			return _contestCountS;
		}
		set {
			_contestCountS = value;
		}
	}

	int _contestCount50;

	public int contestCount50 {
		get {
			return _contestCount50;
		}
		set {
			_contestCount50 = value;
		}
	}

	int _contestCountR;

	public int contestCountR {
		get {
			return _contestCountR;
		}
		set {
			_contestCountR = value;
		}
	}
}
