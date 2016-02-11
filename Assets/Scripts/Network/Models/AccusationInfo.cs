using UnityEngine;
using System.Collections;

public class AccusationInfo {
	string boardNum;

	public string BoardNum {
		get {
			return boardNum;
		}
		set {
			boardNum = value;
		}
	}

	string contentNum;

	public string ContentNum {
		get {
			return contentNum;
		}
		set {
			contentNum = value;
		}
	}

	string type;

	public string Type {
		get {
			return type;
		}
		set {
			type = value;
		}
	}

	string msg;

	public string Msg {
		get {
			return msg;
		}
		set {
			msg = value;
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

	int _outCode;

	public int outCode {
		get {
			return _outCode;
		}
		set {
			_outCode = value;
		}
	}
}
