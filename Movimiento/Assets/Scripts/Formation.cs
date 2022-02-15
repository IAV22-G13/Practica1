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

    struct ratSlot
    {
        public GameObject character;
        public int slot;
    }

    struct pattern
    {
        public int supportedSlots;
    }

    public class Formation : ComportamientoAgente
    {

        static PosOri driftOffset;

        ratSlot[] slotAssignment = new ratSlot[0];

        pattern exPattern;

        void updateSlotAssignment()
        {
            for (int i = 0; i < slotAssignment.Length; i++)
            {
                slotAssignment[i].slot = i;
            }

            //driftOffset = pattern.getDriftOffset(slotAssignments)
        }

        bool addCharacter(GameObject character)
        {
            int occupiedSlots = slotAssignment.Length;

            if (exPattern.supportedSlots < occupiedSlots + 1)
                return false;

            ratSlot addSlot = new ratSlot();
            addSlot.character = character;

            ratSlot[] aux = slotAssignment;

            slotAssignment = new ratSlot[occupiedSlots + 1];

            int i = 0;
            for (i = 0; i < aux.Length; i++)
            {
                slotAssignment[i] = aux[i];
            }
            slotAssignment[i] = addSlot;

            updateSlotAssignment();
            return true;
        }

        void removeCharacter(GameObject character)
        {
            int occupiedSlots = slotAssignment.Length;

            ratSlot[] aux = slotAssignment;

            slotAssignment = new ratSlot[occupiedSlots - 1];
            int found = 0;
            for (int i = 0; i < aux.Length; i++)
            {
                if (character != slotAssignment[i].character)
                {
                    slotAssignment[i - found] = aux[i];
                }
                else found = 1;
            }

            updateSlotAssignment();
        }

        void updateSlots()
        {
            
        }
        public override Direccion GetDireccion()
        {
            //# A Static (i.e., position and orientation) representing the 
            //# drift offset for the currently filled slots. 
            //        driftOffset: Static

            //# The formation pattern. 
            //    pattern: FormationPattern

            //# Update the assignment of characters to slots. 
            //    function updateSlotAssignments(): 
            //        # A trivial assignment algorithm: we simply go through 
            //        # each character and assign sequential slot numbers. 
            //        for i in 0..slotAssignments.length(): 
            //            

            //        # Update the drift offset. 
            //        driftOffset = pattern.getDriftOffset(slotAssignments)

            //    # Add a new character. Return false if no slots are available. 
            //    function addCharacter(character: Character)-> bool: 

            //        # Check if the pattern supports more slots.
            //        occupiedSlots = slotAssignnents.length()
            //        if pattern.supportsSlots(occupiedSlots + 1.
            //# Add a new slot assignment.
            //            slotAssignment = new SlotAssignment()
            //            slotAssignnent.character = character
            //            slotAssignnents.append(slotAssignnent)
            //            updateSlotAssignments()
            //            return true
            //        else:
            //            # Otherwise we've failed to add the character.
            //            return false





            //    # Remove a character from its slot.
            //            function renoveCharacter(character: Character):
            //        slot = charactersInSlots.findIndexOfCharacter character)
            //        slotAssignnents.renovest(slot)
            //        updateSlotAssignments()

            //    # Send new target Locations to each character.
            //            function updateStots():

            //        # Find the anchor point.
            //        anchor: Static = getAnchorPoint()
            //        orientationMatrix: Matrix = anchor.orientation.asMatrix()

            //        # Go through each character in turn.
            //            for 1 in 0..slotAssignnents.Length ):
            //            slotNumber: int = slotAssignnents[i].slotNumber
            //            slot: Static = pattern.getSlotLocation(slotNumber)

            //        # Transform by the anchor point position and orientation
            //            location = new Static()
            //        location.position = anchor.position +
            //        orientationMatrix * slot.position
            //        location.orientation = anchor.orientation +
            //        slot.orientation

            //        # And add the drift component.
            //            location.position -= driftoffset.position
            //        location.orientation -= driftoffset.orientation

            //        # Send the static to the character.
            //            slotAssignments[i].character.setTarget(location)

            //    # The characteristic point of this formation (see below).
            //            function aetAnchorPoint() -> Static

            return new Direccion();
        }
    }
}