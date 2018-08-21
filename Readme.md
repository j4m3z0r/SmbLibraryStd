About SmbLibraryStd:
====================
SmbLibraryStd is a fork of Tal Aloni's excellent
[SMBLibrary](https://github.com/TalAloni/SMBLibrary). It contains a handful of
minor but important changes:

- It allows for overriding the listening port for Direct TCP mode, allowing for
  unpriveleged execution, though please remember that you will need to
  implement port-forwarding or simlar to use this. I will likely expose other
  similar details to the public facing interface over time.
- It has been ported to .NET Standard 2.0.
- To simplify compliance with the LGPL licensing terms, I have made
  pre-packaged binaries that are availble on Nuget. By using these packages,
  you can be confident that you are not including any source code from
  SmbLibraryStd in your project.

To avoid confusion (and to match .net naming conventions), I have moved all
classes to the SmbLibraryStd namespace.

For reference, this code exists as fork based on the advice of SMBLibrary's
author: Tal Aloni. Details are available
[here](https://github.com/TalAloni/SMBLibrary/issues/8).

The original Readme text for SMBLibrary follows:

About SMBLibrary:
=================
SMBLibrary is an open-source C# SMB 1.0/CIFS, SMB 2.0 and SMB 2.1 server implementation.  
SMBLibrary gives .NET developers an easy way to share a directory / file system / virtual file system, with any operating system that supports the SMB protocol.  
SMBLibrary is modular, you can take advantage of Integrated Windows Authentication and the Windows storage subsystem on a Windows host or use independent implementations that allow for cross-platform compatibility.  
SMBLibrary shares can be accessed from any Windows version since Windows NT 4.0.  

Supported SMB / CIFS transport methods:
=======================================
• NetBIOS over TCP (port 139)  
• Direct TCP hosting (port 445)

###### 'NetBIOS over TCP' and 'Direct TCP hosting' are almost identical, the only differences:
- A 'session request' packet is initiating the NBT connection.
- A 'keep alive' packet is sent from time to time over NBT connections.
- SMB2: Direct TCP hosting supports large MTUs.

Notes:
======
By default, Windows already use ports 139 and 445. there are several techniques to free / utilize those ports:

##### Method 1: Disable Windows File and Printer Sharing server completely:
###### Windows XP/2003:
1. For every network adapter: Uncheck 'File and Printer Sharing for Microsoft Networks".
2. Navigate to HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\NetBT\Parameters and set SMBDeviceEnabled to '0' (this will free port 445).
3. Reboot.

###### Windows 7/8/2008/2012:
Disable the "Server" service (p.s. "TCP\IP NETBIOS Helper" should be enabled).

##### Method 2: Use Windows File Sharing AND SMBLibrary:
Windows bind port 139 to the first IP addres of every adapter, while port 445 is bound globally.
This means that if you'll disable port 445 (or block it using a firewall), you'll be able to use a different service on port 139 for every IP address.

###### Additional Notes:
* To free port 139 for a given adapter, go to 'Internet Protocol (TCP/IP) Properties' > Advanced > WINS, and select 'Disable NetBIOS over TCP/IP'.
Uncheck 'File and Printer Sharing for Microsoft Networks' to ensure Windows will not answer to SMB traffic on port 445 for this adapter.

* It's important to note that disabling NetBIOS over TCP/IP will also disable NetBIOS name service for that adapter (a.k.a. WINS), This service uses UDP port 137.
SMBLibrary offers a name service of its own.

* You can install a virtual network adapter driver for Windows to be used solely with SMBLibrary:
  - You can install the 'Microsoft Loopback adapter' and use it for server-only communication with SMBLibrary.
  - A limited alternative is 'OpenVPN TAP-Windows Adapter' that can be used for client communication with SMBLibrary.

  However, you will have to configure this adapter to use a separate network segment.
The driver installation can be downloaded from: https://openvpn.net/index.php/open-source/downloads.html
To get started, go to Adapter properties > 'Advanced' and set 'Media Status' to 'Always Connected'.

###### Windows 7/8/2008/2012:
* if you want localhost access from Windows explorer to work as expected, you must use port 445, you must also specify the IP address that you selected (\\\\127.0.0.1 or \\\\localhost will not work as expected).

##### Method 3: Use an IP address that is invisible to Windows File Sharing:
Using PCap.Net you can programmatically setup a virtual Network adapter and intercept SMB traffic (similar to how a virtual machine operates), You should use the ARP protocol to notify the network about the new IP address, and then process the incoming SMB traffic using SMBLibrary, good luck! 

Using SMBLibrary:
=================
Any directory / filesystem / object you wish to share must implement the IFileSystem interface (or the lower-level INTFileStore interface).  
You can share anything from actual directories to custom objects, as long as they expose a directory structure.  

Contact:
========
If you have any question, feel free to contact me.  
Tal Aloni <tal.aloni.il@gmail.com>
