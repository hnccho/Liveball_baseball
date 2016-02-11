using UnityEngine;
using System.Collections;

public class GameTypeInfo {
	int _gameType;

	public int gameType {
		get {
			return _gameType;
		}
		set {
			_gameType = value;
		}
	}

	int _joinType;

	public int joinType {
		get {
			return _joinType;
		}
		set {
			_joinType = value;
		}
	}

	int _joinCount;

	public int joinCount {
		get {
			return _joinCount;
		}
		set {
			_joinCount = value;
		}
	}

	int _betPoint;

	public int betPoint {
		get {
			return _betPoint;
		}
		set {
			_betPoint = value;
		}
	}

	int _expectAmount;

	public int expectAmount {
		get {
			return _expectAmount;
		}
		set {
			_expectAmount = value;
		}
	}
}
