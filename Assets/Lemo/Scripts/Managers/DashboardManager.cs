using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardManager : MonoBehaviour {

	public List<Reader> readerList = new List<Reader>();

	void Awake() {
		readerList.Clear();

		DatabaseManager.sharedInstance.GetReaders(result => {
			readerList = result;
			Debug.Log(readerList[0].email);
		});
	}
}
