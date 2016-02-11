using UnityEngine;
using System.Collections;

public class SocketMsgInfo {
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

	int _type;

	public int type {
		get {
			return _type;
		}
		set {
			_type = value;
		}
	}

	int _code;

	public int code {
		get {
			return _code;
		}
		set {
			_code = value;
		}
	}

	NotiQuizInfo _data;

	public NotiQuizInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}

}
