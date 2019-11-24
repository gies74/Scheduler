using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler
{
    public struct Meeting
    {
        private MeetingSpec _meetingSpecification;
        private List<Resource> _actualResources;

        public Meeting(MeetingSpec ms)
        {
            _meetingSpecification = ms;
            _actualResources = new List<Resource>();
            foreach (Resource res in ms.RequiredResources)
                _actualResources.Add(res);
            foreach (Resource res in ms.DesiredResources)
                _actualResources.Add(res);
        }
        public MeetingSpec MeetingSpecification
        {
            get { return _meetingSpecification; }
        }
        public List<Resource> ActualResources
        {
            get { return _actualResources; }
        }
    }
}
