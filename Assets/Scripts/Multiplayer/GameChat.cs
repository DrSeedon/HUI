using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameChat : MonoBehaviour, IPunObservable
{

    private PhotonView photonView;

    public GameObject Panel;
    public bool isOpen = false;

    public Text TextChat;
    public InputField InputFieldChat;

    public string InputText;
    public string ChatText;
    public string PlayerName = "PlayerBlya";


    void Start()
    {

        photonView = GetComponent<PhotonView>();

        PlayerName = photonView.Owner.NickName;

        ChatText = "Connected " + PlayerName + "\r\n" + ChatText;

        if (Panel.activeSelf)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputText = InputFieldChat.text;
        TextChat.text = ChatText;
    }

    public void ClickChatButton()
    {


        if (!isOpen)
        {
            Panel.SetActive(true);
            isOpen = true;
        }
        else
        {
            Panel.SetActive(false);
            isOpen = false;
        }
    }

    public void ClickSend()
    {
        if (!string.IsNullOrEmpty(InputText) && InputText.Length > 0)
        {
            SendMessageChat(InputText);
            InputFieldChat.text = "";
        }
    }


    private void SendMessageChat(string message)
    {

        if (message.StartsWith("/"))
        {
            ParseCommand(message);
            return;
        }


        ChatText = PlayerName + ":" + message + "\r\n" + ChatText;

    }


    private void ParseCommand(string command)
    {
        switch (command.Remove(0, 1))
        {
            case "clear":
                {
                    ChatText = "";
                    break;
                }
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(ChatText);
        }
        else
        {
            ChatText = (string)stream.ReceiveNext();
        }
    }



}
