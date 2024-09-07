using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace code_snippets
{

    public static class Kata1
    {
        public static string Disemvowel(string str) => string.Concat(str.Where(ch => !"aeiouAEIOU".Contains(ch)));
        public static string Disemvowel1(string str)
        {
            //    return string.Concat(str.Where(ch => !"aeiouAEIOU".Contains(ch)));
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return string.Concat(str.Where(x => !vowels.Contains(x)));
        }
    }


    public class Kata2
    {
        public static string DuplicateEncode(string word)
        {
            word = word.ToLower();
            List<char> new_word = new();
            foreach (char ch in word)
                if (word.Count(x => x == ch) > 1) new_word.Add(')');
                else new_word.Add('(');
            return string.Concat(new_word);

            //word = word.ToLower();
            //return string.Concat(word.Select(ch => word.Count(x => x == ch) > 1 ? ')' : '('));

        }

        public static int DuplicateCount(string str)
        {
            /*Dictionary<char,int> ch = new Dictionary<char,int>();
            str = str.ToLower();
            foreach(var l in str)
                if (ch.ContainsKey(l)) ch[l]++;
                else ch[l] = 1;
            return ch.Count(c => c.Value > 1);
            */
            //str = str.ToLower();
            return str.ToLower().GroupBy(c => c).Count(g => g.Count() > 1);
        }

        public static string GetMiddle(string s)
        {
            if (s.Length % 2 == 0 && s.Length > 1) return s.Substring(s.Length / 2 - 1, 2);
            else return s.Substring(s.Length / 2, 1);
            //return s.Length % 2 == 0 && s.Length > 1 ? s.Substring(s.Length / 2 - 1, 2) : s.Substring(s.Length / 2, 1);
        }
        //public static string GetMiddle(string s) => s.Length % 2 == 0 && s.Length > 1 ? s.Substring(s.Length / 2 - 1, 2) : s.Substring(s.Length / 2, 1);

        public static bool IsPangram(string str)
        {
            //var ns = string.Concat(str.ToLower().Where(x => "qwertyuiopasdfghjklzxcvbnm".Contains(x)));
            return string.Concat(str.ToLower().Where(x => "qwertyuiopasdfghjklzxcvbnm".Contains(x))).ToHashSet().Count() < 26 ? false : true;
            //return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;
        }
        public static bool ValidatePin(string pin)
        {
            var count = pin.Count(p => Char.IsDigit(p));
            return count == pin.Length && (count == 4 || count == 6) ? true : false;
        }
        //public static bool ValidatePin2(string pin) => (pin.Length == 4 || pin.Length == 6) && pin.All(Char.IsDigit);
        public static int PositiveSum(int[] arr) => arr.Where(x => x >= 0).Sum();
        public static string MakeComplementInDNA(string dna) => string.Concat(dna.Select(c => "AGCT"["TCGA".IndexOf(c)]));

        public static long digPow(int n, int p)
        {
            int sum = n.ToString().Select((d, i) => (int)Math.Pow(char.GetNumericValue(d), p + i)).Sum();
            return sum % n == 0 ? sum / n : -1;
        }

        public static string Order(string words)
        {
            if (words.Length == 0) return "";
            string[] words_arr = words.Split(' ');
            string[] newWords = new string[words_arr.Length];
            foreach (var w in words_arr)
            {
                var value = w.FirstOrDefault(l => char.IsDigit(l));
                var index = (int)char.GetNumericValue(value);
                newWords[index - 1] = w;
            }
            return string.Join(" ", newWords);
            //return string.Join(" ", words.Split().OrderBy(w => w.SingleOrDefault(char.IsDigit)));
        }

        public static int GetVowelCount(string str)
        {
            int vowelCount = 0;
            str.Where(x => "aeiou".Contains(x)).Count();
            // Your code here

            return vowelCount;
        }

        public static string AlphabetPosition(string text)
        {
            return string.Join(' ', text.ToLower().Where(char.IsLetter).Select(c => c -96));
        }

        public static string Longest(string s1, string s2)
        {
            return string.Concat(string.Concat(s1 + s2).ToHashSet().OrderBy(x => x).ToArray());
        }
        //        return new string ((s1 +s2).Distinct().OrderBy(x=>x).ToArray ());

        /*
        numbers.Where(n => n % 2 == 0);
        numbers.Select(n => n * n);
        numbers.Where(n => n % 2 == 0).Select(n => n * n);
        names.OrderBy(n => n.Length);
        names.OrderByDescending(n => n.Length);
        people.GroupBy(p => p.Age);
        numbers.Where(n => n > 5).ToList();
        numbers.Select(n => n * 2).ToArray();
        numbers.First();
        numbers.FirstOrDefault(n => n > 10);
        numbers.Last();
        numbers.LastOrDefault(n => n < 10);
        numbers.Any(n => n % 2 == 0);
        numbers.All(n => n > 0);
        numbers.Sum();
        numbers.Count(n => n > 5);
        numbers.Max();
        numbers.Distinct();
        numbers.Skip(3);
        numbers.Take(3);
        numbers1.Union(numbers2);
        numbers1.Intersect(numbers2); including only elements that appear in both collections
        numbers1.Except(numbers2);   difference of two sequences, excluding elements in the second collection from the first.
        return ts.Aggregate((closest, current) =>
            Math.Abs(current) < Math.Abs(closest) ||
            (Math.Abs(current) == Math.Abs(closest) && current > closest)
        ? current
        : closest);
         */

        public static bool IsIsogram(string str) => str.ToLower().ToHashSet().Count() == str.Length ? true : false;
        public static int NbYear(int p0, double percent, int aug, int p) => p0 >= p ? 0 : 1 + NbYear((int)(p0 + p0 * percent / 100 + aug), percent, aug, p);
        public static string ReverseWords(string str) => string.Join(' ', str.Split(' ').Select(w => string.Concat(w.Reverse())));
        public static int StringToNumber(String str) => Convert.ToInt32(str);

        public static bool IsValidWalk(string[] walk)
        {

            var direction = new Dictionary<char, int[]> { { 'n', new int[] { 0, -1 } }, { 's', new int[] { 0, 1 } }, { 'w', new int[] { 1, 0 } }, { 'e', new int[] { -1, 0 } } };
            //var t = walk.Select(s => { int[] move = direction[s[0]]; int x = move[0]; int y = move[1]; return new int[] { x, y }; }).Select(c => c[0].Sum(); c[1].Sum());

            var t = walk.Select(s => { int[] move = direction[s[0]]; return new int[] { move[0], move[1] }; }).Aggregate(new int[] { 0, 0 }, (sum, curr) => { sum[0] += curr[0]; sum[1] += curr[1]; return sum; });
   // {
     //   int[] move = direction[s[0]];
       // return new int[] { move[0], move[1] };
   // })
    //.Aggregate(new int[] { 0, 0 }, (acc, curr) =>
    //{
     //   acc[0] += curr[0];
      //  acc[1] += curr[1];
      //  return acc;
    //});

            return false;
        }

        var movements = walk.Select(s =>
        {
            int[] move = direction[s[0]];
            int x = move[0];
            int y = move[1];
            return new int[] { x, y };
        }).ToArray();


    }

}

    internal class Program
    {
        static void Main(string[] args)
        {
        //Console.WriteLine(Kata1.Disemvowel("Hello world!"));
        //Console.WriteLine(code_snippets.Kata2.Order("is2 Thi1s T4est 3a"));
        Console.WriteLine( code_snippets.Kata2.ReverseWords("This is an example!"));
        }
    }



