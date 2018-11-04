using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class WebsocketServer : MonoBehaviour {

  public class ClientMessage
  {
    public string data;
    public string userEndPoint;

    public ClientMessage(string userEndPoint, string data)
    {
      this.userEndPoint = userEndPoint;
      this.data = data;
    }
  }
  public List<ClientMessage> messages;

  [SerializeField]
  public GameObject targetGameObject;

  public class Log : WebSocketService
  {
    WebsocketServer server;
    public Log(WebsocketServer server) { this.server = server; }
    protected override void OnMessage(MessageEventArgs e)
    {
      //Debug.Log(Context.UserEndPoint + " " + e.Data);
      Send(e.Data);
      lock (server.messages)
      {
        server.messages.Add(new ClientMessage(Context.UserEndPoint.ToString(), e.Data));
      }
    }
  }

  WebSocketServer server;

  private void OnEnable()
  {
    messages = new List<ClientMessage>();
    server = new WebSocketServer(8080);
    
    server.AddWebSocketService<Log>("/", () => new Log(this));

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
        var playerInputs = GetPlayerInputs(targetGameObject);
    lock (messages)
    {
      foreach (ClientMessage m in messages)
      {
        Debug.Log(m.data);
        playerInputs[m.userEndPoint] = int.Parse(m.data);
      }
      messages.Clear();
    }
  }

  Dictionary<string, int> GetPlayerInputs(GameObject gameObject)
    {
        MoveLatitudinally iHateThisClassNameNow = gameObject.GetComponent<MoveLatitudinally>();
        if (iHateThisClassNameNow != null)
        {
            return iHateThisClassNameNow.playerInputs;
        }
        PlayerGroup playerGroup = gameObject.GetComponent<PlayerGroup>();
        if (playerGroup != null)
        {
            return playerGroup.playerInputs;
        }
        return null;
    }
}
