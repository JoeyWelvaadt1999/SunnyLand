using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	private Inventory<Collectible> _inventory = new Inventory<Collectible>();
	public Inventory<Collectible> Inventory {
		get { 
			return _inventory;
		}
	}
}
