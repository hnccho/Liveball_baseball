using UnityEngine;
using System.Collections;

public class TeamScheduleInfo {
	string _awayTeam;
	public string awayTeam {
		get {
			return _awayTeam;
		}
		set {
			_awayTeam = value;
		}
	}

//"NC",
	string _korDateTime;
	public string korDateTime {
		get {
			return _korDateTime;
		}
		set {
			_korDateTime = value;
		}
	}

//"20160407183000",
	int _awayTeamId;
	public int awayTeamId {
		get {
			return _awayTeamId;
		}
		set {
			_awayTeamId = value;
		}
	}

//11001,
	string _dateTime;
	public string dateTime {
		get {
			return _dateTime;
		}
		set {
			_dateTime = value;
		}
	}

//"20160407053000",
	int _homeTeamId;
	public int homeTeamId {
		get {
			return _homeTeamId;
		}
		set {
			_homeTeamId = value;
		}
	}

//6002,
	int _gameId;
	public int gameId {
		get {
			return _gameId;
		}
		set {
			_gameId = value;
		}
	}

//20160028,
	string _day;
	public string day {
		get {
			return _day;
		}
		set {
			_day = value;
		}
	}

//"Thu",
	string _date;
	public string date {
		get {
			return _date;
		}
		set {
			_date = value;
		}
	}

//"20160407",
	string _homeTeam;//"DS"

	public string homeTeam {
		get {
			return _homeTeam;
		}
		set {
			_homeTeam = value;
		}
	}
}
