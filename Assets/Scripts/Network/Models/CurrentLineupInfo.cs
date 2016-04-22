using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurrentLineupInfo {
	List<ForecastInfo> _forecast;

	public List<ForecastInfo> forecast {
		get {
			return _forecast;
		}
		set {
			_forecast = value;
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

	AwayInfo _away;

	public AwayInfo away {
		get {
			return _away;
		}
		set {
			_away = value;
		}
	}

	HomeInfo _home;

	public HomeInfo home {
		get {
			return _home;
		}
		set {
			_home = value;
		}
	}

	int _inningNumber;

	public int inningNumber {
		get {
			return _inningNumber;
		}
		set {
			_inningNumber = value;
		}
	}

	string _inningHalf;

	public string inningHalf {
		get {
			return _inningHalf;
		}
		set {
			_inningHalf = value;
		}
	}

	int _homeTeamRuns;
	
	public int homeTeamRuns {
		get {
			return _homeTeamRuns;
		}
		set {
			_homeTeamRuns = value;
		}
	}
	
	int _awayTeamRuns;
	
	public int awayTeamRuns {
		get {
			return _awayTeamRuns;
		}
		set {
			_awayTeamRuns = value;
		}
	}

	public class AwayInfo{
		List<PlayerInfo> _hit;

		public List<PlayerInfo> hit {
			get {
				return _hit;
			}
			set {
				_hit = value;
			}
		}

		PlayerInfo _pit;

		public PlayerInfo pit {
			get {
				return _pit;
			}
			set {
				_pit = value;
			}
		}
	}

	public class HomeInfo{
		List<PlayerInfo> _hit;
		
		public List<PlayerInfo> hit {
			get {
				return _hit;
			}
			set {
				_hit = value;
			}
		}
		
		PlayerInfo _pit;
		
		public PlayerInfo pit {
			get {
				return _pit;
			}
			set {
				_pit = value;
			}
		}
	}

	public class ForecastInfo{
		int _battingOrder;
		public int battingOrder {
			get {
				return _battingOrder;
			}
			set {
				_battingOrder = value;
			}
		}

// 2,
		long _playerId;
		public long playerId {
			get {
				return _playerId;
			}
			set {
				_playerId = value;
			}
		}

// 10913,
		string _outYn;
		public string outYn {
			get {
				return _outYn;
			}
			set {
				_outYn = value;
			}
		}

// "Y",
		string _walkYn;
		public string walkYn {
			get {
				return _walkYn;
			}
			set {
				_walkYn = value;
			}
		}

// "",
		int _myValue;
		public int myValue {
			get {
				return _myValue;
			}
			set {
				_myValue = value;
			}
		}

// 1,
		int _inningNumber;// 1

		public int inningNumber {
			get {
				return _inningNumber;
			}
			set {
				_inningNumber = value;
			}
		}
	}
}
