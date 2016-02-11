using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SposTeamInfo {
	SposSchedule _schedule;

	public SposSchedule schedule {
		get {
			return _schedule;
		}
		set {
			_schedule = value;
		}
	}
	SposOther _other;
	
	public SposOther other {
		get {
			return _other;
		}
		set {
			_other = value;
		}
	}
	SposMyTeam _myTeam;
	
	public SposMyTeam myTeam {
		get {
			return _myTeam;
		}
		set {
			_myTeam = value;
		}
	}
}
