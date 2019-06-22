using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
 public static class Program
 {
 static void Main(string[] args)
 {
 Test(new[] {"12:12:12"}, new [] { "few seconds ago" }, "12:12:12");
 Test(new[] { "23:23:23", "23:23:23" }, new[] { "59 minutes ago", "59 minutes ago" }, "00:22:23");
 Test(new[] { "00:10:10", "00:10:10" }, new[] { "59 minutes ago", "1 hours ago" }, "impossible");
 Test(new[] { "11:59:13", "11:13:23", "12:25:15" }, new[] { "few seconds ago", "46 minutes ago", "23 hours ago" }, "11:59:23");
 Console.ReadKey(true);
 }

 private static void Test(string[] postTimes, string[] showTimes, string expected)
 {
 var result = GetCurrentTime(postTimes, showTimes).Equals(expected) ? "PASS" : "FAIL";
 var postTimesCsv = string.Join(", ", postTimes);
 var showTimesCsv = string.Join(", ", showTimes);
 Console.WriteLine($"[{postTimesCsv}], [{showTimesCsv}] => {result}");
 }

 public static string GetCurrentTime(string[] exactPostTime, string[] showPostTime)
 {
	 int[] pStart = null;
	 int[] pEnd = null;

	for (int i = 0; i < exactPostTime.Length; i++)
	 {
		 DateTime pDStart = DateTime.Now,
		 pDEnd = DateTime.Now,
		 cDStart = DateTime.Now, 
		 cDEnd = DateTime.Now;
		 if (pStart == null && pEnd == null) {
		 string[] cStSplit = exactPostTime[i].Split(':');
		 pStart = new[] {int.Parse(cStSplit[0]), 
		 int.Parse(cStSplit[1]),
		 int.Parse(cStSplit[2])};

		 int[] gTime = Program.getTime(showPostTime[i]);
		 
		 if (gTime[3] == 1)
		 {
				 pStart[0] = (gTime[0] + pStart[0]) % 24;
				 gTime[0] = pStart[0];
				 gTime[1] = pStart[1];
				 gTime[2] = pStart[2];

				 gTime[2] = (gTime[2] + 59);
				 if (gTime[2] >= 60) gTime[1] += 1;
				 gTime[2] %= 60;

				 gTime[1] = (gTime[1] + 59);
				 if (gTime[1] >= 60) gTime[0] += 1;
				 gTime[1] %= 60;
				 gTime[0] %= 24;
				 
		 
		 } else if (gTime[4] == 1) 
		 {

		 pStart[1] = (gTime[1] + pStart[1]);
		 if (pStart[1] >= 60) pStart[0] = (pStart[0] + 1) % 24;
		 pStart[1] %= 60;
		 gTime[1] = pStart[1];
		 gTime[0] = pStart[0];
		 gTime[2] = pStart[2];
		 
		 gTime[2] = (gTime[2] + 59);
		 if (gTime[2] >= 60) gTime[1] += 1;
		 gTime[2] %= 60;

		 if (gTime[1] >= 60) gTime[0] += 1;
		 gTime[1] %= 60;
		 gTime[0] %= 24;
		 
		 } else 
		 {
		 gTime[2] = (gTime[2] + pStart[2]);
		 gTime[1] = pStart[1];
		 gTime[0] = pStart[0];

		 if (gTime[2] >= 60) gTime[1] += 1;
		 gTime[2] %= 60;

		 if (gTime[1] >= 60) gTime[0] += 1;
		 gTime[1] %= 60;
		 gTime[0] %= 24;
		 }
		pEnd = new[] {gTime[0], gTime[1], gTime[2]};
		continue;
	}
	else 
	{
	 string[] cStSplit = exactPostTime[i].Split(':');
	 int[] cStart = new[] {int.Parse(cStSplit[0]),
	 int.Parse(cStSplit[1]),
	 int.Parse(cStSplit[2])};

	 int[] gTime = Program.getTime(showPostTime[i]);
 
	 if (gTime[3] == 1)
	 {
	 cStart[0] = (gTime[0] + cStart[0]) % 24;
	 gTime[0] = cStart[0];
	 gTime[1] = cStart[1];
	 gTime[2] = cStart[2];

	 gTime[2] = (gTime[2] + 59);
	 if (gTime[2] >= 60) gTime[1] += 1;
	 gTime[2] %= 60;

	 gTime[1] = (gTime[1] + 59);
	 if (gTime[1] >= 60) gTime[0] += 1;
	 gTime[1] %= 60;
	 gTime[0] %= 24;
 
	} else if (gTime[4] == 1)
	 {

	 cStart[1] = (gTime[1] + cStart[1]);
	 if (cStart[1] >= 60) cStart[0] = (cStart[0] + 1) % 24;
	 cStart[1] %= 60;
	 gTime[1] = cStart[1];
	 gTime[0] = cStart[0];
	 gTime[2] = cStart[2];
	 
	 gTime[2] = (gTime[2] + 59);
	 if (gTime[2] >= 60) gTime[1] += 1;
	 gTime[2] %= 60;

	 if (gTime[1] >= 60) gTime[0] += 1;
	 gTime[1] %= 60;
	 gTime[0] %= 24;
	 } else 
	 {
		gTime[2] = (gTime[2] + cStart[2]);
		gTime[1] = cStart[1];
		gTime[0] = cStart[0];

		if (gTime[2] >= 60) gTime[1] += 1;
		gTime[2] %= 60;

		if (gTime[1] >= 60) gTime[0] += 1;
		gTime[1] %= 60;
		gTime[0] %= 24;
 }
         int[] currentEnd = new[] {gTime[0], gTime[1], gTime[2]};

         pDStart = new DateTime(1, 1, 1, pStart[0], pStart[1], pStart[2]);
         cDStart = new DateTime(1, 1, 1, cStart[0], cStart[1], cStart[2]);

         if (pStart[0] <= pEnd[0]) 
         {
            pDEnd = new DateTime(1, 1, 1, pEnd[0], pEnd[1], pEnd[2]);
         } else 
         {
            pDEnd = new DateTime(1, 1, 2, pEnd[0], pEnd[1], pEnd[2]);
         }

         if (cStart[0] <= currentEnd[0]) 
         {
            cDEnd = new DateTime(1, 1, 1, currentEnd[0], currentEnd[1], currentEnd[2]);
         } else 
         {
            cDEnd = new DateTime(1, 1, 2, currentEnd[0], currentEnd[1], currentEnd[2]);
         }

         if (DateTime.Compare(cDStart, pDStart) >= 0 &&DateTime.Compare(cDStart, pDEnd) <= 0 &&
         DateTime.Compare(cDEnd, pDEnd) >=0) 
         {
            pStart = new[] {cDStart.Hour, cDStart.Minute, cDStart.Second};
            pEnd = new[] {pDEnd.Hour, pDEnd.Minute, pDEnd.Second};
         } else if (DateTime.Compare(cDStart, pDStart) <= 0 &&
         DateTime.Compare(pDEnd, cDEnd) <=0 )
         {
            pStart = new[] {pDStart.Hour, pDStart.Minute, pDStart.Second};
            pEnd = new[] {pDEnd.Hour, pDEnd.Minute, pDEnd.Second};
         } else if (DateTime.Compare(pDStart, cDStart) >= 0 &&
         DateTime.Compare(pDStart, cDEnd) <= 0 &&
         DateTime.Compare(pDEnd, cDEnd) >= 0)
         {
            pStart = new[] {pDStart.Hour, pDStart.Minute, pDStart.Second};
            pEnd = new[] {cDEnd.Hour, cDEnd.Minute, cDEnd.Second};
         } else if (DateTime.Compare(pDStart, cDStart) <= 0 &&
         DateTime.Compare(cDEnd, pDEnd) <= 0)
         {
            pStart = new[] {cDStart.Hour, cDStart.Minute, cDStart.Second};
            pEnd = new[] {cDEnd.Hour, cDEnd.Minute, cDEnd.Second};
         } else 
         {
            return "impossible";
         }
         }
         }
         if (pEnd[0] < pStart[0]) 
         {
            return "00:00:00";
         } 
         string hr = $"{pStart[0]}";
         if (hr.Length == 1) hr = "0" + hr;
         string min = $"{pStart[1]}";
         if (min.Length == 1) min = "0" + min;
         string sec = $"{pStart[2]}";
         if (sec.Length == 1) sec = "0" + sec;
         return $"{hr}:{min}:{sec}";
         }

 public static int[] getTime(string post) {
 var t = post.Split(' ');

 int dur;
 if (t[0].Length == 3) 
 {
	dur = 59;
 } else 
 {
	dur = int.Parse(t[0]);
 }

 if (post.IndexOf("seconds") != -1) 
 {
	return new[] {0, 0, dur, 0, 0, 1};
 } else if (post.IndexOf("minutes") != -1) 
 {
	return new[] {0, dur, 0, 0, 1, 0};
 } else 
 {
	return new[] {dur, 0, 0, 1, 0, 0};
 }
 }
 }
}
