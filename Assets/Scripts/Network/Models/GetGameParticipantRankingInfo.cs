using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GetGameParticipantRankingInfo {

	string _gameSeq;

	public string gameSeq {
		get {
			return _gameSeq;
		}
		set {
			_gameSeq = value;
		}
	}
	string _scheduleSeq;
	
	public string scheduleSeq {
		get {
			return _scheduleSeq;
		}
		set {
			_scheduleSeq = value;
		}
	}
	string _playRound;
	
	public string playRound {
		get {
			return _playRound;
		}
		set {
			_playRound = value;
		}
	}
	string _inningType;
	
	public string inningType {
		get {
			return _inningType;
		}
		set {
			_inningType = value;
		}
	}
	string _gameStatus;
	
	public string gameStatus {
		get {
			return _gameStatus;
		}
		set {
			_gameStatus = value;
		}
	}
	string _playStatus;
	
	public string playStatus {
		get {
			return _playStatus;
		}
		set {
			_playStatus = value;
		}
	}
	string _awayScore;
	
	public string awayScore {
		get {
			return _awayScore;
		}
		set {
			_awayScore = value;
		}
	}
	string _homeScore;
	
	public string homeScore {
		get {
			return _homeScore;
		}
		set {
			_homeScore = value;
		}
	}
	string _joinerCount;
	
	public string joinerCount {
		get {
			return _joinerCount;
		}
		set {
			_joinerCount = value;
		}
	}
	string _awayTeamCount;
	
	public string awayTeamCount {
		get {
			return _awayTeamCount;
		}
		set {
			_awayTeamCount = value;
		}
	}
	string _homeTeamCount;
	
	public string homeTeamCount {
		get {
			return _homeTeamCount;
		}
		set {
			_homeTeamCount = value;
		}
	}
	string _homeNawayType;
	
	public string homeNawayType {
		get {
			return _homeNawayType;
		}
		set {
			_homeNawayType = value;
		}
	}
	string _myRank;
	
	public string myRank {
		get {
			return _myRank;
		}
		set {
			_myRank = value;
		}
	}
	string _rankValue;
	
	public string rankValue {
		get {
			return _rankValue;
		}
		set {
			_rankValue = value;
		}
	}
	List<ParticipantRankInfo> _rank;
	
	public List<ParticipantRankInfo> rank {
		get {
			return _rank;
		}
		set {
			_rank = value;
		}
	}
	string _rewardType;
	
	public string rewardType {
		get {
			return _rewardType;
		}
		set {
			_rewardType = value;
		}
	}
	string _rewardValue;
	
	public string rewardValue {
		get {
			return _rewardValue;
		}
		set {
			_rewardValue = value;
		}
	}
}
