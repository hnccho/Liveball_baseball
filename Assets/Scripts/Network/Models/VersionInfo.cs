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

	string _FILE_PATH;

	public string FILE_PATH {
		get {
			return _FILE_PATH;
		}
		set {
			_FILE_PATH = value;
		}
	}

	string _FILE_SVR;

	string _APPS_SVR;

	public string APPS_SVR {
		get {
			return _APPS_SVR;
		}
		set {
			_APPS_SVR = value;
		}
	}

	public string FILE_SVR {
		get {
			return _FILE_SVR;
		}
		set {
			_FILE_SVR = value;
		}
	}

	string _GAME_SVR;

	public string GAME_SVR {
		get {
			return _GAME_SVR;
		}
		set {
			_GAME_SVR = value;
		}
	}

	string _GAME_PORT;

	public string GAME_PORT {
		get {
			return _GAME_PORT;
		}
		set {
			_GAME_PORT = value;
		}
	}

	string _AUTH_SVR;

	public string AUTH_SVR {
		get {
			return _AUTH_SVR;
		}
		set {
			_AUTH_SVR = value;
		}
	}

	string _EXT_SVR;

	public string EXT_SVR {
		get {
			return _EXT_SVR;
		}
		set {
			_EXT_SVR = value;
		}
	}
}
