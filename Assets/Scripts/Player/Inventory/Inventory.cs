using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Inventory<T> : MonoBehaviour {
	private List<T> _inventoryList = new List<T> ();

	public List<T> GetInventory() {
		return _inventoryList;
	}

	public void AddToInventory(T item) {
		if (!_inventoryList.Contains (item)) {
			_inventoryList.Add (item);
		}
	}
}
