using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BingoInfo {

	Bingo _bingo;
	
	public Bingo bingo {
		get {
			return _bingo;
		}
		set {
			_bingo = value;
		}
	}
	
	List<BingoBoard> _bingoBoard;
	
	public List<BingoBoard> bingoBoard {
		get {
			return _bingoBoard;
		}
		set {
			_bingoBoard = value;
		}
	}

	public class Bingo{
		int _bingoId;
		public int bingoId {
			get {
				return _bingoId;
			}
			set {
				_bingoId = value;
			}
		}

//10,
		int _userId;
		public int userId {
			get {
				return _userId;
			}
			set {
				_userId = value;
			}
		}

//10001,
		int _bingos;
		public int bingos {
			get {
				return _bingos;
			}
			set {
				_bingos = value;
			}
		}

//0,
		int _gameId;
		public int gameId {
			get {
				return _gameId;
			}
			set {
				_gameId = value;
			}
		}

//45110,
		string _useYn;
		public string useYn {
			get {
				return _useYn;
			}
			set {
				_useYn = value;
			}
		}

//"Y",
		string _league;//"mlb

		public string league {
			get {
				return _league;
			}
			set {
				_league = value;
			}
		}
	}

	public class BingoBoard{
		int _tailSn;
		public int tailSn {
			get {
				return _tailSn;
			}
			set {
				_tailSn = value;
			}
		}

//1,
		string _playerName;
		public string playerName {
			get {
				return _playerName;
			}
			set {
				_playerName = value;
			}
		}

//"Lorenzo Cain",
		string _teamKorName;
		public string teamKorName {
			get {
				return _teamKorName;
			}
			set {
				_teamKorName = value;
			}
		}

//"",
		int _bingoId;
		public int bingoId {
			get {
				return _bingoId;
			}
			set {
				_bingoId = value;
			}
		}

//10,
		int _teamId;
		public int teamId {
			get {
				return _teamId;
			}
			set {
				_teamId = value;
			}
		}

//0,
		string _playerKorName;
		public string playerKorName {
			get {
				return _playerKorName;
			}
			set {
				_playerKorName = value;
			}
		}

//"",
		int _playerId;
		public int playerId {
			get {
				return _playerId;
			}
			set {
				_playerId = value;
			}
		}

//10000539,
		int _tailId;
		public int tailId {
			get {
				return _tailId;
			}
			set {
				_tailId = value;
			}
		}

//11,
		string _playerTeam;
		public string playerTeam {
			get {
				return _playerTeam;
			}
			set {
				_playerTeam = value;
			}
		}

//"KC",
		string _playerKorFullName;
		public string playerKorFullName {
			get {
				return _playerKorFullName;
			}
			set {
				_playerKorFullName = value;
			}
		}

//"",
		string _photoUrl;//"http://static.fantas

		public string photoUrl {
			get {
				return _photoUrl;
			}
			set {
				_photoUrl = value;
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

		string _quizCondition;

		public string quizCondition {
			get {
				return _quizCondition;
			}
			set {
				_quizCondition = value;
			}
		}
	}
}
