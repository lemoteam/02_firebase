﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;

public class AuthManager : MonoBehaviour {

	// Firebase API Variables
	Firebase.Auth.FirebaseAuth auth;

	// Delegates
	public delegate IEnumerator AuthCallback(Task<Firebase.Auth.FirebaseUser> task, string operation);
	public event AuthCallback authCallback;

	void Awake() {
		auth = FirebaseAuth.DefaultInstance;
	}

	public void SignUpNewUser(string email, string password) {
		auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
			StartCoroutine(authCallback(task, "sign_up"));
		});
	}
}
