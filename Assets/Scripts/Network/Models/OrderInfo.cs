using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrderInfo {
	int _templateQuizSeq;

	public int templateQuizSeq {
		get {
			return _templateQuizSeq;
		}
		set {
			_templateQuizSeq = value;
		}
	}

	int _quizType;

	public int quizType {
		get {
			return _quizType;
		}
		set {
			_quizType = value;
		}
	}

	int _orderSeq;

	public int orderSeq {
		get {
			return _orderSeq;
		}
		set {
			_orderSeq = value;
		}
	}

	int _referSeq;

	public int referSeq {
		get {
			return _referSeq;
		}
		set {
			_referSeq = value;
		}
	}

	string _ratio;

	public string ratio {
		get {
			return _ratio;
		}
		set {
			_ratio = value;
		}
	}

	string _orderCode;

	public string orderCode {
		get {
			return _orderCode;
		}
		set {
			_orderCode = value;
		}
	}

	string _description;

	public string description {
		get {
			return _description;
		}
		set {
			_description = value;
		}
	}
}
