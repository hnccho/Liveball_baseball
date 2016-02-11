using UnityEngine;
using System.Collections;

public class PlayInfo {
	int _gameSeq;

	public int gameSeq {
		get {
			return _gameSeq;
		}
		set {
			_gameSeq = value;
		}
	}

	int _gameHistorySeq;

	public int gameHistorySeq {
		get {
			return _gameHistorySeq;
		}
		set {
			_gameHistorySeq = value;
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

	int _playInningType;

	public int playInningType {
		get {
			return _playInningType;
		}
		set {
			_playInningType = value;
		}
	}

	int _activeHitter;

	public int activeHitter {
		get {
			return _activeHitter;
		}
		set {
			_activeHitter = value;
		}
	}

	int _activePitcher;

	public int activePitcher {
		get {
			return _activePitcher;
		}
		set {
			_activePitcher = value;
		}
	}

	int _awayScore;

	public int awayScore {
		get {
			return _awayScore;
		}
		set {
			_awayScore = value;
		}
	}

	int _homeScore;

	public int homeScore {
		get {
			return _homeScore;
		}
		set {
			_homeScore = value;
		}
	}

	int _outCount;

	public int outCount {
		get {
			return _outCount;
		}
		set {
			_outCount = value;
		}
	}

	int _ballCount;

	public int ballCount {
		get {
			return _ballCount;
		}
		set {
			_ballCount = value;
		}
	}

	int _strikeCount;

	public int strikeCount {
		get {
			return _strikeCount;
		}
		set {
			_strikeCount = value;
		}
	}

	int _base1st;

	public int base1st {
		get {
			return _base1st;
		}
		set {
			_base1st = value;
		}
	}

	int _base2nd;

	public int base2nd {
		get {
			return _base2nd;
		}
		set {
			_base2nd = value;
		}
	}

	int _base3rd;

	public int base3rd {
		get {
			return _base3rd;
		}
		set {
			_base3rd = value;
		}
	}

}
