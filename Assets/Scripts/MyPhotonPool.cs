using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPhotonPool : Photon.PunBehaviour, IPunPrefabPool
{
    public List<GameObject> PrefabList;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.PrefabPool = this;
    }

    public GameObject Instantiate(string prefabId, Vector3 position, Quaternion rotation)
    {
        foreach (var s in PrefabList)
        {
            if (s.name == prefabId)
            {
                var go = Instantiate(s, position, rotation);
                go.SetActive(false);
                return go;
            }
        }

        return null;
    }

    public void Destroy(GameObject go)
    {
        GameObject.Destroy(go);
    }
}
