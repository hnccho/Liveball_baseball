using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameResultInfo {
	List<TeamResultInfo> _team;

	public List<TeamResultInfo> team {
		get {
			return _team;
		}
		set {
			_team = value;
		}
	}

	public class TeamResultInfo{
	int _doublePlay;
		public int doublePlay {
			get {
				return _doublePlay;
			}
			set {
				_doublePlay = value;
			}
		}

//1,
	int _stolenBases;
		public int stolenBases {
			get {
				return _stolenBases;
			}
			set {
				_stolenBases = value;
			}
		}

//0,
	int _teamId;
		public int teamId {
			get {
				return _teamId;
			}
			set {
				_teamId = value;
			}
		}

//1001,
	int _singles;
		public int singles {
			get {
				return _singles;
			}
			set {
				_singles = value;
			}
		}

//6,
	int _homeNaway;
		public int homeNaway {
			get {
				return _homeNaway;
			}
			set {
				_homeNaway = value;
			}
		}

//2,
	int _hits;
		public int hits {
			get {
				return _hits;
			}
			set {
				_hits = value;
			}
		}

//9,
	int _walks;
		public int walks {
			get {
				return _walks;
			}
			set {
				_walks = value;
			}
		}

//3,
	int _homeRuns;
		public int homeRuns {
			get {
				return _homeRuns;
			}
			set {
				_homeRuns = value;
			}
		}

//1,
	int _err;
		public int err {
			get {
				return _err;
			}
			set {
				_err = value;
			}
		}

//0,
	int _triples;
		public int triples {
			get {
				return _triples;
			}
			set {
				_triples = value;
			}
		}

//0,
	int _doubles;
		public int doubles {
			get {
				return _doubles;
			}
			set {
				_doubles = value;
			}
		}

//2,
	int _hitByPitch;
		public int hitByPitch {
			get {
				return _hitByPitch;
			}
			set {
				_hitByPitch = value;
			}
		}

//0,
	int _strikeouts;//6

		public int strikeouts {
			get {
				return _strikeouts;
			}
			set {
				_strikeouts = value;
			}
		}
	}
}
