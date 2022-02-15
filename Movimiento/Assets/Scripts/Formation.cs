using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{

    struct PosOri
    {
        public Vector3 position;
        public float orientation;
    }

    class ratSlot
    {
        public ratSlot(GameObject o, int s) { character = o; slot = s; }
        public GameObject character;
        public int slot;

        public void setSlot(int x) { slot = x; }
    }

    struct slot
    {

    }

    struct pattern
    {
        public int supportedSlots;
    }

    public class Formation
    {

        static PosOri driftOffset;

        List<ratSlot> slotAssignments = new List<ratSlot>();

        pattern exPattern;
        [SerializeField]
        Transform anchorPoint;
        void updateSlotAssignment()
        {
            for (int i = 0; i < slotAssignments.Count; i++)
            {
                slotAssignments[i].setSlot(i);
            }

            driftOffset = pattern.getDriftOffset(slotAssignments);
        }

        bool addCharacter(GameObject character)
        {
            if (exPattern.supportedSlots < slotAssignments.Count + 1)
                return false;

            ratSlot addSlot = new ratSlot(character, 0);

            slotAssignments.Add(addSlot);
          
            updateSlotAssignment();
            return true;
        }

        void removeCharacter(GameObject character)
        {     
            int i = 0;
            while(i < slotAssignments.Count)
            {
                if (character == slotAssignments[i].character)
                {
                    slotAssignments.RemoveAt(i);
                    break;
                }
            }

            updateSlotAssignment();
        }

        void updateSlots()
        {
            Vector3 ancPoint = anchorPoint.position;
            Vector3 ori = anchorPoint.rotation.eulerAngles;

            for(int i=0; i< slotAssignments.Count; i++)
            {
                int slotNumber = slotAssignments[i].slot;
                slot formSlot = pattern.getSlotLocation(slotNumber);

                PosOri location;
                location.position = ancPoint + ori * formSlot.position;
                location.orientation = ori + formSlot.orientation;

                location.position -= driftOffset.position;
                location.orientation -= driftOffset.orientation;

                slotAssignments[i].character.setTarget(location);
            }
        }

        Vector3 getAnchorPoint()
        {
            return anchorPoint.position;
        }
    }
}