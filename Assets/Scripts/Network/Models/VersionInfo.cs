using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VersionInfo {

	int _osType;

	public int osType {
		get {
			return _osType;
		}
		set {
			_osType = value;
		}
	}

	int _serviceStatus;

	public int serviceStatus {
		get {
			return _serviceStatus;
		}
		set {
			_serviceStatus = value;
		}
	}

	string _verDesc;

	public string verDesc {
		get {
			return _verDesc;
		}
		set {
			_verDesc = value;
		}
	}

	string _appMessage;

	public string appMessage {
		get {
			return _appMessage;
		}
		set {
			_appMessage = value;
		}
	}

	string _recentVer;

	public string recentVer {
		get {
			return _recentVer;
		}
		set {
			_recentVer = value;
		}
	}

	string _supportVer;

	public string supportVer {
		get {
			return _supportVer;
		}
		set {
			_supportVer = value;
		}
	}

//	string _FILE;
//
//	public string FILE_PATH {
//		get {
//			return _FILE;
//		}
//		set {
//			_FILE = value;
//		}
//	}

	string _FILE;

	string _APPS;

	public string APPS {
		get {
			return _APPS;
		}
		set {
			_APPS = value;
		}
	}

	public string FILE {
		get {
			return _FILE;
		}
		set {
			_FILE = value;
		}
	}

	string _PATH;

	public string PATH {
		get {
			return _PATH;
		}
		set {
			_PATH = value;
		}
	}

	string _PORT;

	public string PORT {
		get {
			return _PORT;
		}
		set {
			_PORT = value;
		}
	}

	string _AUTH;

	public string AUTH {
		get {
			return _AUTH;
		}
		set {
			_AUTH = value;
		}
	}

	string _EXTR;

	public string EXTR {
		get {
			return _EXTR;
		}
		set {
			_EXTR = value;
		}
	}

	string _NOTE;

	public string NOTE {
		get {
			return _NOTE;
		}
		set {
			_NOTE = value;
		}
	}
}
