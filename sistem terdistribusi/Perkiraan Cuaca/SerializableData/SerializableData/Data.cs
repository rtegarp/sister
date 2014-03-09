using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableData
{
    public enum Command
    {
        Login,      //Log into the server
        Logout,     //Logout of the server
        Message,    //Send a text message to all the chat clients
        List,       //Get a list of users in the chat room from the server
        Null        //No command
    }

    [Serializable]
	public class Data
	{
	    //Default constructor
	    public Data()
	    {
	        this.cmdCommand = Command.Null;
	        this.strMessage = null;
	        this.strName = null;
	    }       	    
	
	    public string strName;      //Name by which the client logs into the room
	    public string strMessage;   //Message text
	    public Command cmdCommand;  //Command type (login, logout, send message, etcetera)
	}
}
