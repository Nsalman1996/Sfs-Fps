/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package MyExtPackage;


import com.smartfoxserver.v2.entities.Room;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;
import com.smartfoxserver.v2.extensions.BaseServerEventHandler;
import com.smartfoxserver.v2.extensions.SFSExtension;
import static com.sun.corba.se.impl.naming.cosnaming.TransientNameServer.trace;




// Helper methods to easily get current room or zone and precache the link to ExtensionHelper
public class RoomHelper {


	public static RoomHelper getCurrentRoom(BaseClientRequestHandler handler) {
            trace("Handler"+handler);
		return (RoomHelper)handler.getParentExtension().getParentRoom();
	}

	public static Room getCurrentRoom(SFSExtension extension) {
            trace("Extension"+extension);
		return extension.getParentRoom();
	}



}
