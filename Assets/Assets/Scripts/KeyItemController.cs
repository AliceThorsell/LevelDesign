using UnityEngine;

namespace KeySystem 
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool officeDoor = false;
        [SerializeField] private bool officeKey = false;

        [SerializeField] private bool phoneDoor = false;
        [SerializeField] private bool phoneKey = false;

        [SerializeField] private bool toolDoor = false;
        [SerializeField] private bool toolKey = false;


        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (officeDoor) 
            {
                doorObject = GetComponent<KeyDoorController>();
            }

            if (phoneDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }

            if (toolDoor) 
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction() 
        {
            if (officeDoor && _keyInventory.hasOfficeKey)
            {
                doorObject.openAnimationName = "OfficeDoorOpen";
                doorObject.closeAnimationName = "OfficeDoorClose";

                doorObject.PlayAnimation();
                _keyInventory.hasOfficeKey = false;
            }
            else if (officeDoor && !_keyInventory.hasOfficeKey)
            {
                doorObject.DoorLocked();
            }

            if (phoneDoor && _keyInventory.hasPhoneKey)
            {
                doorObject.openAnimationName = "PhoneDoorOpen";
                doorObject.closeAnimationName = "PhoneDoorClose";

                doorObject.PlayAnimation();
                _keyInventory.hasPhoneKey = false;
            }
            else if (phoneDoor && !_keyInventory.hasPhoneKey)
            {
                doorObject.DoorLocked();
            }

            if (toolDoor && _keyInventory.hasToolKey)
            {
                doorObject.openAnimationName = "ToolDoorOpen";
                doorObject.PlayAnimation();
                this.GetComponent<BoxCollider>().enabled = false;

                _keyInventory.hasOfficeKey = false;
            }
            else if (toolDoor && !_keyInventory.hasToolKey)
            {
                doorObject.DoorLocked();
            }




            if (officeKey)
            {
                _keyInventory.hasOfficeKey = true;
                gameObject.SetActive(false);
            }
            if (phoneKey)
            {
                _keyInventory.hasPhoneKey = true;
                gameObject.SetActive(false);
            }
            if (toolKey)
            {
                _keyInventory.hasToolKey = true;
                gameObject.SetActive(false);
            }
        }
    }

}
