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

        [Header("Audio")]
        [SerializeField] private AudioClip soundClip = null;

        private AudioSource doorAudioSource;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
            doorAudioSource = GetComponent<AudioSource>();
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
            if (soundClip != null)
            {
                doorAudioSource.PlayOneShot(soundClip);
            }
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
