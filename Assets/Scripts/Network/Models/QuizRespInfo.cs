using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizRespInfo {
	int _gameSeq;

	public int gameSeq {
		get {
			return _gameSeq;
		}
		set {
			_gameSeq = value;
		}
	}

	int _gameQuizSeq;

	public int gameQuizSeq {
		get {
			return _gameQuizSeq;
		}
		set {
			_gameQuizSeq = value;
		}
	}

	int _templateQuizSeq;

	public int templateQuizSeq {
		get {
			return _templateQuizSeq;
		}
		set {
			_templateQuizSeq = value;
		}
	}

	int _memSeq;

	public int memSeq {
		get {
			return _memSeq;
		}
		set {
			_memSeq = value;
		}
	}

	double _useCardNo;

	public double useCardNo {
		get {
			return _useCardNo;
		}
		set {
			_useCardNo = value;
		}
	}

	int _respStatus;

	public int respStatus {
		get {
			return _respStatus;
		}
		set {
			_respStatus = value;
		}
	}

	int _useItemSeq;

	public int useItemSeq {
		get {
			return _useItemSeq;
		}
		set {
			_useItemSeq = value;
		}
	}

	int _betPoint;

	public int betPoint {
		get {
			return _betPoint;
		}
		set {
			_betPoint = value;
		}
	}

	int _qzType;

	public int qzType {
		get {
			return _qzType;
		}
		set {
			_qzType = value;
		}
	}

	int _expectRewardPoint;

	public int expectRewardPoint {
		get {
			return _expectRewardPoint;
		}
		set {
			_expectRewardPoint = value;
		}
	}

	string _respValue;

	public string respValue {
		get {
			return _respValue;
		}
		set {
			_respValue = value;
		}
	}

	string _respValueExtend;

	public string respValueExtend {
		get {
			return _respValueExtend;
		}
		set {
			_respValueExtend = value;
		}
	}

	float _selectRatio;

	public float selectRatio {
		get {
			return _selectRatio;
		}
		set {
			_selectRatio = value;
		}
	}

	float _addRewardRate;

	public float addRewardRate {
		get {
			return _addRewardRate;
		}
		set {
			_addRewardRate = value;
		}
	}
}