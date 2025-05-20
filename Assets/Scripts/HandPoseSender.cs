using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HandPoseSender : MonoBehaviourPun
{
    public OVRSkeleton skeleton;
    public OVRHand hand;

    private List<Transform> bones = new List<Transform>();

    void Start()
    {
        foreach (var bone in skeleton.Bones)
        {
            bones.Add(bone.Transform);
        }
    }

    void Update()
    {
        if (!photonView.IsMine || !hand.IsTracked)
            return;

        object[] data = new object[bones.Count * 3];
        for (int i = 0; i < bones.Count; i++)
        {
            Vector3 pos = bones[i].position;
            data[i * 3] = pos.x;
            data[i * 3 + 1] = pos.y;
            data[i * 3 + 2] = pos.z;
        }

        photonView.RPC("UpdateGhostHand", RpcTarget.Others, data);
    }
}