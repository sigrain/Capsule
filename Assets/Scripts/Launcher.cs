using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Launcher : Photon.PunBehaviour
{
    string _gameVersion = "test";

    public void Connect()
    {
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings(_gameVersion);
            Debug.Log("Connected to Photon.");
        }
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Joined Lobby.");
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom("TestRoom");
        Debug.Log("Failed to entering Room.");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Room");
        Debug.Log("Entered to Room");
    }
}
