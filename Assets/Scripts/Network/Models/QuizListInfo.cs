using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizListInfo {
	GameTypeInfo _gameType;

	public GameTypeInfo gameType {
		get {
			return _gameType;
		}
		set {
			_gameType = value;
		}
	}
	List<TeamInfo> _team;

	public List<TeamInfo> team {
		get {
			return _team;
		}
		set {
			_team = value;
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
	List<nextPlayerInfo> _nextPlayer;
	
	public List<nextPlayerInfo> nextPlayer {
		get {
			return _nextPlayer;
		}
		set {
			_nextPlayer = value;
		}
	}
	List<nowPlayerInfo> _nowPlayer;
	
	public List<nowPlayerInfo> nowPlayer {
		get {
			return _nowPlayer;
		}
		set {
			_nowPlayer = value;
		}
	}
	List<QuizInfo> _quiz;

	public List<QuizInfo> quiz {
		get {
			return _quiz;
		}
		set {
			_quiz = value;
		}
	}
}
