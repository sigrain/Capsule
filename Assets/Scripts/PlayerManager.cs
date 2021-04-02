using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerManager : Photon.PunBehaviour
{
    public GameObject PlayerController;
    public GameObject PlayerUiPrefab;
    public static GameObject LocalPlayerInstance;

    GameObject _uiGo;

    void Awake()
    {
        if (photonView.isMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.connected)
        {
            SceneManager.LoadScene("Launcher");
            return;
        }

        if(PlayerController == null)
        {
            GameObject Player = PhotonNetwork.Instantiate(this.PlayerController.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
        }

        if(PlayerUiPrefab != null)
        {
            _uiGo = Instantiate(PlayerUiPrefab) as GameObject;
            _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
        }
    }
}
