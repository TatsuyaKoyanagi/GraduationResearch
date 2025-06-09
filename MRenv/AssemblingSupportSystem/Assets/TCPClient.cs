using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
 
public class TCPClient : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
 
    void Start()
    {
        try
        {
            // サーバーに接続
            client = new TcpClient("127.0.0.1", 65432); // Pythonサーバーと同じIPとポートを指定
            stream = client.GetStream();
            Debug.Log("Connected to server");
 
            // サーバーにデータを送信
            SendMessageToServer("Hello from Unity!");
 
            // サーバーからのレスポンスを受信
            ReceiveMessageFromServer();
        }
        catch (Exception e)
        {
            Debug.Log($"Exception: {e.Message}");
        }
    }
 
    void SendMessageToServer(string message)
    {
        if (stream != null && stream.CanWrite)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Debug.Log($"Sent: {message}");
        }
    }
 
    void ReceiveMessageFromServer()
    {
        if (stream != null && stream.CanRead)
        {
            byte[] data = new byte[1024];
            int bytes = stream.Read(data, 0, data.Length);
            string response = Encoding.UTF8.GetString(data, 0, bytes);
            Debug.Log($"Received: {response}");
        }
    }
 
    private void OnApplicationQuit()
    {
        // 終了時に接続を閉じる
        if (stream != null)
        {
            stream.Close();
        }
        if (client != null)
        {
            client.Close();
        }
    }
}