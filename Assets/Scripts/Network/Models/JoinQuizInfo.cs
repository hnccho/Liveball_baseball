using UnityEngine;
using System.Collections;

public class JoinQuizInfo {
	int memSeq;

	public int MemSeq {
		get {
			return memSeq;
		}
		set {
			memSeq = value;
		}
	}

	int gameSeq;

	public int GameSeq {
		get {
			return gameSeq;
		}
		set {
			gameSeq = value;
		}
	}

	int quizListSeq;

	public int QuizListSeq {
		get {
			return quizListSeq;
		}
		set {
			quizListSeq = value;
		}
	}

	int qzType;

	public int QzType {
		get {
			return qzType;
		}
		set {
			qzType = value;
		}
	}

	double useCardNo;

	public double UseCardNo {
		get {
			return useCardNo;
		}
		set {
			useCardNo = value;
		}
	}

	string betPoint;

	public string BetPoint {
		get {
			return betPoint;
		}
		set {
			betPoint = value;
		}
	}

	int item;

	public int Item {
		get {
			return item;
		}
		set {
			item = value;
		}
	}

	string selectValue;

	public string SelectValue {
		get {
			return selectValue;
		}
		set {
			selectValue = value;
		}
	}

	string extendValue;

	public string ExtendValue {
		get {
			return extendValue;
		}
		set {
			extendValue = value;
		}
	}
}
