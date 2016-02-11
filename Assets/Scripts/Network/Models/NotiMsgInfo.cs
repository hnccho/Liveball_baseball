using UnityEngine;
using System.Collections;

public class NotiMsgInfo {
	string _title;

	public string title {
		get {
			return _title;
		}
		set {
			_title = value;
		}
	}

	string _msg;

	public string msg {
		get {
			return _msg;
		}
		set {
			_msg = value;
		}
	}

	string _type;

	public string type {
		get {
			return _type;
		}
		set {
			_type = value;
		}
	}

	string _code;

	public string code {
		get {
			return _code;
		}
		set {
			_code = value;
		}
	}

	NotiQuizInfo _info;

	public NotiQuizInfo info {
		get {
			return _info;
		}
		set {
			_info = value;
		}
	}

}
