using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class WebsocketServer : MonoBehaviour {

  public class Log : WebSocketService
  {
    protected override void OnMessage(MessageEventArgs e)
    {
      Debug.Log(e.Data);
      Send(e.Data);
    }
  }

  WebSocketServer server;

  private void OnEnable()
  {
    server = new WebSocketServer(8080);
    
    server.AddWebSocketService<Log>("/", () => new Log());

    server.Start();

    Debug.Log("Server Started");
  }
  
  private void OnDisable()
  {
    server.Stop(CloseStatusCode.Normal, "Stopping Server");
    server = null;
    Debug.Log("Server Stopped");
  }

  // Update is called once per frame
  void Update () {
		
	}
}
