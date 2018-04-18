using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;

public class DatabaseManager : MonoBehaviour {

	public static DatabaseManager sharedInstance = null;

	/// <summary>
	/// Awake this instance and initialize sharedInstance for Singleton pattern
	/// </summary>
	void Awake() {
		if (sharedInstance == null) {
			sharedInstance = this;
		} else if (sharedInstance != this) {
			Destroy (gameObject);  
		}

		DontDestroyOnLoad(gameObject);

		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unity-firebase-78a2d.firebaseio.com/");
	}
	
	public void CreateNewReader(Reader reader, string uid) {
		Debug.Log ("readerJSON readerJSON readerJSON");
		string readerJSON = JsonUtility.ToJson(reader);
		Router.ReaderWithUID(uid).SetRawJsonValueAsync(readerJSON);
	}

	public void GetReaders(Action<List<Reader>> completionBlock) {
		List<Reader> tmpList = new List<Reader> ();

		Router.ReaderWithUID("UiXMSzcJT6Zc7Kf3BFXdHElX3ri2").GetValueAsync().ContinueWith (task => { // Place a UID

			DataSnapshot reader = task.Result;

			var readerDict = (IDictionary<string, object>)reader.Value;
			Reader newReader = new Reader(readerDict);
			tmpList.Add(newReader);

			completionBlock(tmpList);
		});
	}
}
