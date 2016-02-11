using UnityEngine;
using System.Collections;

public class PlayerStatisticsInfo {
	string _rankType;
	public string _ankType {
		get {
			return _rankType;
		}
		set {
			_rankType = value;
		}
	}

// "AVG",
	int _rankSeq;
	public int rankSeq {
		get {
			return _rankSeq;
		}
		set {
			_rankSeq = value;
		}
	}

// 1,
	int _ranking;
	public int ranking {
		get {
			return _ranking;
		}
		set {
			_ranking = value;
		}
	}

// 1,
	int _playerSeq;
	public int playerSeq {
		get {
			return _playerSeq;
		}
		set {
			_playerSeq = value;
		}
	}

// 99606,
	string _playerName;
	public string playerName {
		get {
			return _playerName;
		}
		set {
			_playerName = value;
		}
	}

// "정성훈",
	string _teamCode;
	public string teamCode {
		get {
			return _teamCode;
		}
		set {
			_teamCode = value;
		}
	}

// "LG",
	string _teamName;
	public string teamName {
		get {
			return _teamName;
		}
		set {
			_teamName = value;
		}
	}

// "LG 트윈스",
	string _record;// "0.423"

	public string record {
		get {
			return _record;
		}
		set {
			_record = value;
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
}
