/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package MyExtPackage;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.entities.data.SFSObject;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;
import com.smartfoxserver.v2.entities.data.SFSDataWrapper;
import com.smartfoxserver.v2.entities.Room;
import MyExtPackage.RoomHelper;
import MyExtPackage.UserHelper;
import MyExtPackage.MainExtenxion;
import java.util.List;
/**
 *
 * @author nms19
 */
public class transformHandler extends BaseClientRequestHandler {
   

    @Override
    public void handleClientRequest(User user, ISFSObject isfso)
    {
        trace("transformHandler1");
        ISFSObject dt = new SFSObject();
        dt=isfso;
        String transform=dt.toJson();
    
        int id=user.getId();
        trace(transform);
        
        
       trace("Iduserfrom"+id);
        
       isfso.putInt("playerID", user.getId());    
       isfso.putUtfString("transform", transform);
      
       MainExtenxion myext=(MainExtenxion)getParentExtension();
 if(myext==null)
 {
 trace("myext null");
 }
 else if(myext!=null)
         {
           Room currentroom= (Room) myext.getParentZone().getRoomByName("The Lobby");
           trace("currentroom"+currentroom);
           if(currentroom==null)
           {
               trace("current room null");
           }
              List<User> userList = currentroom.getUserList();
              trace("userList" + userList);
              if (userList==null)
              {
               trace("userList null") ;
              }
              myext.send("transform",isfso,userList);    
        
          
         }
            
              
                       
    }
    
}
