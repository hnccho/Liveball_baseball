using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatistics {
	List<PlayerStatisticsInfo> _AVG;

	public List<PlayerStatisticsInfo> AVG {
		get {
			return _AVG;
		}
		set {
			_AVG = value;
		}
	}

	List<PlayerStatisticsInfo> _ERA;

	public List<PlayerStatisticsInfo> ERA {
		get {
			return _ERA;
		}
		set {
			_ERA = value;
		}
	}

	List<PlayerStatisticsInfo> _HR;

	public List<PlayerStatisticsInfo> HR {
		get {
			return _HR;
		}
		set {
			_HR = value;
		}
	}

	List<PlayerStatisticsInfo> _WIN;

	public List<PlayerStatisticsInfo> WIN {
		get {
			return _WIN;
		}
		set {
			_WIN = value;
		}
	}
}
