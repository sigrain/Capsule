using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : Photon.PunBehaviour
{
    public GameObject PlayerManager;

    void Start()
    {
        if (!PhotonNetwork.connected)
        {
            SceneManager.LoadScene("Launcher");
            return;
        }

        if (PlayerManager == null)
        {
            GameObject Player = PhotonNetwork.Instantiate(this.PlayerManager.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
        }
    }
}
