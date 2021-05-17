using UnityEngine;
using System.Collections;
using DASH._Player;
using DASH._UI;

namespace DASH._Dungeon
{
    public class Interactable : MonoBehaviour
    {
        protected GameObject player;
        protected UIManager ui;
        [SerializeField]
        protected string interactText;
        protected bool playerInTrigger = false;
        protected bool ready = true;

        protected virtual void Start()
        {
            ui = UIManager.instance;
        }

        void Update()
        {
            if (playerInTrigger && ready && Input.GetButtonDown("Interact"))
            {
                Interact();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                PlayerEntered();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerExited();
            }
        }

        protected virtual void PlayerEntered()
        {
            ui.ShowInteractText(interactText);
            playerInTrigger = true;
        }

        protected virtual void PlayerExited()
        {
            ui.HideInteractText();
            playerInTrigger = false;
        }

        protected virtual void Interact()
        {

        }
    }
}