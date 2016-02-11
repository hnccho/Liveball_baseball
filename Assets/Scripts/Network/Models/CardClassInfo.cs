using UnityEngine;
using System.Collections;

public class CardClassInfo {
	int _classNo;

	public int classNo {
		get {
			return _classNo;
		}
		set {
			_classNo = value;
		}
	}

	int _maxLevel;

	public int maxLevel {
		get {
			return _maxLevel;
		}
		set {
			_maxLevel = value;
		}
	}

	string _classCode;

	public string classCode {
		get {
			return _classCode;
		}
		set {
			_classCode = value;
		}
	}

	int _classSeq;

	public int classSeq {
		get {
			return _classSeq;
		}
		set {
			_classSeq = value;
		}
	}

	string _className;

	public string className {
		get {
			return _className;
		}
		set {
			_className = value;
		}
	}

	int _availableHP;

	public int availableHP {
		get {
			return _availableHP;
		}
		set {
			_availableHP = value;
		}
	}
}
