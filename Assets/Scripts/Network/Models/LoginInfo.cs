using UnityEngine;
using System.Collections;

public class LoginInfo {

	private int _memSeq;
	private string _memberEmail;
	private string _memberName;
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

	public string memberEmail
	{
		get
		{
			return _memberEmail;
		}
		
		set
		{
			_memberEmail = value;
		}
	}

	public string memberName
	{
		get
		{
			return _memberName;
		}
		
		set
		{
			_memberName = value;
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
}
