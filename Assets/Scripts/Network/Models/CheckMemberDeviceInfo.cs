using UnityEngine;
using System.Collections;

public class CheckMemberDeviceInfo {
	int _memSeq;

	public int memSeq {
		get {
			return _memSeq;
		}
		set {
			_memSeq = value;
		}
	}

	int _outCode;

	public int outCode {
		get {
			return _outCode;
		}
		set {
			_outCode = value;
		}
	}

	string _memPIN;

	public string memPIN {
		get {
			return _memPIN;
		}
		set {
			_memPIN = value;
		}
	}

	string _useNotify;

	public string useNotify {
		get {
			return _useNotify;
		}
		set {
			_useNotify = value;
		}
	}

	string _outMessage;

	public string outMessage {
		get {
			return _outMessage;
		}
		set {
			_outMessage = value;
		}
	}

	int _isBlackList;

	public int isBlackList {
		get {
			return _isBlackList;
		}
		set {
			_isBlackList = value;
		}
	}

	string _memberName;

	public string memberName {
		get {
			return _memberName;
		}
		set {
			_memberName = value;
		}
	}

	int _registType;

	public int registType {
		get {
			return _registType;
		}
		set {
			_registType = value;
		}
	}

	int _tutorialYn;

	public int tutorialYn {
		get {
			return _tutorialYn;
		}
		set {
			_tutorialYn = value;
		}
	}

	long _memberNo;

	public long memberNo {
		get {
			return _memberNo;
		}
		set {
			_memberNo = value;
		}
	}

	string _memUID;

	public string memUID {
		get {
			return _memUID;
		}
		set {
			_memUID = value;
		}
	}
}
