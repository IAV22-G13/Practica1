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

    public class FormationPattern
    {
        [SerializeField]
        PosOri[] formation;

        public bool supportsSlots(int slotCount)
        {
            return formation.Length > slotCount;
        }
        public Vector3 getSlotLocation(int slotNumber)
        {
            if (supportsSlots(slotNumber))
                return formation[slotNumber].position;
            else
                return new Vector3();
        }

        //public PosOri getDriftOffset(int sl)
        //{

        //}
    }

    public class Formation
    {

        static PosOri driftOffset = new PosOri();

        List<ratSlot> slotAssignments = new List<ratSlot>();

        FormationPattern exPattern;
        [SerializeField]
        Transform anchorPoint;
        void updateSlotAssignment()
        {
            for (int i = 0; i < slotAssignments.Count; i++)
            {
                slotAssignments[i].setSlot(i);
            }

            //driftOffset = exPattern.getDriftOffset(slotAssignments);
        }

        bool addCharacter(GameObject character)
        {
            if (exPattern.supportsSlots(slotAssignments.Count + 1))
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
                PosOri formSlot;
                formSlot.position = exPattern.getSlotLocation(slotNumber);
                formSlot.orientation = 0;

                PosOri location;
                location.position = ancPoint + ori.y * formSlot.position;
                location.orientation = ori.y + formSlot.orientation;

                location.position -= driftOffset.position;
                location.orientation -= driftOffset.orientation;

                slotAssignments[i].character.GetComponent<Seguir>().SetTarget(location.position, location.orientation);
            }
        }

        Vector3 getAnchorPoint()
        {
            return anchorPoint.position;
        }
    }
}