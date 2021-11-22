using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject PlayerPrefab;
    public GameObject BallPrefab;
    public GameObject PotatoPrefab;


    private void Awake()
    {
        PhotonNetwork.SendRate = 20;
    }



    void Start()
    {


        Vector3 pos = new Vector3(Random.Range(-5f, 5f), 0);
        Debug.Log(pos);
        PhotonNetwork.Instantiate(PlayerPrefab.name, pos, Quaternion.identity);

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(BallPrefab.name, Vector3.zero, Quaternion.identity);
            pos = new Vector3(0, -1f);
            PhotonNetwork.Instantiate(PotatoPrefab.name, pos, Quaternion.identity);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LobbyMultiplayer");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room", newPlayer.NickName);

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room", otherPlayer.NickName);

    }
}
