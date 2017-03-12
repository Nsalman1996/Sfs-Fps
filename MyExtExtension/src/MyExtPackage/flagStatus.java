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
import com.smartfoxserver.v2.util.JSONUtil;
import com.smartfoxserver.v2.entities.data.SFSDataWrapper;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
/**
 *
 * @author nms19
 */
public class flagStatus extends BaseClientRequestHandler
{
    @Override
     public void handleClientRequest(User user, ISFSObject isfso)
    {
        trace("flagstatus callled");
        SFSObject flagdt=new SFSObject();
        flagdt=(SFSObject)isfso;
       // flagdt = flagdt.getSFSObject("SpawnPoints");
       String Tdata=flagdt.getUtfString("SpawnPoints").toString();
      // String data="";
       //data=Tdata.toString();
       trace("dataaa" + Tdata);
       flagPositionCalc(Tdata);
        
        
        //flagPositionCalc(user,flagdt);
    }    
     public void flagPositionCalc(String data)
     {
     JSONParser parser =new JSONParser();
        try {
            trace("try method");
            
            Object obj = parser.parse(data);
            trace("obj"+ obj.toString());
             JSONArray array = (JSONArray)obj;
               trace("array"+ array.toString());
             String ParserDataSpawn1=(String) array.get(1);
              trace("flag"+ParserDataSpawn1);
               Object Obj1 = parser.parse(ParserDataSpawn1);
                      JSONArray array1 = (JSONArray)Obj1;
               String PosX= array1.get(1).toString();
               trace ("Posxa" + PosX);
            
        } catch (ParseException ex) {
            Logger.getLogger(flagStatus.class.getName()).log(Level.SEVERE, null, ex);
        }
     }
    
}
