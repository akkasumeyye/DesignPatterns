using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Program // bir method içinde farklı operasyonlar oldugunu dusun 3 farklı işlem farklı method ile cagırıyoruz, farklı durumda farklı favrandıgını dusun. bunu kolaylastırmak tek sablon içinde tanımlamak
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            Console.WriteLine("Mans");
            algorithm = new MensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

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

        public abstract int CalculateOverallScore(int scores, int reduction);

        public abstract int CalculateReduction(TimeSpan time);

        public abstract int CalculateBaseScore(int hits);
    }

    class MensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }

    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }

    class ChildrenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }
}
