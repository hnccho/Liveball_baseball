using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rankinfo {
	
	private int _rankValue;
	public int rankValue {
		get {
			return _rankValue;
		}
		set {
			_rankValue = value;
		}
	}
	
	private int _rank;
	public int rank {
		get {
			return _rank;
		}
		set {
			_rank = value;
		}
	}
	
	private int _rankType;
	public int rankType {
		get {
			return _rankType;
		}
		set {
			_rankType = value;
		}
	}
	

	private List<Rankrankinfo> _ranking;
	public List<Rankrankinfo> ranking {
		get {
			return _ranking;
		}
		set {
			_ranking = value;
		}
	}
	private int _code;
	public int code {
		get {
			return _code;
		}
		set {
			_code = value;
		}
	}
	private string _rankDesc;
	public string rankDesc {
		get {
			return _rankDesc;
		}
		set {
			_rankDesc = value;
		}
	}

}
