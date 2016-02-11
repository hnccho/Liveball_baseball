using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScheduleInfo {
	public const int GAME_READY = 0;
	public const int GAME_PLAYING = 1;
	public const int GAME_ENDED = 2;

	private int _contentsSeq;
	public int contentsSeq {
		get {
			return _contentsSeq;
		}
		set {
			_contentsSeq = value;
		}
	}

	private int _scheduleSeq;
	public int scheduleSeq {
		get {
			return _scheduleSeq;
		}
		set {
			_scheduleSeq = value;
		}
	}

	private int _channelSeq;
	public int channelSeq {
		get {
			return _channelSeq;
		}
		set {
			_channelSeq = value;
		}
	}

	private int _gameSeq;
	public int gameSeq {
		get {
			return _gameSeq;
		}
		set {
			_gameSeq = value;
		}
	}

	private int _gameStatus;
	public int gameStatus {
		get {
			return _gameStatus;
		}
		set {
			_gameStatus = value;
		}
	}

	
	private int _gameType;
	public int gameType {
		get {
			return _gameType;
		}
		set {
			_gameType = value;
		}
	}

 //실시간예측가능여부.	
	private string _channelName;

	public string channelName {
		get {
			return _channelName;
		}
		set {
			_channelName = value;
		}
	}

	private int _dateFlag;

	public int dateFlag {
		get {
			return _dateFlag;
		}
		set {
			_dateFlag = value;
		}
	}

	private int _contentsType;

	public int contentsType {
		get {
			return _contentsType;
		}
		set {
			_contentsType = value;
		}
	}

	private string _title;

	public string title {
		get {
			return _title;
		}
		set {
			_title = value;
		}
	}

	private string _subTitle;

	public string subTitle {
		get {
			return _subTitle;
		}
		set {
			_subTitle = value;
		}
	}

	private string _contentsCode;

	public string contentsCode {
		get {
			return _contentsCode;
		}
		set {
			_contentsCode = value;
		}
	}

	private string _channelCode;

	public string channelCode {
		get {
			return _channelCode;
		}
		set {
			_channelCode = value;
		}
	}

	private string _startDate;

	public string startDate {
		get {
			return _startDate;
		}
		set {
			_startDate = value;
		}
	}

	private string _startTime;

	public string startTime {
		get {
			return _startTime;
		}
		set {
			_startTime = value;
		}
	}

	private string _endTime;

	public string endTime {
		get {
			return _endTime;
		}
		set {
			_endTime = value;
		}
	}

	private int _screenShotCount;

	public int screenShotCount {
		get {
			return _screenShotCount;
		}
		set {
			_screenShotCount = value;
		}
	}

	private int _tagCount;

	public int tagCount {
		get {
			return _tagCount;
		}
		set {
			_tagCount = value;
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

	private string _imageName;

	public string imageName {
		get {
			return _imageName;
		}
		set {
			_imageName = value;
		}
	}

	private string _onairDay;

	public string onairDay {
		get {
			return _onairDay;
		}
		set {
			_onairDay = value;
		}
	}

	private int _emoticonGroupSeq;

	public int emoticonGroupSeq {
		get {
			return _emoticonGroupSeq;
		}
		set {
			_emoticonGroupSeq = value;
		}
	}

	private int _onAir;

	public int onAir {
		get {
			return _onAir;
		}
		set {
			_onAir = value;
		}
	}

	private int _numberOfContents;

	public int numberOfContents {
		get {
			return _numberOfContents;
		}
		set {
			_numberOfContents = value;
		}
	}

	private string _contentsTypeCode;

	public string contentsTypeCode {
		get {
			return _contentsTypeCode;
		}
		set {
			_contentsTypeCode = value;
		}
	}

	private string _startHour;

	public string startHour {
		get {
			return _startHour;
		}
		set {
			_startHour = value;
		}
	}

	private string _startMinute;

	public string startMinute {
		get {
			return _startMinute;
		}
		set {
			_startMinute = value;
		}
	}

	private string _interActive;

	public string interActive {
		get {
			return _interActive;
		}
		set {
			_interActive = value;
		}
	}

	private string _bcastChannel;

	public string bcastChannel {
		get {
			return _bcastChannel;
		}
		set {
			_bcastChannel = value;
		}
	}

	private List<ExtendInfo> _extend;
	public List<ExtendInfo> extend {
		get {
			return _extend;
		}
		set {
			_extend = value;
		}
	}

	
	private string _bettingTotal;

	public string bettingTotal {
		get {
			return _bettingTotal;
		}
		set {
			_bettingTotal = value;
		}
	}
	private string _entryFee;
	
	public string entryFee {
		get {
			return _entryFee;
		}
		set {
			_entryFee = value;
		}
	}
	private string _rewardType;
	
	public string rewardType {
		get {
			return _rewardType;
		}
		set {
			_rewardType = value;
		}
	}
	private string _rewardValue;
	
	public string rewardValue {
		get {
			return _rewardValue;
		}
		set {
			_rewardValue = value;
		}
	}
	private string _rewardRate;
	
	public string rewardRate {
		get {
			return _rewardRate;
		}
		set {
			_rewardRate = value;
		}
	}
	private string _myEntryFee;
	
	public string myEntryFee {
		get {
			return _myEntryFee;
		}
		set {
			_myEntryFee = value;
		}
	}

	private string _doneGame;
	
	public string doneGame {
		get {
			return _doneGame;
		}
		set {
			_doneGame = value;
		}
	}
	private int _playRound;
	
	public int playRound {
		get {
			return _playRound;
		}
		set {
			_playRound = value;
		}
	}
	private string _inningType;
	
	public string inningType {
		get {
			return _inningType;
		}
		set {
			_inningType = value;
		}
	}

	

}
