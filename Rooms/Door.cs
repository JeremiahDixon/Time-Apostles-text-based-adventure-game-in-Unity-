/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	private Room room1;
	private Room room2;
	public bool isOpen{
		get{
			return _isOpen;
		}
	}
	
	public bool isClosed{
		get{
			return !_isOpen;
		}
	}

	public void open{
			_isOpen = true;
	}

	public void close{
			_isOpen = false;
	}

	public Door(Room room1, Room room2){
		this.room1 = room1;
		this.room2 = room2
		isOpen = true;
	}

	public Room getOtherRoom(Room fromRoom){
		if (fromRoom == room1){
			return room2;
		}
		else{
			return room2;
		}
	}

	public static Door connectRooms(Room room1, string exitName1, Room room2, string exitName2){
		Door door = new Door(room1, room2);

		room1.setExit (exitName1, door);
		room2.setExit (exitName2, door);
		
		return door;
	}
}
*/