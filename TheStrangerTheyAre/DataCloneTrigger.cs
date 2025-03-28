﻿using UnityEngine;
using GhostEnums;

namespace TheStrangerTheyAre
{
    public class DataCloneTrigger : MonoBehaviour
    {
        GameObject scientist1; // creates variable to store the walking around scientist
        GameObject scientist2; // creates variable to store the pre-vision scientist

        void Awake()
        {
            scientist1 = GameObject.Find("Prefab_IP_GhostBird_SCIENTIST"); // gets the ghostbird ai scientist
            scientist2 = GameObject.Find("Prefab_IP_GhostBird_Scientist2"); // gets the pre-vision scientist
        }

        public virtual void OnTriggerEnter(Collider hitCollider)
        {
            //checks if player collides with the trigger volume
            if (hitCollider.CompareTag("PlayerDetector") && enabled)
            {
                scientist1.GetComponent<GhostController>().FacePlayer(TurnSpeed.FASTEST); // faces scientist to player
                scientist2.SetActive(true); // enables pre-vision scientist when player interacts with trigger
                scientist2.transform.position = scientist1.transform.position; // sets the position of pre-vision scientist equal to ghostbird ai
                scientist2.transform.rotation = scientist1.transform.rotation; // sets the rotation of pre-vision scientist equal to ghostbird ai
                scientist2.GetComponentInChildren<ConeShape>().enabled = true; // enables vision torch cone so it can work!!!!
            }
        }
    }
}