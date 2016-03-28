using UnityEngine;
using System.Collections;

public class LoginInfo {

	private int _memSeq;
	private string _email;
	private string _nick;
	private string _memUID;
	private int _osType;
	private int _registType;
	private string _memberPwd;
	private string _memID;
	private string _message;
	private int _code;
	private int _totalGoldenball;
	private int _totalDiamond;
	private int _tutorialYn;
	int _teamSeq;
	string _teamCode;
	string _deviceID;

	public string DeviceID {
		get {
			return _deviceID;
		}
		set {
			_deviceID = value;
		}
	}

	public int teamSeq
	{
		get
		{
			return _teamSeq;
		}		
		set
		{
			_teamSeq = value;
		}
	}

	public string teamCode
	{
		get
		{
			return _teamCode;
		}		
		set
		{
			_teamCode = value;
		}
	}

	public int memSeq
	{
		get
		{
			return _memSeq;
		}

		set
		{
			_memSeq = value;
		}
	}

	public string email
	{
		get
		{
			return _email;
		}
		
		set
		{
			_email = value;
		}
	}

	public string nick
	{
		get
		{
			return _nick;
		}
		
		set
		{
			_nick = value;
		}
	}

	public string memUID
	{
		get
		{
			return _memUID;
		}
		
		set
		{
			_memUID = value;
		}
	}
	public int osType
	{
		get
		{
			return _osType;
		}
		
		set
		{
			_osType = value;
		}
	}

	public int registType
	{
		get
		{
			return _registType;
		}
		
		set
		{
			_registType = value;
		}
	}
	public string memberPwd
	{
		get
		{
			return _memberPwd;
		}
		
		set
		{
			_memberPwd = value;
		}
	}

	public string memID
	{
		get
		{
			return _memID;
		}
		
		set
		{
			_memID = value;
		}
	}

	public string message
	{
		get
		{
			return _message;
		}
		
		set
		{
			_message = value;
		}
	}
	
	public int code
	{
		get
		{
			return _code;
		}
		
		set
		{
			_code = value;
		}
	}
	
	public int totalGoldenball
	{
		get
		{
			return _totalGoldenball;
		}
		
		set
		{
			_totalGoldenball = value;
		}
	}
	
	public int totalDiamond
	{
		get
		{
			return _totalDiamond;
		}
		
		set
		{
			_totalDiamond = value;
		}
	}
	
	public int tutorialYn
	{
		get
		{
			return _tutorialYn;
		}
		
		set
		{
			_tutorialYn = value;
		}
	}

	string photo;
	
	public string Photo {
		get {
			return photo;
		}
		set {
			photo = value;
		}
	}

	byte[] photoBytes;
	
	public byte[] PhotoBytes {
		get {
			return photoBytes;
		}
		set {
			photoBytes = value;
		}
	}

	int _status;

	public int status {
		get {
			return _status;
		}
		set {
			_status = value;
		}
	}

	string _outMessage;

	public string outMessage {
		get {
			return _outMessage;
		}
		set {
			_outMessage = value;
		}
	}

	int _outCode;

	public int outCode {
		get {
			return _outCode;
		}
		set {
			_outCode = value;
		}
	}

	int _memType;

	public int memType {
		get {
			return _memType;
		}
		set {
			_memType = value;
		}
	}

	int _points;

	public int points {
		get {
			return _points;
		}
		set {
			_points = value;
		}
	}

	int _attendDay;

	public int attendDay {
		get {
			return _attendDay;
		}
		set {
			_attendDay = value;
		}
	}

	long _freeGold;

	public long freeGold {
		get {
			return _freeGold;
		}
		set {
			_freeGold = value;
		}
	}

	long _freeTicket;

	public long freeTicket {
		get {
			return _freeTicket;
		}
		set {
			_freeTicket = value;
		}
	}

	long _joinFreeGold;

	public long joinFreeGold {
		get {
			return _joinFreeGold;
		}
		set {
			_joinFreeGold = value;
		}
	}

	long _joinFreeTicket;

	public long joinFreeTicket {
		get {
			return _joinFreeTicket;
		}
		set {
			_joinFreeTicket = value;
		}
	}

	string _serverTime;

	public string serverTime {
		get {
			return _serverTime;
		}
		set {
			_serverTime = value;
		}
	}

	string _joinFreeItem;

	public string joinFreeItem {
		get {
			return _joinFreeItem;
		}
		set {
			_joinFreeItem = value;
		}
	}

	string _freeItem;

	public string freeItem {
		get {
			return _freeItem;
		}
		set {
			_freeItem = value;
		}
	}
}
