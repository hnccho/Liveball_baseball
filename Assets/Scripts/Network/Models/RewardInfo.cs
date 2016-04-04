using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewardInfo {
	int _point;
	public int point {
		get {
			return _point;
		}
		set {
			_point = value;
		}
	}

//180,
	int _rank;
	public int rank {
		get {
			return _rank;
		}
		set {
			_rank = value;
		}
	}

//6,
	int _reward;
	public int reward {
		get {
			return _reward;
		}
		set {
			_reward = value;
		}
	}

//3004,
	long _item;
	public long item {
		get {
			return _item;
		}
		set {
			_item = value;
		}
	}

//2110233001,
	int _gold;
	public int gold {
		get {
			return _gold;
		}
		set {
			_gold = value;
		}
	}

//240,
	int _cid;
	public int cid {
		get {
			return _cid;
		}
		set {
			_cid = value;
		}
	}

//17,
	long _mcid;//200803004

	public long mcid {
		get {
			return _mcid;
		}
		set {
			_mcid = value;
		}
	}
}
