using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineupInfo {

	List<PlayerInfo> _lineup;

	public List<PlayerInfo> lineup {
		get {
			return _lineup;
		}
		set {
			_lineup = value;
		}
	}

	List<PlayerInfo> _pit;

	public List<PlayerInfo> pit {
		get {
			return _pit;
		}
		set {
			_pit = value;
		}
	}

	List<PlayerInfo> _hit;

	public List<PlayerInfo> hit {
		get {
			return _hit;
		}
		set {
			_hit = value;
		}
	}
}
