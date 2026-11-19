using UnityEngine;

namespace KeySystem 
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool officeDoor = false;
        [SerializeField] private bool officeKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (officeDoor) 
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction() 
        {
            if (officeDoor) 
            {
                doorObject.PlayAnimation();
            }

            else if (officeKey) 
            {
                _keyInventory.hasOfficeKey = true;
                gameObject.SetActive(false);
            }
        }
    }

}
