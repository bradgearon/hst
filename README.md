hst - manage your host in windows
========================

Simple cmd line to enable management of host files in Windows... without the UAC hoops, and in such a way that you can automate it.  

+ Install and add a host entry in less characters than you type to open system32/drivers/etc/hosts
+ **Without touching a rodent**

Install with [chocolatey](http://chocolatey.org/)

	cinst hst

usage: 

	hst <action> hostName [networkAddress]
	
### networkAddress can be omitted; defaults to loopback (127.0.0.1)
### action must be one of the following: 
+ add: adds an entry for hostName @ [networkAdress]
+ delete: removes entry for hostName
+ check: exitcode of 1 or 0, useful for scripting
+ replace: replaces the hostName entry with [networkAddress]
	