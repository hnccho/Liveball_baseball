using UnityEngine;
using System.Collections;

public class AttendanceInfo {
	
	
	int _attendDay;
	
	public int attendDay {
		get {
			return _attendDay;
		}
		set {
			_attendDay = value;
		}
	}
	
	long _freeGold;
	
	public long freeGold {
		get {
			return _freeGold;
		}
		set {
			_freeGold = value;
		}
	}
	
	long _freeTicket;
	
	public long freeTicket {
		get {
			return _freeTicket;
		}
		set {
			_freeTicket = value;
		}
	}
	
	long _joinFreeGold;
	
	public long joinFreeGold {
		get {
			return _joinFreeGold;
		}
		set {
			_joinFreeGold = value;
		}
	}
	
	long _joinFreeTicket;
	
	public long joinFreeTicket {
		get {
			return _joinFreeTicket;
		}
		set {
			_joinFreeTicket = value;
		}
	}
}
