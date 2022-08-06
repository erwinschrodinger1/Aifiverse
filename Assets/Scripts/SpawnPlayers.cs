using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject character;
    private void Start()
    {

        if (PhotonNetwork.IsConnectedAndReady)
        {
            Vector3 instanciatePosition = new Vector3(0f, 0f, 0f);
            var characterIns = PhotonNetwork.Instantiate(character.name, instanciatePosition, Quaternion.identity);
            characterIns.GetComponent<CharacterControl>().enabled = true;
            characterIns.GetComponentInChildren<Camera>().enabled = true;
        }
    }
}





