using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class SocketExample1 : MonoBehaviour
{
    const int PORTNUMBER = 3456;
    //UI Fields
    public TMPro.TMP_InputField ipAddress;
    public TMPro.TMP_InputField messageToSend;
    public TMPro.TextMeshProUGUI messageLog;
    //Sockets
    Socket listener;
    Socket handler;
    //MultiThreading
    Mutex mutex = new Mutex();
    private Thread SocketThread;

    //Misc
    public bool keepReading;
    string messageLogText = "";


    /// <summary>
    /// Gets the local Ip address of the PC being executed on (this PC)
    /// </summary>
    /// <returns></returns>
    string GetHostIP()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }



    /// <summary>
    /// By Default lets set the target IP address to the proper IP of this machine for same PC testing.
    /// </summary>
    private void Start()
    {
        ipAddress.text = GetHostIP();
    }

    /// <summary>
    /// Sends the text held in the UI input field off to a connected server
    /// Identified in the UI IPaddress object
    /// </summary>
    public void SendTextMessage()
    {
        try
        {
            IPAddress ipAddr = IPAddress.Parse(ipAddress.text);
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddr, PORTNUMBER);

            // Instantiate a TCP/IP Socket using Socket Class 
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // Connect Socket to the remote endpoint using method Connect() 
                sender.Connect(remoteEndPoint);
                // We print EndPoint information that we are connected 
                Debug.Log($"Socket connected to -> {sender.RemoteEndPoint.ToString()}");
                // Creation of messagge that we will send to Server 
                byte[] messageSent = Encoding.ASCII.GetBytes(messageToSend.text + "<EOF>");
                int byteSent = sender.Send(messageSent);
                // Data buffer 
                byte[] messageReceived = new byte[1024];
                // We receive the messagge using the method Receive(). 
                // returns number of bytes received, that we'll use to convert them to string 
                int byteRecv = sender.Receive(messageReceived);
                Debug.Log($"Message from Server -> {Encoding.ASCII.GetString(messageReceived, 0, byteRecv)}");
                //If this is running on a seperate machine to the server then echo the response from the server on screen
                if (GetHostIP() != ipAddress.text)
                    messageLog.text = Encoding.ASCII.GetString(messageReceived, 0, byteRecv) + messageLog.text;
                // Shutdown and close the socket
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }

            catch (Exception e)
            {
                Debug.Log($"Exception Processing Data: {e.ToString()}");
            }
        }
        catch (Exception e)
        {
            Debug.Log($"Exception: {e.ToString()}");
        }
    }

    /// <summary>
    /// Start up the server thread.
    /// </summary>
    public void ExecuteServer()
    {
        StartCoroutine(UpdateMessageLog());
        SocketThread = new System.Threading.Thread(ThreadedServer);
        SocketThread.IsBackground = true;
        SocketThread.Start();
    }


    /// <summary>
    /// Server thread, monitors the port for incoming data and updates the messageLogText string for outputting.
    /// </summary>
    public void ThreadedServer()
    {

        IPAddress ipAddr = IPAddress.Parse(GetHostIP());
        IPEndPoint localEndPoint = new IPEndPoint(ipAddr, PORTNUMBER);
        string data;
        // Data buffer for incoming data.
        byte[] bytes = new Byte[1024];
        // Create a TCP/IP socket.
        listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            // Bind the socket to the local endpoint and 
            // listen for incoming connections.     
            listener.Bind(localEndPoint);
            listener.Listen(10);
            // Start listening for connections.
            while (true)
            {
                keepReading = true;
                // Program is suspended while waiting for an incoming connection.
                Debug.Log("Waiting for Connection");     //It works
                handler = listener.Accept();
                Debug.Log("Client Connected");     //It doesn't work
                data = null;
                // An incoming connection needs to be processed.
                while (keepReading)
                {
                    mutex.WaitOne();
                    string tmp = messageLog.text;
                    mutex.ReleaseMutex();
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    Debug.Log("Received from Server");

                    if (bytesRec <= 0)
                    {
                        keepReading = false;
                        handler.Disconnect(true);
                        break;
                    }

                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        mutex.WaitOne();
                        messageLogText = data.Replace("<EOF>", "\n") + messageLogText;
                        mutex.ReleaseMutex();
                        Debug.Log(data);
                        //Should send a response as well
                        handler.Send(Encoding.ASCII.GetBytes(data.Replace("<EOF>", "\n")));
                        break;
                    }
                    System.Threading.Thread.Sleep(1);
                }
                System.Threading.Thread.Sleep(1);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    /// <summary>
    /// Updates the messagelog output  for the server side.
    /// </summary>
    /// <returns></returns>
    IEnumerator UpdateMessageLog()
    {
        while (true)
        {
            messageLog.text = messageLogText;
            yield return new WaitForSeconds(.25f);
        }
    }
    void stopServer()
    {
        keepReading = false;

        //stop thread
        if (SocketThread != null)
        {
            SocketThread.Abort();
        }

        if (handler != null && handler.Connected)
        {
            handler.Disconnect(false);
            Debug.Log("Disconnected!");
        }
    }

    /// <summary>
    /// Object disabled, probably time to shut it all down.
    /// </summary>
    void OnDisable()
    {
        stopServer();
    }
}
