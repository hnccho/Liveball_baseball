using UnityEngine;
using System.Collections;

public class GetLobbyInfoResponse : BaseResponse {
	LobbyInfo _data;

	public LobbyInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
