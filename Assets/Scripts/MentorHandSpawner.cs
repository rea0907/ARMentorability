using Photon.Pun;
using UnityEngine;

public class MentorHandSpawner : MonoBehaviourPunCallbacks
{
    public GameObject handPrefab;
    public Transform leftHand;
    public Transform rightHand;

    private GameObject leftHandInstance;
    private GameObject rightHandInstance;

    void Start()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient)
        {
            leftHandInstance = PhotonNetwork.Instantiate(handPrefab.name, leftHand.position, leftHand.rotation);
            rightHandInstance = PhotonNetwork.Instantiate(handPrefab.name, rightHand.position, rightHand.rotation);
        }
    }

    void Update()
    {
        if (leftHandInstance != null && rightHandInstance != null)
        {
            leftHandInstance.transform.position = leftHand.position;
            leftHandInstance.transform.rotation = leftHand.rotation;

            rightHandInstance.transform.position = rightHand.position;
            rightHandInstance.transform.rotation = rightHand.rotation;
        }
    }
}