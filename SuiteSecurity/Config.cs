using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Configuration;
public class Config
{
	//----------------------------------------------------------------
	// Class for management of the configuration file (app.config)
	//----------------------------------------------------------------
    private string _ConnectioPrefix = "Default";
	public Config(string ConnectionPrefix)
	{
        if (ConnectionPrefix == "Default")
            _ConnectioPrefix = "";
        else
            _ConnectioPrefix = ConnectionPrefix;
	}
	//==================================================
	// Version
	//==================================================
	public string Version {
		get { return ConfigurationManager.AppSettings["version"]; }
	}
	//==================================================
	// Database
	//==================================================
	public string ServerName {
		get { return ConfigurationManager.AppSettings[_ConnectioPrefix+"Server name"]; }
	}
	public string DatabaseName {
		get { return ConfigurationManager.AppSettings[_ConnectioPrefix+"Database name"]; }
	}
}