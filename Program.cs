using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Channels;
using System.Collections;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

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
            return string.Join(' ', text.ToLower().Where(char.IsLetter).Select(c => c - 96));
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

        //public static bool IsValidWalk(string[] walk)
        //{
        //var direction = new Dictionary<char, int[]> { { 'n', new int[] { 0, -1 } }, { 's', new int[] { 0, 1 } }, { 'w', new int[] { 1, 0 } }, { 'e', new int[] { -1, 0 } } };

        //var t = walk.Select(s => { int[] move = direction[s[0]]; return new int[] { move[0], move[1] }; })
        //    .Aggregate(new int[] { 0, 0 }, (sum, curr) => { sum[0] += curr[0]; sum[1] += curr[1]; return sum; });
        //}
        public static bool IsValidWalk(string[] w) => w.Select(x => x[0] == 'n' ? -0.1f : x[0] == 's' ? 0.1f : x[0] == 'w' ? 1f : -1f).Sum() == 0 && w.Length == 10 ? true : false;
        public static IEnumerable<string> OpenOrSenior(int[][] data) => data.Select(x => x[0] >= 55 && x[1] > 7 ? "Senior" : "Open");

        //public static double[] Tribonacci(double[] signature, int n) => n <= 3 ? Tribonacci(new double[] { signature[1], signature[2], signature.Sum() }, --n).Concat(new[] { signature.Sum() }).ToArray() : signature.Reverse().ToArray();
        public static double[] Tribonacci(double[] signature, int n) => n > 0 ? new double[] { signature[0] }.Concat(Tribonacci(new double[] { signature[1], signature[2], signature.Sum() }, --n)).ToArray() : Array.Empty<double>();// : signature.Reverse().ToArray();
        public static double[] xbonacci(double[] signature, int n) => n > 0 ? new double[] { signature[0] }.Concat(Tribonacci(signature.Skip(1).Append(signature.Sum()).ToArray(), --n)).ToArray() : Array.Empty<double>();
        //{1,0,0,0,0,0,1} 10
        public static int sumTwoSmallestNumbers(int[] n) => n.OrderBy(x => x).Take(2).Sum();
        public static bool IsSquare(int n) => Math.Sqrt(n) % 1 == 0;
        //public static string HighAndLow2(string n) =>  string.Join(n.Split(" ").Select(c=>int.Parse(c)).Where((f,i) => i==0 || i==n.Split(" ").Length - 1));//string.Concat(n.ToList().OrderBy(o => o).ToList().RemoveRange(1, n.ToList().Count() - 2));
        public static string HighAndLow(string n) => $"{n.Split(" ").Select(int.Parse).Max()} {n.Split(" ").Select(int.Parse).Min()}";
        public static double FindAverage(double[] array) => array.DefaultIfEmpty().Average();
        public static string CountSheep(int n) => string.Concat(Enumerable.Range(1, n).Select(j => $"{j} sheep..."));
        public static string CountSheep2(int n) => string.Concat(new int[n].Select((_, i) => $"{i + 1} sheep..."));
        //public static IEnumerable<int> GetIntegersFromList(List<object> l) => l.Where(x => int.TryParse(x.ToString(), out int r)).Select(v => int.Parse(v.ToString()));
        //public static IEnumerable<int> GetIntegersFromList(List<object> l) => l.Where(x => x.GetType() == typeof(int)).Select(c=>(int)c);
        public static IEnumerable<int> GetIntegersFromList(List<object> l) => l.OfType<int>();
        public static string seriesSum(int n) => Math.Round((decimal)Enumerable.Range(0, n).Select((_, i) => 1 / (i * 3M + 1M)).Sum(), 2).ToString("0.00");
        public static string SeriesSum(int n) => Enumerable.Range(0, n).Sum(i => 1.0 / (i * 3 + 1)).ToString("0.00");
        public static string RepeatStr(int n, string s) => $"{string.Concat(Enumerable.Range(1, n).Select((_, i) => s))}";
        public static string repeatStr(int n, string s) => String.Concat(Enumerable.Repeat(s, n));
        public static long findNb(long m)
        {
            long i = 1;
            for (; m > 0; i++)
            { Console.WriteLine($"{m}      {i}"); m -= i * i * i; }
            return m == 0 ? i - 1 : -1;
        }
        public static string RemoveExclamationMarks(string s) => s.Replace("!", "");
        public static string FakeBin(string x) => string.Join("", x.Select(d => d > 52 ? 1 : 0));
        public static int[] ReverseSeq(int n) => Enumerable.Range(1, n).Reverse().ToArray();
        public static int СenturyFromYear(int y) => (y % 100 == 0) ? y / 100 : y / 100 + 1;
        public int GetSum(int a, int b) => Enumerable.Range(Math.Min(a, b), Math.Abs(a) + Math.Abs(b)).Sum();
        public static int Grow(int[] x) => x.Aggregate((agg, cur) => agg *= cur);
        public static char GetGrade(int s1, int s2, int s3) => new Dictionary<int, char> { { 0, 'F' }, { 1, 'F' }, { 2, 'F' }, { 3, 'F' }, { 4, 'F' }, { 5, 'F' }, { 6, 'D' }, { 7, 'C' }, { 8, 'B' }, { 9, 'A' }, { 10, 'A' } }[(s1 + s2 + s3) / 30];
        public static int GetUnique(IEnumerable<int> n) => n.ToLookup(v => v).Where(c => c.Count() == 1).Select(x => x.Key).FirstOrDefault();
        public static int GetUnique2(IEnumerable<int> numbers) => numbers.First(x => numbers.Count(i => i == x) == 1);
        public static int GetUnique3(IEnumerable<int> numbers) => numbers.GroupBy(x => x).Single(x => x.Count() == 1).Key;
        public static int[] minMax(int[] lst) => new int[] { lst.Min(), lst.Max() };
        public static string High2(string s)
        {
            var result = s.Split()
                .Select( (w, i) => (Word: w, Index: i, Sum: w.Aggregate(0, (agr, cur) => agr + cur)))
                .OrderByDescending(x => x.Sum) 
                .First().Word;
            return result;
        }
        public static string High(string s) => s.Split().Select(w => (W: w, V: w.Sum(l => l - 'a' + 1))).OrderByDescending(o => o.V).First().W;
        public static string High3(string s) => s.Split().OrderBy(a => a.Select(b => b - 96).Sum()).Last();
        public static int CountSmileys(string[] s) => new HashSet<string> { ":)", ":-)", ";)", ";-)", ";D", ":D", ":-D", ";)", ";-D", ":~)", ";~D", ":~D", ";~)" }.Count(s.Contains);
        public static int CountSmileys2(string[] smileys) => Regex.Matches(string.Join(" ", smileys), "([:;][-~]?)[)D]").Count;
        public static int[] CountPositivesSumNegatives(int[] i) => i != null && i.Length > 0 ? new int[] { i.Count(n => n > 0), i.Aggregate(0, (agg, cur) => cur < 0 ? agg += cur : agg) } : Array.Empty<int>();
        public static bool lovefunc(int flower1, int flower2) => flower1 % 2 != flower2 % 2;
        public static IEnumerable<string> FriendOrFoe(string[] names) => names.Where(n => n.Count() == 5);



        internal class Program
        {
            static void Main(string[] args)
            {
                //Console.WriteLine(Kata1.Disemvowel("Hello world!"));
                //Console.WriteLine(code_snippets.Kata2.Order("is2 Thi1s T4est 3a"));
                //code_snippets.Kata2.xbonacci(new double[] { 1, 0, 0, 0, 0, 0, 1 }, 10).ToList().ForEach(x=> Console.WriteLine(x.ToString()));//.Select(x => { Console.WriteLine(x.ToString()); return x; });
                Console.WriteLine(code_snippets.Kata2.High("man i need a taxi up to ubud"));

            }

        }
    }
}




