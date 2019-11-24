using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler
{
    public class MeetingSpec
    {
        #region Private Fields
        private string _topic;
        private string _description;
        private List<Resource> _requiredResources;
        private List<Resource> _desiredResources;
        #endregion

        #region Ctor
        public MeetingSpec(string topic)
        {
            _requiredResources = new List<Resource>();
            _desiredResources = new List<Resource>();
            _topic = topic;

        }
        #endregion

        #region Public Properties
        public string Topic
        {
            get { return _topic; }
            set { _topic = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public List<Resource> RequiredResources
        {
            get { return _requiredResources; }
        }
        public List<Resource> DesiredResources
        {
            get { return _desiredResources; }
        }
        #endregion

        #region Public Methods
        public void AddRequired(Resource res)
        {
            _requiredResources.Add(res);
        }
        public void AddDesired(Resource res)
        {
            _desiredResources.Add(res);
        }
        #endregion
    }
}
