namespace TestProject.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class WayFair
    {
        public static List<int[]> FindRectangeCoordinates(int[][] rect)
        {
            int rows = rect.GetUpperBound(0) + 1;
            int cols = rect[0].Length;
            List<int[]> result = new List<int[]>();
            bool outerloop = false;
            bool innerloop = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (rect[i][j] == 0)
                    {
                        result.Add(new int[] { i, j });
                        outerloop = true;
                        break;
                    }
                }

                if (outerloop)
                {
                    break;
                }
            }

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (rect[i][j] == 0)
                    {
                        result.Add(new int[] { i, j });
                        innerloop = true;
                        break;
                    }
                }

                if (innerloop)
                {
                    break;
                }
            }

            return result;
        }
        public static void FindRectangleLengthAndBreath(int[][] rect)
        {
            int rows = rect.GetUpperBound(0) + 1;
            int cols = rect[0].Length;

            int height = 1;
            int width = 1;
            List<int> points = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (rect[i][j] == 0)
                    {
                        points.Add(i);
                        points.Add(j);

                        while (i + height < rows && rect[i + height][j] == 0)
                        {
                            height++;
                        }

                        while (j + width < cols && rect[i][j + width] == 0)
                        {
                            width++;
                        }

                        break;
                    }
                }

                if (points.Count() > 0)
                {
                    break;
                }
            }

        }

        public static void FindMultipleRectangleStartEnd(int[][] rect)
        {
            List<List<int>> result = new List<List<int>>();
            int rows = rect.GetUpperBound(0) + 1;
            int cols = rect[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (rect[i][j] == 0)
                    {
                        result.Add(new List<int>() { i, j });


                        int height = 1, width = 1;

                        rect[i][j] = 1;

                        while (i + height < rows && rect[i + height][j] == 0)
                        {
                            height++;
                            rect[i + height][j] = 1;
                        }

                        while (j + width < cols && rect[i][j + width] == 0)
                        {
                            width++;
                            rect[i][j + width] = 1;
                        }

                        for (int k = 0; k < height; k++)
                        {
                            for (int m = 0; m < width; m++)
                            {
                                rect[i + k][j + m] = 1;
                            }
                        }

                        result.Add(new List<int>() { i + height - 1, j + width - 1 });
                    }

                }
            }
        }

        public static IList<string> SubdomainVisits(string[] cpdomains)
        {
            List<string> result = new List<string>();

            //Input cpdomains = ["900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"]
            //Output: ["901 mail.com","50 yahoo.com","900 google.mail.com","5 wiki.org","5 org","1 intel.mail.com","951 com"]

            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (string str in cpdomains)
            {
                string[] input = str.Split(' ');
                int count = Convert.ToInt32(input[0]);

                string[] arr = input[1].Split('.');
                string temp = string.Empty;

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    temp = arr[i] + "." + temp;

                    if (temp[temp.Length - 1] == '.')
                    {
                        temp = temp.Substring(0, temp.Length - 1);
                    }

                    if (map.ContainsKey(temp))
                    {
                        map[temp] = map[temp] + count;
                    }
                    else
                    {
                        map.Add(temp, count);
                    }
                }
            }

            foreach (var pair in map)
            {
                string o = pair.Value + " " + pair.Key;
                result.Add(o);
            }

            return result;
        }
        public static IList<string> SubdomainVisitsPractice(string[] cpdomains)
        {
            List<string> result = new List<string>();
            Dictionary<string, int> map = new Dictionary<string, int>();

            //Input cpdomains = ["900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"]
            //Output: ["901 mail.com","50 yahoo.com","900 google.mail.com","5 wiki.org","5 org","1 intel.mail.com","951 com"]

            foreach (string input in cpdomains)
            {
                string[] parts = input.Split(' ');

                int count = Convert.ToInt32(parts[0]);

                string[] domain = parts[1].Split('.');

                string str = string.Empty;

                for (int i = domain.Length - 1; i >= 0; i--)
                {
                    str = domain[i] + "." + str;

                    if (str[str.Length - 1] == '.')
                    {
                        str = str.Substring(0, str.Length - 1);
                    }

                    if (map.ContainsKey(str))
                    {
                        map[str] = map[str] + count;
                    }
                    else
                    {
                        map[str] = count;
                    }
                }
            }

            foreach (var pair in map)
            {
                result.Add(pair.Value + " " + pair.Key);
            }


            return result;

        }


        public static void GetUserLoginLogoutTime(List<List<string>> logs)
        {
            /*logs1 = [
            ["58523", "user_1", "resource_1"],
["62314", "user_2", "resource_2"],
["54001", "user_1", "resource_3"],
["200", "user_6", "resource_5"],
["215", "user_6", "resource_4"],
["54060", "user_2", "resource_3"],
["53760", "user_3", "resource_3"],
["58522", "user_22", "resource_1"],
["53651", "user_5", "resource_3"],
["2", "user_6", "resource_1"],
["100", "user_6", "resource_6"],
["400", "user_7", "resource_2"],
["100", "user_8", "resource_6"],
["54359", "user_1", "resource_3"],
            */

            Dictionary<string, HashSet<string>> map = new Dictionary<string, HashSet<string>>();

            foreach (var log in logs)
            {
                string[] logdata = log.ToArray();
                string userId = logdata[1];
                string userTime = logdata[0];

                if (map.ContainsKey(userId))
                {
                    map[userId].Add(userTime);
                }
                else
                {
                    map.Add(userId, new HashSet<string>() { userTime });
                }
            }

            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            foreach (var pair in map)
            {
                result.Add(pair.Key, new List<string>() { pair.Value.Min(), pair.Value.Max() });
                Console.WriteLine(pair.Key + " " + pair.Value.Min() + " " + pair.Value.Max());
            }

        }


        public static List<string> FindContiguosHistory(List<string> user1, List<string> user2)
        {
            //user0 = ["/start", "/green", "/blue", "/pink", "/register", "/orange","/one/two"]
            //user1 = ["/start", "/pink", "/register", "/orange", "/red", "a"]
            List<string> result = new List<string>();

            int[,] dp = new int[user1.Count() + 1, user2.Count() + 1];
            int max = int.MinValue;
            int lastIndex = -1;

            for (int i = user1.Count() - 1; i >= 0; i--)
            {
                for (int j = user2.Count() - 1; j >= 0; j--)
                {
                    if (user1[i].Equals(user2[j]))
                    {
                        dp[i, j] = 1 + dp[i + 1, j + 1];
                        if (max < dp[i, j])
                        {
                            lastIndex = j;
                            max = dp[i, j];

                        }

                        break;
                    }
                }
            }

            for (int i = lastIndex; i < lastIndex + max; i++)
            {
                result.Add(user2[i]);
            }

            return result;

        }
        public static List<string> FindContiguosHistoryPractice(List<string> user1, List<string> user2)
        {
            //user0 = ["/start", "/green", "/blue", "/pink", "/register", "/orange","/one/two"]
            //user1 = ["/start", "/pink", "/register", "/orange", "/red", "a"]
            List<string> result = new List<string>();

            int[,] dp = new int[user1.Count() + 1, user2.Count() + 1];
            int max = int.MinValue;
            int startIndex = int.MaxValue;

            for (int i = user1.Count() - 1; i >= 0; i--)
            {
                for (int j = user2.Count() - 1; j >= 0; j--)
                {
                    if (user1[i].Equals(user2[j]))
                    {
                        dp[i, j] = dp[i + 1, j + 1] + 1;

                        if (dp[i, j] > max)
                        {
                            startIndex = j;
                            max = dp[i, j];
                        }

                        break;
                    }
                }
            }

            for (int j = startIndex; j < startIndex + max; j++)
            {
                result.Add(user2[j]);
            }

            return result;
        }


        public static void GetClicksDataResult(List<string> userIds, List<string> adClicks, List<string> userIps)
        {
            Dictionary<string, int> countMap = new Dictionary<string, int>();
            Dictionary<string, string> ipUserMap = new Dictionary<string, string>();
            Dictionary<string, int> resultMap = new Dictionary<string, int>();

            /*
             ad_clicks = [
#"IP_Address,Time,Ad_Text",
"122.121.0.1,2016-11-03 11:41:19,Buy wool coats for your pets",
"96.3.199.11,2016-10-15 20:18:31,2017 Pet Mittens",
"122.121.0.250,2016-11-01 06:13:13,The Best Hollywood Coats",
"82.1.106.8,2016-11-12 23:05:14,Buy wool coats for your pets",
"92.130.6.144,2017-01-01 03:18:55,Buy wool coats for your pets",
"122.121.0.155,2017-01-01 03:18:55,Buy wool coats for your pets",
"92.130.6.145,2017-01-01 03:18:55,2017 Pet Mittens",
]
             */
            foreach (string input in adClicks)
            {
                string[] parts = input.Split(',');
                string adName = parts[2];
                if (countMap.ContainsKey(adName))
                {
                    countMap[adName]++;
                }
                else
                {
                    countMap.Add(adName, 1);
                }
            }

            foreach (string input in userIps)
            {
                string[] parts = input.Split(',');
                string ipaddress = parts[1];
                string userId = parts[0];

                if (!ipUserMap.ContainsKey(ipaddress))
                {
                    ipUserMap.Add(ipaddress, userId);
                }
            }

            foreach (string input in adClicks)
            {

                string[] parts = input.Split(',');
                string ipaddress = parts[0];
                string adname = parts[2];

                if (ipUserMap.ContainsKey(ipaddress))
                {
                    string userId = ipUserMap[ipaddress];

                    if (userIds.Contains(userId))
                    {
                        if (resultMap.ContainsKey(adname))
                        {
                            resultMap[adname]++;
                        }
                        else
                        {
                            resultMap.Add(adname, 1);
                        }
                    }
                }
            }

            List<string> result = new List<string>();

            foreach (var pair in countMap)
            {
                string temp = string.Empty;

                if (resultMap.ContainsKey(pair.Key))
                {
                    temp = resultMap[pair.Key] + " of " + pair.Value + " " + pair.Key;
                }
                else
                {
                    temp = "0" + " of " + pair.Value + " " + pair.Key;
                }

                result.Add(temp);
            }

            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
        }
        public static void GetClicksDataResultPractice(List<string> userIds, List<string> adClicks, List<string> userIps)
        {
            //"122.121.0.1,2016-11-03 11:41:19,Buy wool coats for your pets",

            Dictionary<string, int> totalCountMap = new Dictionary<string, int>();
            Dictionary<string, string> mapUserIpWithUserId = new Dictionary<string, string>();
            Dictionary<string, int> midData = new Dictionary<string, int>();


            foreach (string ad in adClicks)
            {
                string[] partsOfAd = ad.Split(',');
                string adDesc = partsOfAd[2];

                if (totalCountMap.ContainsKey(adDesc))
                {
                    totalCountMap[adDesc]++;
                }
                else
                {
                    totalCountMap[adDesc] = 1;
                }
            }

            foreach (string pair in userIps)
            {
                string[] parts = pair.Split(',');
                string ipAddress = parts[1];
                string userId = parts[0];

                if (!mapUserIpWithUserId.ContainsKey(ipAddress))
                {
                    mapUserIpWithUserId.Add(ipAddress, userId);
                }
            }

            foreach (string ad in adClicks)
            {

                string[] adParts = ad.Split(',');
                string ipAdderess = adParts[0];
                string adName = adParts[2];

                if (mapUserIpWithUserId.ContainsKey(ipAdderess))
                {
                    string userId = mapUserIpWithUserId[ipAdderess];

                    if (userIds.Contains(userId))
                    {
                        if (midData.ContainsKey(adName))
                        {
                            midData[adName]++;
                        }
                        else
                        {
                            midData.Add(adName, 1);
                        }
                    }
                }
            }

            foreach (var pair in totalCountMap)
            {
                if (midData.ContainsKey(pair.Key))
                {
                    Console.WriteLine(midData[pair.Key] + " of " + totalCountMap[pair.Key] + " " + pair.Key.ToString());
                }
                else
                {
                    Console.WriteLine("0" + " of " + totalCountMap[pair.Key] + " " + pair.Key.ToString());
                }
            }
        }


        public static void OverlapCoursed(List<List<string>> input)
        {
            /*student_course_pairs_1 = [
            ["58", "Software Design"],
  ["58", "Linear Algebra"],
  ["94", "Art History"],
  ["94", "Operating Systems"],
  ["17", "Software Design"],
  ["58", "Mechanics"],
  ["58", "Economics"],
  ["17", "Linear Algebra"],
  ["17", "Political Science"],
  ["94", "Economics"],
  ["25", "Economics"],
            
]
            */
            /*
             [58, 17]: ["Software Design", "Linear Algebra"]
[58, 94]: ["Economics"]
[58, 25]: ["Economics"]
[94, 25]: ["Economics"]
[17, 94]: []
            [17, 25]: []
            */

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            HashSet<string> students = new HashSet<string>();


            foreach (var course in input)
            {
                string studentId = course[0];
                string courseTaken = course[1];
                students.Add(studentId);
                if (map.ContainsKey(studentId))
                {
                    map[studentId].Add(courseTaken);
                }
                else
                {
                    map.Add(studentId, new List<string>() { courseTaken });
                }
            }

            List<string> studentsIds = students.ToList();

            List<string> pairs = new List<string>();

            for (int i = 0; i < studentsIds.Count(); i++)
            {
                for (int j = i + 1; j < studentsIds.Count(); j++)
                {
                    string temp = studentsIds[i] + "," + studentsIds[j];
                    pairs.Add(temp);
                }
            }

            Dictionary<string, List<string>> resultMap = new Dictionary<string, List<string>>();

            foreach (var pair in pairs)
            {
                string[] studentsdata = pair.Split(',');

                string singleStudent = studentsdata[0];
                string secondStudent = studentsdata[1];

                List<string> firstStudentCourses = new List<string>();
                List<string> secondStudentCourses = new List<string>();

                if (map.ContainsKey(singleStudent))
                {
                    firstStudentCourses = map[singleStudent];
                }

                if (map.ContainsKey(secondStudent))
                {
                    secondStudentCourses = map[secondStudent];
                }


                var common = firstStudentCourses.Intersect(secondStudentCourses);
                resultMap.Add(pair, common.ToList());


            }

        }

        public static int CountSubSequence(string str)
        {
            int[] dp = new int[str.Length + 1];
            dp[0] = 1;

            Dictionary<char, int> map = new Dictionary<char, int>();

            for(int i=1;i<dp.Length;i++)
            {
                char ch = str[i - 1];

                dp[i] = dp[i - 1] * 2;
                if(map.ContainsKey(ch))
                {
                    int index = map[ch];

                    dp[i] = dp[i] - dp[index - 1];

                    map[ch] = i;
                }
                else
                {
                    map.Add(ch, i);
                }
            }

            return dp[str.Length] - 1;
        }

    }
}

