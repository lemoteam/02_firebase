using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Router : MonoBehaviour {

	private static DatabaseReference baseRef = FirebaseDatabase.DefaultInstance.RootReference;

	public static DatabaseReference Readers() {
		return baseRef.Child("readers");
	}

	public static DatabaseReference ReadersWithUID(string uid) {
		return baseRef.Child("readers").Child(uid);
	}
}
