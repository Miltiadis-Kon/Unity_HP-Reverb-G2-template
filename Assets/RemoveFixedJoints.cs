using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RemoveFixedJoints : MonoBehaviour
{
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.gameObject.layer != 3)
        {
            FixedJoint leftJoint;
            FixedJoint rightJoint;
            FixedJoint leftGOJoint;
            FixedJoint rightGOJoint;
            if (leftHand.TryGetComponent<FixedJoint>(out leftJoint) )
            {
                if(leftJoint.connectedBody == this.GetComponent<Rigidbody>())
                {
                    if (this.TryGetComponent<FixedJoint>(out leftGOJoint) && leftGOJoint.connectedBody == leftHand)
                    {
                        Destroy(leftGOJoint);
                    }
                    Destroy(leftJoint);
                    Debug.Log("Destroyed joints");
                }
            }
            if(rightHand.TryGetComponent<FixedJoint>(out rightJoint))
            {
                if (rightJoint.connectedBody == this.GetComponent<Rigidbody>())
                {
                    if (this.TryGetComponent<FixedJoint>(out rightGOJoint) && rightGOJoint.connectedBody == leftHand)
                        Destroy(rightGOJoint);
                    Destroy(rightJoint);
                    Debug.Log("Destroyed joints");
                }
            }
        }
    }
}
