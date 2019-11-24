using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler
{
    public class Resource
    {
        #region Private Fields
        private string _name;
        private ResourceType _type;
        private int _numReqMeetings;
        private int _numDesMeetings;
        #endregion

        #region Ctor
        public Resource(string name, string type)
        {
            _name = name;
            _numReqMeetings = 0;
            _numDesMeetings = 0;
            switch (type)
            {
                case "person":
                    _type = Resource.ResourceType.Person;
                    break;
                case "device":
                    _type = Resource.ResourceType.Device;
                    break;
                case "room":
                    _type = Resource.ResourceType.Room;
                    break;
                default:
                    _type = Resource.ResourceType.Person;
                    break;
            }
        }
        #endregion

        #region Public Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ResourceType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int NumReqMeetings
        {
            get { return _numReqMeetings; }
            set { _numReqMeetings = value; }
        }
        public int NumDesMeetings
        {
            get { return _numDesMeetings; }
            set { _numDesMeetings = value; }
        }
        #endregion

        public enum ResourceType
        {
            Person,
            Device,
            Room
        }
    }
}
