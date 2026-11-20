using System.Collections;
using UnityEngine;


namespace KeySystem 
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        [Header("Animation Names")]
        [SerializeField] public string openAnimationName;
        [SerializeField] public string closeAnimationName;

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        [SerializeField] private KeyItemController _keyItemController = null;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }

        private IEnumerator PauseDoorInteraction() 
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }


        public void PlayAnimation() 
        {
            OpenDoor();
        }

        public void DoorLocked()
        {
            StartCoroutine(ShowDoorLocked());
        }

        void OpenDoor()
        {
            if(!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }
        }



        IEnumerator ShowDoorLocked() 
        {
            Debug.Log("here");
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
        }
    }

}
