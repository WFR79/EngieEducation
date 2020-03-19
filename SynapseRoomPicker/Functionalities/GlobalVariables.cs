using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseRoomPicker.Functionalities
{
    public partial class GlobalVariables
    {
        public enum EditMode
        {
            New = 0, Edit = 1
        }

        public enum PickerType
        {
            Entity = 0, Building = 1, Room = 2
        }

        public enum DisplayMember
        {
            Code = 0, Name = 1
        }
    }
}
