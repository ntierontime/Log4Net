using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using MathNet.Numerics.Statistics;

namespace MathNet.Numerics.LinqExtensions
{
    public static class StatisticalAggregates
    {

        // Calculate the stdev value for a collection of type Double.
        public static double StDev(this IEnumerable<double> stDevAggregate)
        {
            return stDevAggregate.StandardDeviation();
        }

        // Project the collection of generic items as type Double and calculate the stdev value.
        public static double StDev<T>(this IEnumerable<T> stDevAggregate, Func<T, double> selector)
        {
            var values = from element in stDevAggregate
                         select selector(element);
            return values.StandardDeviation();
        }

        // Calculate the stdevp value for a collection of type Double.
        public static double Var(this IEnumerable<double> stDevAggregate)
        {
            return stDevAggregate.Variance();
        }

        // Project the collection of generic items as type Double and calculate the stdevp value.
        public static double Var<T>(this IEnumerable<T> stDevAggregate, Func<T, double> selector)
        {
            var values = from element in stDevAggregate
                         select selector(element);
            return values.Variance();
        }


        // Calculate the stdev value for a collection of type Double.
        public static double StDevP(this IEnumerable<double> stDevAggregate)
        {
            return stDevAggregate.PopulationStandardDeviation();
        }

        // Project the collection of generic items as type Double and calculate the stdev value.
        public static double StDevP<T>(this IEnumerable<T> stDevAggregate, Func<T, double> selector)
        {
            var values = from element in stDevAggregate
                         select selector(element);
            return values.PopulationStandardDeviation();
        }

        // Calculate the stdevp value for a collection of type Double.
        public static double VarP(this IEnumerable<double> stDevAggregate)
        {
            return stDevAggregate.PopulationVariance();
        }

        // Project the collection of generic items as type Double and calculate the stdevp value.
        public static double VarP<T>(this IEnumerable<T> stDevAggregate, Func<T, double> selector)
        {
            var values = from element in stDevAggregate
                         select selector(element);
            return values.PopulationVariance();
        }

        // Calculate the stdevp value for a collection of type Double.
        public static double Median(this IEnumerable<double> stDevAggregate)
        {
            return stDevAggregate.Median();
        }

        // Project the collection of generic items as type Double and calculate the stdevp value.
        public static double Median<T>(this IEnumerable<T> stDevAggregate, Func<T, double> selector)
        {
            var values = from element in stDevAggregate
                         select selector(element);
            return values.Median();
        }

        // Calculate the stdevp value for a collection of type Double.
        public static double Mean(this IEnumerable<double> stDevAggregate)
        {
            return stDevAggregate.Mean();
        }

        // Project the collection of generic items as type Double and calculate the stdevp value.
        public static double Mean<T>(this IEnumerable<T> stDevAggregate, Func<T, double> selector)
        {
            var values = from element in stDevAggregate
                         select selector(element);
            return values.Mean();
        }

        // Calculate the stdevp value for a collection of type Double.
        public static double OrderStatistic(this IEnumerable<double> stDevAggregate, int order)
        {
            return stDevAggregate.OrderStatistic(order);
        }


        // Calculate the Kurtosis value for a collection of type Double.
        public static double Kurtosis(this IEnumerable<double> stDevAggregate)
        {
            DescriptiveStatistics _DescriptiveStatistics = new DescriptiveStatistics(stDevAggregate);
            return _DescriptiveStatistics.Kurtosis;
        }

        // Calculate the Kurtosis value for a collection of type Double.
        public static double Kurtosis<T>(this IEnumerable<T> stDevAggregate, Func<T, double> selector)
        {
            var values = from element in stDevAggregate
                         select selector(element);
            DescriptiveStatistics _DescriptiveStatistics = new DescriptiveStatistics(values);
            return _DescriptiveStatistics.Kurtosis;
        }

        // Calculate the Skewness value for a collection of type Double.
        public static double Skewness(this IEnumerable<double> stDevAggregate)
        {
            DescriptiveStatistics _DescriptiveStatistics = new DescriptiveStatistics(stDevAggregate);
            return _DescriptiveStatistics.Skewness;
        }

        // Calculate the Skewness value for a collection of type Double.
        public static double Skewness<T>(this IEnumerable<T> stDevAggregate, Func<T, double> selector)
        {
            var values = from element in stDevAggregate
                         select selector(element);
            DescriptiveStatistics _DescriptiveStatistics = new DescriptiveStatistics(values);
            return _DescriptiveStatistics.Skewness;
        }
    }
}