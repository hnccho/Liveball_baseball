using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SposOther {
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
	string _rankDiff;
	
	public string rankDiff {
		get {
			return _rankDiff;
		}
		set {
			_rankDiff = value;
		}
	}
	string _teamCode;
	
	public string teamCode {
		get {
			return _teamCode;
		}
		set {
			_teamCode = value;
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
	string _imagePath;
	
	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
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
	int _behind;
	
	public int behind {
		get {
			return _behind;
		}
		set {
			_behind = value;
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
	int _ranking;
	
	public int ranking {
		get {
			return _ranking;
		}
		set {
			_ranking = value;
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
	int _prevRanking;
	
	public int prevRanking {
		get {
			return _prevRanking;
		}
		set {
			_prevRanking = value;
		}
	}
	SposOtherPitcher _pitcher;
	
	public SposOtherPitcher pitcher {
		get {
			return _pitcher;
		}
		set {
			_pitcher = value;
		}
	}
	
}
