using UnityEngine;
using System.Collections;

public class NotiQuizInfo {
	string _gameSeq;
	
	public string gameSeq {
		get {
			return _gameSeq;
		}
		set {
			_gameSeq = value;
		}
	}
	
	string _scheduleSeq;
	
	public string scheduleSeq {
		get {
			return _scheduleSeq;
		}
		set {
			_scheduleSeq = value;
		}
	}
	
	string _quizListSeq;
	
	public string quizListSeq {
		get {
			return _quizListSeq;
		}
		set {
			_quizListSeq = value;
		}
	}
	
	string _quiz;
	
	public string quiz {
		get {
			return _quiz;
		}
		set {
			_quiz = value;
		}
	}
	
	string _play;
	
	public string play {
		get {
			return _play;
		}
		set {
			_play = value;
		}
	}
	
	string _inning;
	
	public string inning {
		get {
			return _inning;
		}
		set {
			_inning = value;
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
	
	string _time;
	
	public string time {
		get {
			return _time;
		}
		set {
			_time = value;
		}
	}

	string _result;

	public string result {
		get {
			return _result;
		}
		set {
			_result = value;
		}
	}
	
	string _half;
	
	public string half {
		get {
			return _half;
		}
		set {
			_half = value;
		}
	}
	
	long _playerId;
	
	public long playerId {
		get {
			return _playerId;
		}
		set {
			_playerId = value;
		}
	}
	
	int _gameId;
	
	public int gameId {
		get {
			return _gameId;
		}
		set {
			_gameId = value;
		}
	}

	int _value;

	public int value {
		get {
			return _value;
		}
		set {
			_value = value;
		}
	}

	string _status;

	public string status {
		get {
			return _status;
		}
		set {
			_status = value;
		}
	}

	string _inningState;

	public string inningState {
		get {
			return _inningState;
		}
		set {
			_inningState = value;
		}
	}
}
