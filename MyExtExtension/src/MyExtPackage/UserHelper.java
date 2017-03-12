/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package MyExtPackage;
import com.smartfoxserver.v2.entities.Room;
import com.smartfoxserver.v2.entities.User;
import static com.sun.corba.se.impl.naming.cosnaming.TransientNameServer.trace;

import java.util.List;

// Helper methods to easily get socket channel list to send response message to clients
public class UserHelper {


	public static List<User> getRecipientsList(Room room, User exceptUser) {
            trace("room" + room + "exceptUser"+ exceptUser);
		List<User> users = room.getUserList();
		if (exceptUser != null) {
			users.remove(exceptUser);
		}

		return users;

	}

	public static List<User> getRecipientsList(Room currentRoom) {
            trace("getcurr"+currentRoom);
		return getRecipientsList(currentRoom, null);
	}


}
