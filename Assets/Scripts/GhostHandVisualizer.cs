using UnityEngine;
using System.Collections.Generic;
using Photon.Pun;

public class GhostHandVisualizer : MonoBehaviourPun
{
    public GameObject jointPrefab;
    private List<GameObject> joints = new List<GameObject>();
    private const int jointCount = 21;

    void Start()
    {
        for (int i = 0; i < jointCount; i++)
        {
            GameObject joint = Instantiate(jointPrefab, transform);
            joint.GetComponent<Renderer>().material.color = new Color(0f, 0.5f, 1f, 0.3f); // blue + low opacity
            joints.Add(joint);
        }
    }

    [PunRPC]
    public void UpdateGhostHand(object[] data)
    {
        for (int i = 0; i < jointCount; i++)
        {
            int baseIndex = i * 3;
            Vector3 pos = new Vector3(
                (float)data[baseIndex],
                (float)data[baseIndex + 1],
                (float)data[baseIndex + 2]
            );
            joints[i].transform.position = pos;
        }
    }
}