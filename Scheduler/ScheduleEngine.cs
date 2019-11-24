using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Scheduler
{
    public static class ScheduleEngine
    {
        public static readonly object uiLock = new object();
        public static bool stop;

        private static List<Schedule> _solutions = new List<Schedule>();
        private static List<MeetingSpec> _initMeetings = new List<MeetingSpec>();
        private static int _minScore;

        private static long _noEvaluated;

        private static int[] _penalties = new int[3];

        private static MainUI.ProgressDelegate _d;

        private static int facAll;
        private static MainUI _parent;
        private static long _numC;
        
        private static int noParSess;
        private static int noSessBlocks;
        public static MainUI Parent
        {
            set { _parent = value; }
        }
        public static List<Schedule> Solutions
        {
            get { return _solutions; }
        }
        public static List<MeetingSpec> InitMeetings
        {
            get { return _initMeetings; }
        }
        public static int MinScore
        {
            get { return _minScore; }
        }
        public static int PenRR
        {
            set { _penalties[0] = value; }
        }
        public static int PenRD
        {
            set { _penalties[1] = value; }
        }
        public static int PenDD
        {
            set { _penalties[2] = value; }
        }

        public static void Run()
        {
            lock (uiLock)
            {
                stop = false;
            }
            _minScore = Int32.MaxValue;
            _solutions.Clear();
            _noEvaluated = 0;
            noParSess = Convert.ToInt32(_parent.NoParSess);
            noSessBlocks = Convert.ToInt32(_parent.NoSessBlocks);
            if (_initMeetings.Count > noSessBlocks * noParSess)
            {
                MessageBox.Show("More sessions than slots. Abort.");
                return;
            }
            _d = new MainUI.ProgressDelegate(_parent.UpdateProgress);
            Schedule emptySched = new Schedule(noParSess, noSessBlocks);
            bool earlyStop = false;
            // int total = BuildAndEvalSchedule(_initMeetings.Count, emptySched, ref _minScore, true, ref earlyStop);

            _d.BeginInvoke("Calculating number of candidate schedules...", 0M, null, null);


            _numC = ScheduleEngine.CalculateNoCombis(_initMeetings.Count, noParSess, noSessBlocks);

            _minScore = Int32.MaxValue;
            emptySched = new Schedule(noParSess, noSessBlocks);
            BuildAndEvalSchedule(_initMeetings.Count, emptySched, ref _minScore, false, ref earlyStop);
            _d.BeginInvoke(String.Format("{0} schedules evaluated. Lowest penalty: {1}", _noEvaluated, _minScore), 100M * (decimal)_noEvaluated/_numC, null, null);
            _parent.Callback(null);
        }

        private static int BuildAndEvalSchedule(int level, Schedule s, ref int bestScore, bool countrun, ref bool earlyStop)
        {
            if (earlyStop)
                return 0;
            if (level == 0)
            {
                if (_noEvaluated % 5000 == 0)
                {
                    lock (uiLock)
                    {
                        earlyStop = stop;
                    }
                }
                if (!countrun)
                {
                    Meeting emptyMeeting = new Meeting(new MeetingSpec("<empty slot>"));
                    for (int i = 0; i < noSessBlocks; i++)
                    {
                        for (int j = s.Meetings[i].Count; j < noParSess; j++)
                        {
                            s.Meetings[i].Add(emptyMeeting);
                        }
                    }

                    int score = s.Evaluate(_penalties);
                    if (score < bestScore)
                    {
                        _solutions.Clear();
                        bestScore = score;
                    }
                    _noEvaluated++;
                    if (_noEvaluated % 5000 == 0)
                    {
                        _d.BeginInvoke(String.Format("{0} of {1} possible schedules evaluated, current lowest penalty: {2}", _noEvaluated, _numC, _minScore), 100M * (decimal)_noEvaluated / _numC, null, null);
                    }                    
                    if (score <= bestScore && _solutions.Count < 128)
                        _solutions.Add(s);
                }
                return 1;
            }
            else
            {
                SortedDictionary<int, List<int>> cnt2idx = new SortedDictionary<int, List<int>>();
                bool seen0 = false;
                for (int i = 0; !seen0 && i < noSessBlocks; i++)
                {
                    int cnt = s.Meetings[i].Count;
                    if (!cnt2idx.ContainsKey(cnt))
                        cnt2idx.Add(cnt, new List<int>());
                    cnt2idx[cnt].Add(i);
                    seen0 = (cnt == 0);
                }
                int runs = 0;
                foreach (int cnt in cnt2idx.Keys)
                {
                    foreach (int i in cnt2idx[cnt])
                    {
                        if (s.Meetings[i].Count < noParSess)
                        {
                            Schedule s2 = s.Clone();
                            s2.Meetings[i].Add(new Meeting(_initMeetings[level - 1]));
                            runs += BuildAndEvalSchedule(level - 1, s2, ref bestScore, countrun, ref earlyStop);
                        }
                    }
                }
                if (countrun && level > 10)
                    _d.BeginInvoke(String.Format("Counting. Level {0} counted {1} schedules", level, runs), 0M, null, null);
                return runs;
            }
        }

        public static void Run_oud()
        {
            facAll = Faculteit(_parent.LVMeetings.Items.Count);
            _minScore = Int32.MaxValue;
            _solutions.Clear();
            noParSess = Convert.ToInt32(_parent.NoParSess);
            noSessBlocks = Convert.ToInt32(_parent.NoSessBlocks);
            if (_parent.LVMeetings.Items.Count > noSessBlocks * noParSess)
            {
                MessageBox.Show("More sessions than slots. Abort.");
                return;
            }

            _d = new MainUI.ProgressDelegate(_parent.UpdateProgress);
            _d.BeginInvoke("begin", 0.0M, null, null);
            List<Schedule> allPerms = BuildPermutations(_initMeetings);
            _d.BeginInvoke("midden", 50.0M, null, null);
            FinishPermutations(ref allPerms);

            System.Diagnostics.Trace.WriteLine("we have " + allPerms.Count + " sessions");

            int pi = 0, pN = allPerms.Count;

            foreach (Schedule pSchedule in allPerms)
            {
                int score = pSchedule.Evaluate(_penalties);
                if (score < _minScore)
                {
                    _minScore = score;
                    _solutions.Clear();
                }
                if (score == _minScore)
                {
                    _solutions.Add(pSchedule);
                }
                if (pi%5000 == 0)
                    _d.BeginInvoke("eval", 50M + (decimal)pi * 50M / pN, null, null);
                pi++;
            }
            _parent.Callback(null);
            _d.BeginInvoke("eind", 100.0M, null, null);
        }

        private static List<Schedule> BuildPermutations(List<MeetingSpec> meetings)
        {
            int level = meetings.Count;
            decimal facPrevLevel = (decimal)Faculteit(level-1);
            decimal facLevel = (decimal)level * facPrevLevel;
            List<Schedule> retval = new List<Schedule>();
            if (meetings.Count == 1)
            {
                for (int i = 0; i < noSessBlocks; i++)
                {
                    Schedule s = new Schedule(noParSess, noSessBlocks);
                    s.Meetings[i].Add(new Meeting(meetings[0]));
                    retval.Add(s);
                }
            }
            else
            {
                MeetingSpec head = meetings[0];
                meetings.RemoveAt(0);
                List<Schedule> perms = BuildPermutations(meetings);
                int pi = 0, pN = perms.Count;
                foreach (Schedule aSchedule in perms)
                {
                    for (int i = 0; i < noSessBlocks; i++)
                    {
                        if (aSchedule.Meetings[i].Count < noParSess)
                        {
                            Schedule cloneSchedule = aSchedule.Clone();
                            cloneSchedule.Meetings[i].Insert(0,new Meeting(head));
                            retval.Add(cloneSchedule);
                        }
                    }
                    if (pi%5000 == 0)
                        _d.BeginInvoke("Building perms (" + level.ToString() + ") " + pi.ToString(), 50M * ((facPrevLevel + (pi/pN)*(facLevel-facPrevLevel)) / facAll), null, null);
                    pi++;
                }
                if (facLevel >= 120)
                {
                    // build a histogram for all score values seen so far
                    SortedDictionary<int, int> hist = new SortedDictionary<int, int>();
                    foreach (Schedule s in retval)
                    {
                        int score = s.Evaluate(_penalties);
                        if (!hist.ContainsKey(score))
                            hist.Add(score, 1);
                        else
                            hist[score]++;
                    }
                    // determine the score threshold that splits 1% - 99%
                    int N = retval.Count;
                    int cumsumCounts = 0;
                    int threshold = int.MaxValue;
                    double thrRatio = .0001; // -((double).6 * level / _parent.LVMeetings.Items.Count);
                    foreach (int sckey in hist.Keys)
                    {
                        double ratio = (double)cumsumCounts / N;
                        if (ratio > thrRatio)
                            break;
                        threshold = sckey;
                        cumsumCounts += hist[sckey];
                    }
                    List<Schedule> retval2 = new List<Schedule>();
                    foreach (Schedule s in retval)
                    {
                        if (s.Score <= threshold)
                            retval2.Add(s);
                    }
                    retval = retval2;
                }
            }
            _d.BeginInvoke("perms", 50M * (facLevel / facAll), null, null);
            return retval;
        }

        private static int Faculteit(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * Faculteit(n - 1);
        }

        private static void FinishPermutations(ref List<Schedule> perms)
        {
            Meeting emptyMeeting = new Meeting(new MeetingSpec("<empty slot>"));
            foreach (Schedule s in perms)
            {
                for (int i = 0; i < noSessBlocks; i++)
                {
                    for (int j = s.Meetings[i].Count; j < noParSess; j++)
                    {
                        s.Meetings[i].Add(emptyMeeting);
                    }
                }
            }
        }

        internal static long CalculateNoCombis(int M, int p, int q)
        {
            List<List<int>> combs = Generate(p, p, q);
            Filter(combs, M, q);

            return Compute(combs, Convert.ToInt64(M));
        }

        private static long Compute(List<List<int>> combs, long M)
        {
            long sum = 0;
            long N;
            foreach (List<int> list in combs)
            {
                N = M;
                long prod = 1;
                for (int i=1; i<list.Count; i++)
                {
                    long tprod = 1;
                    for (int j = 0; j < list[i]; j++)
                    {
                        double f1p = (double)Fac(N) / Fac(N - i);
                        long ttprod = Convert.ToInt64(f1p / Fac(i));
                        tprod *= ttprod;
                        N -= i;
                    }
                    tprod = Convert.ToInt64((double)tprod / Fac(list[i]));
                    prod *= tprod;
                }
                sum += prod;
            }
            return sum;
        }

        private static long Fac(long n)
        {
            if (n <= 1)
                return 1;
            else
                return n * Fac(n - 1);
        }

        private static void Filter(List<List<int>> combs, int M, int q)
        {
            int tM, tB;
            for (int i = combs.Count - 1; i >= 0; i--)
            {
                List<int> thisList = combs[i];
                Count(thisList, out tM, out tB);
                if (tM != M || tB != q)
                    combs.Remove(thisList);
            }
        }

        private static void Count(List<int> list, out int totalM, out int totalB)
        {
            totalM = 0;
            totalB = 0;
            for (int i = 0; i < list.Count; i++)
            {
                totalM += i * list[i];
                totalB += list[i];
            }
            return;
        }

        private static List<List<int>> Generate(int plevel, int p, int q)
        {
            List<List<int>> combs = new List<List<int>>();
            for (int i=0; i <= q; i++)
            {
                if (plevel == 0)
                {
                    List<int> list = new List<int>();
                    list.Add(i);
                    combs.Add(list);
                }
                else
                {
                    List<List<int>> tcombs = Generate(plevel - 1, p, q);
                    List<int> l;
                    for (int j = 0; j < tcombs.Count; j++)
                    {
                        l = new List<int>();
                        foreach (int cc in tcombs[j])
                            l.Add(cc);
                        l.Add(i);
                        combs.Add(l);
                    }
                }
            }
            return combs;
        }

#if UNUSED
        public static int OptimizeBlocks(ref Schedule pSched)
        {
            List<Schedule> blockPermutations = new List<Schedule>();
            PermuteBlocks(pSched, blockPermutations);
            int longestBreak = Int32.MaxValue;
            foreach (Schedule s in blockPermutations)
            {
                int breakLen = EvalLongestResourceBreak(s);
                if (breakLen < longestBreak)
                {
                    pSched = s;
                    longestBreak = breakLen;
                }
            }
            return longestBreak;
        }

        private static void PermuteBlocks(Schedule pSched, ref List<Schedule> pBlockPermutations)
        {
            if (pBlockPermutations.Count == 0)
            {
                Schedule tSched = new Schedule(pSched.NoParSess, pSched.NoSessBlocks);
                tSched.Meetings[0] = pSched.Meetings[0];
            }
        }

        private static int EvalLongestResourceBreak(Schedule pSched)
        {
        }
#endif


    }
}
