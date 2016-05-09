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
		int _msgCount;

		public int msgCount {
			get {
				return _msgCount;
			}
			set {
				_msgCount = value;
			}
		}

		int _totalRewarded;

		public int totalRewarded {
			get {
				return _totalRewarded;
			}
			set {
				_totalRewarded = value;
			}
		}

		int _rewardCount;//can get reward max

		public int rewardCount {
			get {
				return _rewardCount;
			}
			set {
				_rewardCount = value;
			}
		}

		int _rewardedCount;

		public int rewardedCount {
			get {
				return _rewardedCount;
			}
			set {
				_rewardedCount = value;
			}
		}

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

		int _powerGauge;

		public int powerGauge {
			get {
				return _powerGauge;
			}
			set {
				_powerGauge = value;
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
		string _walkYn;

		public string walkYn {
			get {
				return _walkYn;
			}
			set {
				_walkYn = value;
			}
		}

		string _outYn;

		public string outYn {
			get {
				return _outYn;
			}
			set {
				_outYn = value;
			}
		}

		string _successYn;

		public string successYn {
			get {
				return _successYn;
			}
			set {
				_successYn = value;
			}
		}

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

		int _powerCheck;

		public int powerCheck {
			get {
				return _powerCheck;
			}
			set {
				_powerCheck = value;
			}
		}

//"",
		long _playerId;
		public long playerId {
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

		string _quizConditionKor;
		
		public string quizConditionKor {
			get {
				return _quizConditionKor;
			}
			set {
				_quizConditionKor = value;
			}
		}
	}
}
