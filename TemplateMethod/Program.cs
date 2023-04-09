using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            Console.WriteLine("Men");
            algorithm = new MenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(20,new TimeSpan(0,5,0)));

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(20, new TimeSpan(0, 3, 0)));

            Console.WriteLine("Children");
            algorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(25, new TimeSpan(0, 2, 0)));

            Console.ReadLine();
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        protected abstract int CalculateOverallScore(int score, int reduction);
        protected abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);
    }
    class MenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
        protected override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
        protected override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }
    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
        protected override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
        protected override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }
    class ChildrenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }
        protected override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
        protected override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }
}
