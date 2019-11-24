using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler
{
    public struct Schedule
    {
        private List<Meeting>[] _meetings;
        private int _noParSess, _noSessBlocks;

        public int NoSessBlocks
        {
            get { return _noSessBlocks; }
            set { _noSessBlocks = value; }
        }

        public int NoParSess
        {
            get { return _noParSess; }
            set { _noParSess = value; }
        }
        private int _score;
        public Schedule(int noParSess, int noSessBlocks)
        {
            _noParSess = noParSess;
            _noSessBlocks = noSessBlocks;
            _meetings = new List<Meeting>[noSessBlocks];
            for (int k = 0; k < noSessBlocks; k++)
                _meetings[k] = new List<Meeting>(noParSess);
            _score = 0;
        }
        public List<Meeting>[] Meetings
        {
            get { return _meetings; }
        }

        public int Score
        {
            get { return _score; }
        }

        public int Evaluate(int[] penalties)
        {
            string comment;
            return Evaluate(false, out comment, penalties);
        }

        public int Evaluate(bool verbose, out string comment, int[] penalties)
        {
            StringBuilder sbComment = new StringBuilder();
            int score = 0;
            for (int b = 0; b < _noSessBlocks; b++)
            {
                for (int i = 0; i < _noParSess - 1; i++)
                {
                    for (int j = i + 1; j < _meetings[b].Count; j++)
                    {
                        string comment2;
                        score += EvaluateMeetingPair(_meetings[b][i], _meetings[b][j], verbose, out comment2, penalties);
                        if (comment2 != "")
                            sbComment.Append(comment2);
                    }
                }
            }
            comment = sbComment.ToString();
            _score = score;
            return score;
        }

        public new string ToString()
        {
            string retVal = "";
            foreach (List<Meeting> lm in _meetings)
            {
                bool comma = false;
                foreach (Meeting m in lm)
                {
                    if (comma)
                        retVal += ";";
                    else
                        comma = true;
                    retVal += m.MeetingSpecification.Topic;
                }
                retVal += " ### ";
            }
            return retVal;
        }

        internal static int EvaluateMeetingPair(Meeting m1, Meeting m2, bool verbose, out string comment, int[] penalties)
        {
            comment = "";
            int score = 0;
            foreach (Resource res in m1.MeetingSpecification.RequiredResources)
                if (m2.MeetingSpecification.RequiredResources.Contains(res))
                {
                    if (verbose) comment += String.Format("MAJOR Conflict: Resource {0} assigned to Meeting {1}(r) to miss Meeting {2}(r) -> penalty +{3}" + Environment.NewLine, res.Name, m1.MeetingSpecification.Topic, m2.MeetingSpecification.Topic, penalties[0]);
                    m2.ActualResources.Remove(res);
                    score += penalties[0];
                }
            foreach (Resource res in m1.MeetingSpecification.RequiredResources)
            {
                if (m2.MeetingSpecification.DesiredResources.Contains(res))
                {
                    if (verbose) comment += String.Format("Minor Conflict: Resource {0} assigned to Meeting {1}(r) to miss Meeting {2}(d) -> penalty +{3}" + Environment.NewLine, res.Name, m1.MeetingSpecification.Topic, m2.MeetingSpecification.Topic, penalties[1]);
                    m2.ActualResources.Remove(res);
                    score += penalties[1];
                }
            }
            foreach (Resource res in m1.MeetingSpecification.DesiredResources)
                if (m2.MeetingSpecification.RequiredResources.Contains(res))
                {
                    if (verbose) comment += String.Format("Minor Conflict: Resource {0} assigned to Meeting {1}(r) to miss Meeting {2}(d) -> penalty +{3}" + Environment.NewLine, res.Name, m2.MeetingSpecification.Topic, m1.MeetingSpecification.Topic, penalties[1]);
                    m1.ActualResources.Remove(res);
                    score += penalties[1];
                }
            foreach (Resource res in m1.MeetingSpecification.DesiredResources)
                if (m2.MeetingSpecification.DesiredResources.Contains(res))
                {
                    if (verbose) comment += String.Format("Minor Conflict: Resource {0} assigned to Meeting {1}(d) to miss Meeting {2}(d) -> penalty +{3}" + Environment.NewLine, res.Name, m1.MeetingSpecification.Topic, m2.MeetingSpecification.Topic, penalties[2]);
                    m2.ActualResources.Remove(res);
                    score += penalties[2];
                }
            return score;
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int b = 0; b < _noSessBlocks; b++)
            {
                sb.AppendLine(String.Format("Block {0}", b + 1));
                for (int i = 0; i < _noParSess; i++)
                {
                    sb.Append(String.Format("- Meeting with topic {0} attended by: ", _meetings[b][i].MeetingSpecification.Topic));
                    for (int j = 0; j < _meetings[b][i].ActualResources.Count; j++)
                    {
                        Resource res = _meetings[b][i].ActualResources[j];
                        if (j > 0)
                            sb.Append(", ");
                        sb.Append(res.Name);
                    }
                    sb.AppendLine();
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public Schedule Clone()
        {
            Schedule retVal = new Schedule(_noParSess, _noSessBlocks);
            for (int b = 0; b < _noSessBlocks; b++)
                foreach (Meeting m in this._meetings[b])
                    retVal.Meetings[b].Add(new Meeting(m.MeetingSpecification));
            return retVal;
        }

    }
}
