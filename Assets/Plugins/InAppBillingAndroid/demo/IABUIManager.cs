using UnityEngine;
using System.Collections.Generic;
using Prime31;


public class IABUIManager : MonoBehaviourGUI
{
#if UNITY_ANDROID
	void OnGUI()
	{
		beginColumn();

		if( GUILayout.Button( "Initialize IAB" ) )
		{
			var key = "your public key from the Android developer portal here";
			key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAu6jn+Es/Lp/MaC6HsFY1XDVd7ZRU19b7NnOmjKN4Zs/kgb1/A8g0tlrgs85/yfzmroPIp66SnTsvtuV1bbbNcIwaecswCTHNOAksokZtLlOc7B/90cp1EdNM1ERKxmcLy3nsaCvWkTDSP/+MD0jdI1KLwCTnjsbcNAUy+zSlIu0xmw+lGSoB/0l4xiniF701yLjWct0OMNljOoSOVRiq5/mhXrt8UWHpB/F4JNJB3CbqODALPII5fcg7KNXo7P0Zov+ndAF2UjzSCru1H97bWoQYScdrtCgnrBGuNtInbSw5qUZFaPDouKaRHOgbSU+4a4+7ZcvjEmXpY9AlNAEZrQIDAQAB";
			GoogleIAB.init( key );
		}


		if( GUILayout.Button( "Query Inventory" ) )
		{
			// enter all the available skus from the Play Developer Console in this array so that item information can be fetched for them
			var skus = new string[] { "com.prime31.testproduct", "android.test.purchased", "com.prime31.managedproduct", "com.prime31.testsubscription" };
			GoogleIAB.queryInventory( skus );
		}


		if( GUILayout.Button( "Are subscriptions supported?" ) )
		{
			Debug.Log( "subscriptions supported: " + GoogleIAB.areSubscriptionsSupported() );
		}


		if( GUILayout.Button( "Purchase Test Product" ) )
		{
			GoogleIAB.purchaseProduct( "android.test.purchased" );
		}


		if( GUILayout.Button( "Consume Test Purchase" ) )
		{
			GoogleIAB.consumeProduct( "android.test.purchased" );
		}


		if( GUILayout.Button( "Test Unavailable Item" ) )
		{
			GoogleIAB.purchaseProduct( "android.test.item_unavailable" );
		}


		endColumn( true );


		if( GUILayout.Button( "Purchase Real Product" ) )
		{
			GoogleIAB.purchaseProduct( "ruby_50", "payload that gets stored and returned" );
		}


		if( GUILayout.Button( "Purchase Real Subscription" ) )
		{
			GoogleIAB.purchaseProduct( "com.prime31.testsubscription", "subscription payload" );
		}


		if( GUILayout.Button( "Consume Real Purchase" ) )
		{
			GoogleIAB.consumeProduct( "com.prime31.testproduct" );
		}


		if( GUILayout.Button( "Enable High Details Logs" ) )
		{
			GoogleIAB.enableLogging( true );
		}


		if( GUILayout.Button( "Consume Multiple Purchases" ) )
		{
			var skus = new string[] { "com.prime31.testproduct", "android.test.purchased" };
			GoogleIAB.consumeProducts( skus );
		}

		endColumn();
	}
#endif
}
