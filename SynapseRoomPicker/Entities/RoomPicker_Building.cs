using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;

namespace SynapseRoomPicker.Entities
{
    public partial class RoomPicker_Building : SynapseEntity<RoomPicker_Building>
    {
        private static String _query = "SELECT * FROM [Synapse_ROOMPICKER_BUILDING]";
        private static String _tableName = "[Synapse_ROOMPICKER_BUILDING]";
        private static String _IDproperty = "ID";
        private static String _EcludeForSave = "||";

        private Int64 _ID;
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _SITE;
        public string SITE
        {
            get { return _SITE; }
            set { _SITE = value; }
        }

        private string _CODE;
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }

        private Int64 _FK_ENTITY;
        public Int64 FK_ENTITY
        {
            get { return _FK_ENTITY; }
            set { _FK_ENTITY = value; }
        }

        private string _NAME;
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        private Int64 _FK_MODULE;
        public Int64 FK_MODULE
        {
            get { return _FK_MODULE; }
            set { _FK_MODULE = value; }
        }

        private bool _AVAILABLE;
        public bool AVAILABLE
        {
            get { return _AVAILABLE; }
            set { _AVAILABLE = value; }
        }
    }
}
