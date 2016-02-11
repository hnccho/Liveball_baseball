using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizInfo {
	public bool mShowInningFlag;

	List<QuizRespInfo> _resp;

	public List<QuizRespInfo> resp {
		get {
			return _resp;
		}
		set {
			_resp = value;
		}
	}

	int _gameSeq;

	public int gameSeq {
		get {
			return _gameSeq;
		}
		set {
			_gameSeq = value;
		}
	}
	int _lineUp;
	
	public int lineUp {
		get {
			return _lineUp;
		}
		set {
			_lineUp = value;
		}
	}
	int _quizListSeq;

	public int quizListSeq {
		get {
			return _quizListSeq;
		}
		set {
			_quizListSeq = value;
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

	int _quizResultSeq;

	public int quizResultSeq {
		get {
			return _quizResultSeq;
		}
		set {
			_quizResultSeq = value;
		}
	}

	int _gameRound;

	public int gameRound {
		get {
			return _gameRound;
		}
		set {
			_gameRound = value;
		}
	}

	int _inningType;

	public int inningType {
		get {
			return _inningType;
		}
		set {
			_inningType = value;
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

	string _subTitle;

	public string subTitle {
		get {
			return _subTitle;
		}
		set {
			_subTitle = value;
		}
	}

	int _countValue;
	public int countValue {
		get {
			return _countValue;
		}
		set {
			_countValue = value;
		}
	}

// 15,				// 타이머 시간(초)
	string _startValue;
	public string startValue {
		get {
			return _startValue;
		}
		set {
			_startValue = value;
		}
	}

// "0",			
	string _defaultValue;
	public string defaultValue {
		get {
			return _defaultValue;
		}
		set {
			_defaultValue = value;
		}
	}

// "0",
	string _maxValue;
	public string maxValue {
		get {
			return _maxValue;
		}
		set {
			_maxValue = value;
		}
	}

// "10",
	string _valueInterval;
	public string valueInterval {
		get {
			return _valueInterval;
		}
		set {
			_valueInterval = value;
		}
	}

// "1",
	int _multipleYn;
	public int multipleYn {
		get {
			return _multipleYn;
		}
		set {
			_multipleYn = value;
		}
	}

// 1,				// x배수 아이템 적용
	int _betShieldYn;
	public int betShieldYn {
		get {
			return _betShieldYn;
		}
		set {
			_betShieldYn = value;
		}
	}

// 1,				// 베팅쉴드 적용
	int _comboShieldYn;
	public int comboShieldYn {
		get {
			return _comboShieldYn;
		}
		set {
			_comboShieldYn = value;
		}
	}

// 1,			// 콤보쉴드 적용
	int _stealBaseYn;
	public int stealBaseYn {
		get {
			return _stealBaseYn;
		}
		set {
			_stealBaseYn = value;
		}
	}

// 0,				// 도루와 적용(현제 사용하지 않음.)
	int _softballYn;
	public int softballYn {
		get {
			return _softballYn;
		}
		set {
			_softballYn = value;
		}
	}

// 1,				// 소프트볼 적용
	string _typeCode;
	public string typeCode {
		get {
			return _typeCode;
		}
		set {
			_typeCode = value;
		}
	}

// "BB_QZD_FORECAST",
	string _quizTitle;
	public string quizTitle {
		get {
			return _quizTitle;
		}
		set {
			_quizTitle = value;
		}
	}

// "다음 타석의 결과를 예측해 보세요.",
	string _registTime;
	public string registTime {
		get {
			return _registTime;
		}
		set {
			_registTime = value;
		}
	}

// "20140516102521",
	string _quizValue;
	public string quizValue {
		get {
			return _quizValue;
		}
		set {
			_quizValue = value;
		}
	}

// "",				// 어웨이에 해당하는 정답값
	string _quizValueExtend;
	public string quizValueExtend {
		get {
			return _quizValueExtend;
		}
		set {
			_quizValueExtend = value;
		}
	}

// "",		// 홈에 해당하는 정답값
	string _respValue;
	public string respValue {
		get {
			return _respValue;
		}
		set {
			_respValue = value;
		}
	}

// "",				// 어웨이에 해당하는 내가 선택한 값
	string _respValueExtend;
	public string respValueExtend {
		get {
			return _respValueExtend;
		}
		set {
			_respValueExtend = value;
		}
	}

// "",		// 홈에 해당하는 내가 선택한 값
	int _respStatus;
	public int respStatus {
		get {
			return _respStatus;
		}
		set {
			_respStatus = value;
		}
	}

// 0,				// 0:미참여, 1:임시, 2:완료
	string _betPoint;
	public string betPoint {
		get {
			return _betPoint;
		}
		set {
			_betPoint = value;
		}
	}

// "",				// 베팅포인트(골든볼)
	int _useItemSeq;
	public int useItemSeq {
		get {
			return _useItemSeq;
		}
		set {
			_useItemSeq = value;
		}
	}

//1000				// 사용한 아이템 Seq (default: 1000)
	string _rewardDividend;
	public string rewardDividend {
		get {
			return _rewardDividend;
		}
		set {
			_rewardDividend = value;
		}
	}

// "0",		// 예상 보상포인트, 결과가 나오기 전의 예상포인
	int _closeYN;
	public int closeYN {
		get {
			return _closeYN;
		}
		set {
			_closeYN = value;
		}
	}

// 0,					// 0:미종료, 1:종료 (퀴즈)
	int _isFixedPoint;
	public int isFixedPoint {
		get {
			return _isFixedPoint;
		}
		set {
			_isFixedPoint = value;
		}
	}

// 0,			// 고정배당 방식 퀴즈
	int _isBetPoint;
	public int isBetPoint {
		get {
			return _isBetPoint;
		}
		set {
			_isBetPoint = value;
		}
	}

// 1,				// 베팅풀배당 방식 퀴즈
	int _timeOver;
	public int timeOver {
		get {
			return _timeOver;
		}
		set {
			_timeOver = value;
		}
	}

// 1,				// 베팅가능시간 초과 유무
	int _isRefund;
	public int isRefund {
		get {
			return _isRefund;
		}
		set {
			_isRefund = value;
		}
	}

// 0,
	int _playerNumber;
	public int playerNumber {
		get {
			return _playerNumber;
		}
		set {
			_playerNumber = value;
		}
	}

// 1,
	string _playerName;
	public string playerName {
		get {
			return _playerName;
		}
		set {
			_playerName = value;
		}
	}

// "조동화",
	int _teamSeq;
	public int teamSeq {
		get {
			return _teamSeq;
		}
		set {
			_teamSeq = value;
		}
	}

// 8,					// 팀 Seq
	string _teamName;
	public string teamName {
		get {
			return _teamName;
		}
		set {
			_teamName = value;
		}
	}

// "두산 베어스",		// 팀 이름
	string _teamColor;
	public string teamColor {
		get {
			return _teamColor;
		}
		set {
			_teamColor = value;
		}
	}

	private string _imagePath;
	
	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
		}
	}

// "#2c3256",		// 팀 컬러
	string _imageName;
	public string imageName {
		get {
			return _imageName;
		}
		set {
			_imageName = value;
		}
	}

// "baseball_SK_71848.jpg",
	int _isCancel;
	public int isCancel {
		get {
			return _isCancel;
		}
		set {
			_isCancel = value;
		}
	}

// 0,
	string _resultMsg;
	public string resultMsg {
		get {
			return _resultMsg;
		}
		set {
			_resultMsg = value;
		}
	}

// "adfasdfasdfasfd",
	string _rewardPoint;
	public string rewardPoint {
		get {
			return _rewardPoint;
		}
		set {
			_rewardPoint = value;
		}
	}

// "",			// 보상포인트(골든볼)
	int _isBetPool;
	public int isBetPool {
		get {
			return _isBetPool;
		}
		set {
			_isBetPool = value;
		}
	}

// 0,				// 베팅풀방식
	string _hitAvg;
	public string hitAvg {
		get {
			return _hitAvg;
		}
		set {
			_hitAvg = value;
		}
	}
	string _hitH;
	public string hitH {
		get {
			return _hitH;
		}
		set {
			_hitH = value;
		}
	}
	string _hit2B;
	public string hit2B {
		get {
			return _hit2B;
		}
		set {
			_hit2B = value;
		}
	}
	string _hitHr;
	public string hitHr {
		get {
			return _hitHr;
		}
		set {
			_hitHr = value;
		}
	}

	string _hitBB;
	public string hitBB {
		get {
			return _hitBB;
		}
		set {
			_hitBB = value;
		}
	}
	string _hitSO;
	public string hitSO {
		get {
			return _hitSO;
		}
		set {
			_hitSO = value;
		}
	}
	List<OrderInfo> _order;

	public List<OrderInfo> order {
		get {
			return _order;
		}
		set {
			_order = value;
		}
	}
}
