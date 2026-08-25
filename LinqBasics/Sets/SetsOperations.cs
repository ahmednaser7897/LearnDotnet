using System;
using System.Linq;

namespace Linq.Sets
{
    internal class LinqSetsOperations
    {
        public static void Run()
        {
            // DistinctExamples();
            // ExceptExamples();
            // IntersectExamples();
            UnionExamples();
        }

        public static void DistinctExamples()
        {
            Console.WriteLine("===================== Distinct Examples =====================");

            var participantsMeeting1Meeting2 =
                Repository.Meeting1.Participants
                    .Concat(Repository.Meeting2.Participants);

            // Combine participants from Meeting 1 and Meeting 2.
            participantsMeeting1Meeting2.Print(
                "Meeting 1 and Meeting 2 Participants"
            );

            // Remove duplicate participants from the sequence.
            var distinctParticipantsMeeting1Meeting2 =
                participantsMeeting1Meeting2.Distinct();

            distinctParticipantsMeeting1Meeting2.Print(
                "Meeting 1 and Meeting 2 Distinct Participants"
            );

            // Remove duplicates based on EmployeeNo.
            var distinctParticipantsMeeting1Meeting2DistinctBy =
                participantsMeeting1Meeting2.DistinctBy(x => x.EmployeeNo);

            distinctParticipantsMeeting1Meeting2DistinctBy.Print(
                "Meeting 1 and Meeting 2 DistinctBy(x => x.EmployeeNo) Participants"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void ExceptExamples()
        {
            Console.WriteLine("===================== Except Examples =====================");

            var set1 = Repository.Meeting1.Participants;
            var set2 = Repository.Meeting2.Participants;

            set1.Print($"========= Meeting 1 Participants ({set1.Count()})");
            set2.Print($"========= Meeting 2 Participants ({set2.Count()})");

            // Get participants that exist in set1 but not in set2.
            var set3 = set1.Except(set2);

            set3.Print(
                $"========= set1.Except(set2) Participants ({set3.Count()})"
            );

            // Compare the sets using EmployeeNo instead of the whole object.
            var set4 = set1.ExceptBy(
                set2.Select(x => x.EmployeeNo),
                x => x.EmployeeNo
            );

            set4.Print(
                $"========= set1.ExceptBy(set2.Select(x => x.EmployeeNo)) Participants ({set4.Count()})"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void IntersectExamples()
        {
            Console.WriteLine("===================== Intersect Examples =====================");

            var set1 = Repository.Meeting1.Participants;
            var set2 = Repository.Meeting2.Participants;

            set1.Print($"========= Meeting 1 Participants ({set1.Count()})");
            set2.Print($"========= Meeting 2 Participants ({set2.Count()})");

            // Get participants that exist in both set1 and set2.
            var set3 = set1.Intersect(set2);

            set3.Print(
                $"========= set1.Intersect(set2) Participants ({set3.Count()})"
            );

            // Find common participants based on EmployeeNo.
            var set4 = set1.IntersectBy(
                set2.Select(x => x.EmployeeNo),
                x => x.EmployeeNo
            );

            set4.Print(
                $"========= set1.IntersectBy(set2.Select(x => x.EmployeeNo)) Participants ({set4.Count()})"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void UnionExamples()
        {
            Console.WriteLine("===================== Union Examples =====================");

            var set1 = Repository.Meeting1.Participants;
            var set2 = Repository.Meeting2.Participants;

            set1.Print($"========= Meeting 1 Participants ({set1.Count()})");
            set2.Print($"========= Meeting 2 Participants ({set2.Count()})");

            // Combine both sets and remove duplicates.
            var set3 = set1.Union(set2);

            set3.Print(
                $"========= set1.Union(set2) Participants ({set3.Count()})"
            );

            // Combine both sets and remove duplicates based on EmployeeNo.
            var set4 = set1.UnionBy(
                set2,
                x => x.EmployeeNo
            );

            set4.Print(
                $"========= set1.UnionBy(set2, x => x.EmployeeNo) Participants ({set4.Count()})"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}