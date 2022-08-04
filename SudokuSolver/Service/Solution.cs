using SudokuSolver.Models;

namespace SudokuSolver.Service
{
    public static class Solution
    {
        private static int contEmptyValues = 81;
        public static void Resolve(SudokuMap map)
        {
            CleaningLists(map);
            CountValues(map);
            OnlyInTheList(map);

            if(contEmptyValues != map.Fields.Where(x => !x.Value.HasValue).ToList().Count)
            {
                contEmptyValues = map.Fields.Where(x => !x.Value.HasValue).ToList().Count;
                Resolve(map);
            }
        }

        private static void CountValues(SudokuMap map)
        {
            var CountedValues = map.Fields.Where(x => x.Value.HasValue)
                .GroupBy(x => x.Value)
                .Select(n => new { n.Key, Count = n.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            foreach (var item in CountedValues.Where(x => x.Count == 8).ToList())
            {
                if (item.Key.HasValue)
                {
                    var rows = map.Fields.Where(x => x.Value == item.Key).Select(x => x.Row).ToList();
                    var cols = map.Fields.Where(x => x.Value == item.Key).Select(x => x.Column).ToList();
                    map.Fields.Where(x => !rows.Contains(x.Row) && !cols.Contains(x.Column)).FirstOrDefault().Value = item.Key;
                }
            }

            CleaningLists(map);
        }

        private static void OnlyInTheList(SudokuMap map)
        {
            var emptyValues = map.Fields.Where(x => !x.Value.HasValue).ToList();

            foreach (var item in emptyValues)
            {
                foreach (var p in item.Possibilities)
                {
                    if (map.Fields.Where(x => x.Row == item.Row && x != item).Any(x => x.Possibilities.Contains(p)))
                        continue;
                    if (map.Fields.Where(x => x.Column == item.Column && x != item).Any(x => x.Possibilities.Contains(p)))
                        continue;
                    if (map.Fields.Where(x => x.Box == item.Box && x != item).Any(x => x.Possibilities.Contains(p)))
                        continue;

                    item.Value = p;
                    break;
                }
            }
            CleaningLists(map);
            AloneInTheRow(map);
            AloneInTheColumn(map);
            AloneInTheBox(map);
        }

        private static void AloneInTheRow(SudokuMap map)
        {
            var emptyValues = map.Fields.Where(x => !x.Value.HasValue).ToList();

            foreach (var item in emptyValues)
            {
                foreach (var p in item.Possibilities)
                {
                    if (!map.Fields.Where(x => x.Row == item.Row && x != item).Any(x => x.Possibilities.Contains(p)))
                    {
                        item.Value = p;
                        break;
                    }
                }
            }
            CleaningLists(map);
        }

        private static void AloneInTheColumn(SudokuMap map)
        {
            var emptyValues = map.Fields.Where(x => !x.Value.HasValue).ToList();

            foreach (var item in emptyValues)
            {
                foreach (var p in item.Possibilities)
                {
                    if (!map.Fields.Where(x => x.Column == item.Column && x != item).Any(x => x.Possibilities.Contains(p)))
                    {
                        item.Value = p;
                        break;
                    }
                }
            }
            CleaningLists(map);
        }

        private static void AloneInTheBox(SudokuMap map)
        {
            var emptyValues = map.Fields.Where(x => !x.Value.HasValue).ToList();

            foreach (var item in emptyValues)
            {
                foreach (var p in item.Possibilities)
                {
                    if (!map.Fields.Where(x => x.Box == item.Box && x != item).Any(x => x.Possibilities.Contains(p)))
                    {
                        item.Value = p;
                        break;
                    }
                }
            }
            CleaningLists(map);
        }


        private static void CleaningLists(SudokuMap map)
        {
            bool again = false;
            var startValues = map.Fields.Where(f => f.Value.HasValue).ToList();

            foreach (var item in startValues)
            {
                foreach (var r in map.Fields.Where(f => f.Row == item.Row && f != item && f.Possibilities.Contains(item.Value)).ToList())
                {
                    again = RemoveItem(r, item.Value);
                }
                foreach (var r in map.Fields.Where(f => f.Column == item.Column && f != item && f.Possibilities.Contains(item.Value)).ToList())
                {
                    again = RemoveItem(r, item.Value);
                }
                foreach (var r in map.Fields.Where(f => f.Box == item.Box && f != item && f.Possibilities.Contains(item.Value)).ToList())
                {
                    again = RemoveItem(r, item.Value);
                }
            }

            if (again)
            {
                CleaningLists(map);
            }
        }

        public static bool RemoveItem(Field field, int? value)
        {
            field.Possibilities.Remove(value);
            if (field.Possibilities.Count == 1)
                field.Value = field.Possibilities[0];
            return true;
        }
    }
}
