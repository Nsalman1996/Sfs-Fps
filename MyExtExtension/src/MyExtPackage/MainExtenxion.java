/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package MyExtPackage;
import com.smartfoxserver.v2.extensions.SFSExtension;
/**
 *
 * @author nms19
 */
public class MainExtenxion extends SFSExtension {
    @Override
    public void init()
    {
        addRequestHandler("sendTransform",transformHandler.class);
        addRequestHandler("flagValue",flagStatus.class);
        trace("sfs extention started");
    }
}
