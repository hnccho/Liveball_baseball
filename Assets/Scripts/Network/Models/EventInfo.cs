using UnityEngine;
using System.Collections;

public class EventInfo {
//gameId: 35003,
//// gameId		
	int _gameId;

	public int gameId {
		get {
			return _gameId;
		}
		set {
			_gameId = value;
		}
	}
//dateTime: "20160310130700",
//// 경기 시작시간	
	string _dateTime;

	public string dateTime {
		get {
			return _dateTime;
		}
		set {
			_dateTime = value;
		}
	}

//korDateTime: "20160311020700",
//// 경기시작시간(한국기준)
	string _korDateTime;

	public string korDateTime {
		get {
			return _korDateTime;
		}
		set {
			_korDateTime = value;
		}
	}
//awayTeam: "BOS",
//// 어웨이팀	
	string _awayTeam;
		
	public string awayTeam {
		get {
			return _awayTeam;
		}
		set {
			_awayTeam = value;
		}
	}
//homeTeam: "TOR",
//// 홈팀		
	string _homeTeam;
	
	public string homeTeam {
		get {
			return _homeTeam;
		}
		set {
			_homeTeam = value;
		}
	}
//awayTeamId: 25,
	int _awayTeamId;
	
	public int awayTeamId {
		get {
			return _awayTeamId;
		}
		set {
			_awayTeamId = value;
		}
	}
//homeTeamId: 3,
	int _homeTeamId;
	
	public int homeTeamId {
		get {
			return _homeTeamId;
		}
		set {
			_homeTeamId = value;
		}
	}
//stadiumId: 42,
	int _stadiumId;
	
	public int stadiumId {
		get {
			return _stadiumId;
		}
		set {
			_stadiumId = value;
		}
	}
//stadiumName: "Rogers Centre",
	string _stadiumName;
	
	public string stadiumName {
		get {
			return _stadiumName;
		}
		set {
			_stadiumName = value;
		}
	}
//// 경기장이름		
//inning: 0,			// 이닝			
	int _inning;
	
	public int inning {
		get {
			return _inning;
		}
		set {
			_inning = value;
		}
	}
//inningHalf: "T",
//// 이낭 초:'T', 말:'B'	
	string _inningHalf;
	
	public string inningHalf {
		get {
			return _inningHalf;
		}
		set {
			_inningHalf = value;
		}
	}
//awayTeamRuns: 0
//// 어웨이팀 현재 점수	
	int _awayTeamRuns;
	
	public int awayTeamRuns {
		get {
			return _awayTeamRuns;
		}
		set {
			_awayTeamRuns = value;
		}
	}
//homeTeamRuns: 0,
//// 홈팀 현재 점수		
	int _homeTeamRuns;
	
	public int homeTeamRuns {
		get {
			return _homeTeamRuns;
		}
		set {
			_homeTeamRuns = value;
		}
	}
//currentHitterId: 10000312,
	long _currentHitterId;

	public long currentHitterId {
		get {
			return _currentHitterId;
		}
		set {
			_currentHitterId = value;
		}
	}
//hitterName: "J. Votto",
	string _hitterName;

	public string hitterName {
		get {
			return _hitterName;
		}
		set {
			_hitterName = value;
		}
	}
//// 현재 타자 이름		
//hitterPhooto: "http://static.fantasydata.com/headshots/mlb/low-res/10000312.png",
	string _hitterPhoto;

	public string hitterPhoto {
		get {
			return _hitterPhoto;
		}
		set {
			_hitterPhoto = value;
		}
	}
//// 현재 타자 사진
//currentPitcherId: 10000102,
	long _currentPitcherId;

	public long currentPitcherId {
		get {
			return _currentPitcherId;
		}
		set {
			_currentPitcherId = value;
		}
	}
//pitcherName: "M. Gonzalez"
//// 현재 투수 이름		
	string _pitcherName;
	
	public string pitcherName {
		get {
			return _pitcherName;
		}
		set {
			_pitcherName = value;
		}
	}
//pitcherPhooto: "http://static.fantasydata.com/headshots/mlb/low-res/10000102.png",
//// 현재 투수 사진
	string _pitcherPhoto;
	
	public string pitcherPhoto {
		get {
			return _pitcherPhoto;
		}
		set {
			_pitcherPhoto = value;
		}
	}
//joinYN: 0,			// 0: 불참, 1:참석
	int _joinYN;

	public int joinYN {
		get {
			return _joinYN;
		}
		set {
			_joinYN = value;
		}
	}
}
