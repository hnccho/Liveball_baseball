using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SposDetailBoard {
	List<ScoreInfo> _awayScore;

	public List<ScoreInfo> awayScore {
		get {
			return _awayScore;
		}
		set {
			_awayScore = value;
		}
	}

	List<ScoreInfo> _homeScore;

	public List<ScoreInfo> homeScore {
		get {
			return _homeScore;
		}
		set {
			_homeScore = value;
		}
	}

	List<HEBInfo> _infoBoard;

	public List<HEBInfo> infoBoard {
		get {
			return _infoBoard;
		}
		set {
			_infoBoard = value;
		}
	}

	PlayInfo _play;

	public PlayInfo play {
		get {
			return _play;
		}
		set {
			_play = value;
		}
	}

	List<PlayerInfo> _player;

	public List<PlayerInfo> player {
		get {
			return _player;
		}
		set {
			_player = value;
		}
	}
}
