using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.ConvertingDataTypes
{
    internal class LinqConvertingDataTypes
    {
        public static void Run()
        {
            // AsEnumerableExamples();
            // AsQueryableExamples();
            // CastExamples();
            // OfTypeExamples();
            // ToArrayExamples();
            // ToListExamples();
            // ToDictionaryExamples();
            ToLookupExamples();
        }

        public static void AsEnumerableExamples()
        {
            Console.WriteLine("===================== AsEnumerable Examples =====================");

            ShippingList<Shipping> shippings =
                ShippingRepository.AllAsShippingList;

            // Where uses the implementation of ShippingList<T>.
            var todayShipping =
                shippings.Where(x => x.ShippingDate == DateTime.Today);

            todayShipping.Process("Today's shipping using ShippingList<T> Where");

            // AsEnumerable converts the sequence to IEnumerable<T>.
            var todayShipping2 =
                shippings.AsEnumerable()
                    .Where(x => x.ShippingDate == DateTime.Today);

            todayShipping2.Process("Today's shipping using IEnumerable<T> Where");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void AsQueryableExamples()
        {
            Console.WriteLine("===================== AsQueryable Examples =====================");

            ShippingList<Shipping> shippings =
                ShippingRepository.AllAsShippingList;

            // Where uses the implementation of ShippingList<T>.
            var todayShipping =
                shippings.Where(x => x.ShippingDate == DateTime.Today);

            // Expression is not available when working with IEnumerable<T>.
            // Console.WriteLine(todayShipping.Expression);

            todayShipping.Process("Today's shipping using ShippingList<T> Where");

            // AsQueryable converts the sequence to IQueryable<T>.
            IQueryable<Shipping> todayShipping2 =
                shippings.AsQueryable()
                    .Where(x => x.ShippingDate == DateTime.Today);

            todayShipping2.Process("Today's shipping using IQueryable<T> Where");

            // IQueryable<T> allows us to inspect the Expression Tree.
            Console.WriteLine(todayShipping2.Expression);

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void CastExamples()
        {
            Console.WriteLine("===================== Cast Examples =====================");

            IEnumerable<Shipping> shippings =
                ShippingRepository.AllAsList;

            // Filter GroundShipping objects, then cast them to GroundShipping.
            var groundShippings =
                shippings
                    .Where(x => x.GetType() == typeof(GroundShipping))
                    .Cast<GroundShipping>();

            groundShippings.Process("Ground shippings");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void OfTypeExamples()
        {
            Console.WriteLine("===================== OfType Examples =====================");

            IEnumerable<Shipping> shippings =
                ShippingRepository.AllAsList;

            // OfType filters and casts objects of the specified type.
            var groundShippings =
                shippings.OfType<GroundShipping>();

            groundShippings.Process("Ground shippings");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void ToArrayExamples()
        {
            Console.WriteLine("===================== ToArray Examples =====================");

            IEnumerable<Shipping> shippings =
                ShippingRepository.AllAsList;

            // ToArray converts the sequence into an array.
            var shippingArray = shippings.ToArray();

            Console.WriteLine($"Total shippings: {shippingArray.Length}");
            Console.WriteLine("First shipping:");

            shippingArray[0].Start();

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void ToListExamples()
        {
            Console.WriteLine("===================== ToList Examples =====================");

            IEnumerable<Shipping> shippings =
                ShippingRepository.AllAsList;

            // ToList converts the sequence into a List<T>.
            List<Shipping> shippingList =
                shippings.ToList();

            Console.WriteLine($"Total shippings: {shippingList.Count}");
            Console.WriteLine("First shipping:");

            shippingList[0].Start();
            shippingList.First().Start();

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void ToDictionaryExamples()
        {
            Console.WriteLine("===================== ToDictionary Examples =====================");

            IEnumerable<Shipping> shippings =
                ShippingRepository.AllAsList;

            // Create a dictionary using UniqueId as the key.
            Dictionary<string, Shipping> dictionary1 =
                shippings.ToDictionary(x => x.UniqueId);

            dictionary1["ABC005"].Start();

            // Group shippings by date, then convert each group into a List.
            Dictionary<DateTime, List<Shipping>> dictionary2 =
                shippings
                    .GroupBy(x => x.ShippingDate)
                    .ToDictionary(s => s.Key, s => s.ToList());

            var date = new DateTime(2022, 3, 9, 0, 0, 0);

            dictionary2[date].Process(
                $"Shippings on {date.ToString("dddd, MMMM dd yyyy")}"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void ToLookupExamples()
        {
            Console.WriteLine("===================== ToLookup Examples =====================");

            IEnumerable<Shipping> shippings =
                ShippingRepository.AllAsList;

            // ToLookup creates a lookup that can contain multiple values for the same key.
            ILookup<string, Shipping> lookup1 =
                shippings.ToLookup(x => x.UniqueId);

            lookup1["ABC005"].First().Start();

            // Create a lookup where the shipping date is the key.
            ILookup<DateTime, Shipping> lookup2 =
                shippings.ToLookup(x => x.ShippingDate);

            var date = new DateTime(2022, 3, 9, 0, 0, 0);

            lookup2[date].Process(
                $"Shippings on {date.ToString("dddd, MMMM dd yyyy")}"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}