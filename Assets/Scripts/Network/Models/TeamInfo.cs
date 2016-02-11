using UnityEngine;
using System.Collections;

public class TeamInfo {
	int _gameSeq;

	public int gameSeq {
		get {
			return _gameSeq;
		}
		set {
			_gameSeq = value;
		}
	}

	int _scheduleSeq;

	public int scheduleSeq {
		get {
			return _scheduleSeq;
		}
		set {
			_scheduleSeq = value;
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

	int _score;

	public int score {
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

	string _teamColor;

	public string teamColor {
		get {
			return _teamColor;
		}
		set {
			_teamColor = value;
		}
	}

	private string _imagePath;
	
	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
		}
	}

	string _imageName;

	public string imageName {
		get {
			return _imageName;
		}
		set {
			_imageName = value;
		}
	}

	int _imageWidth;

	public int imageWidth {
		get {
			return _imageWidth;
		}
		set {
			_imageWidth = value;
		}
	}

	int _imageHeight;

	public int imageHeight {
		get {
			return _imageHeight;
		}
		set {
			_imageHeight = value;
		}
	}

	int _homeNawayType;

	public int homeNawayType {
		get {
			return _homeNawayType;
		}
		set {
			_homeNawayType = value;
		}
	}

	string _homeNaway;

	public string homeNaway {
		get {
			return _homeNaway;
		}
		set {
			_homeNaway = value;
		}
	}

	int _dateFlag;

	public int dateFlag {
		get {
			return _dateFlag;
		}
		set {
			_dateFlag = value;
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

	int _countWin;

	public int countWin {
		get {
			return _countWin;
		}
		set {
			_countWin = value;
		}
	}

	int _countLose;

	public int countLose {
		get {
			return _countLose;
		}
		set {
			_countLose = value;
		}
	}

	int _countDraw;

	public int countDraw {
		get {
			return _countDraw;
		}
		set {
			_countDraw = value;
		}
	}

	int _ranking;

	public int ranking {
		get {
			return _ranking;
		}
		set {
			_ranking = value;
		}
	}

	string _winRate;

	public string winRate {
		get {
			return _winRate;
		}
		set {
			_winRate = value;
		}
	}

	float _behind;

	public float behind {
		get {
			return _behind;
		}
		set {
			_behind = value;
		}
	}

	int _prevRanking;

	public int prevRanking {
		get {
			return _prevRanking;
		}
		set {
			_prevRanking = value;
		}
	}

	string _rankDiff;

	public string rankDiff {
		get {
			return _rankDiff;
		}
		set {
			_rankDiff = value;
		}
	}
}