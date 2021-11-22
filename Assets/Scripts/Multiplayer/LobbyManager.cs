using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text LogText;
    private byte maxplayers = 30;
    public InputField NicknameInput;
    public GameObject PanelLoading;
    void Start()
    {
        string nickName =PlayerPrefs.GetString("Nickname", "Player " + Random.Range(1000, 9999));
        PhotonNetwork.NickName = nickName;
        NicknameInput.text = nickName;
        Log("Player's name is set to " + nickName);

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to Master");
        PanelLoading.SetActive(false);
    }

    public void CreateRoom()
    {
        PhotonNetwork.NickName = NicknameInput.text;
        PlayerPrefs.SetString("Nickname", NicknameInput.text);
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = maxplayers });
    }

    public void JoinRoom()
    {
        PhotonNetwork.NickName = NicknameInput.text;
        PlayerPrefs.SetString("Nickname", NicknameInput.text);
        PhotonNetwork.JoinRandomRoom();
    }

    public void JoinInternetRoom()
    {
        
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Exit()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Menu");
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the room");
        PhotonNetwork.LoadLevel("Multiplayer");
    }

    private void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;
    }
    
}
