using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurrentLineupInfo {
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
}
