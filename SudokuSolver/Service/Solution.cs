using SudokuSolver.Models;

namespace SudokuSolver.Service
{
    public static class Solution
    {
        public static void Calculate(SudokuMap map)
        {
            var startValues = map.Fields.Where(f => f.Value != 0).ToList();

            foreach (var item in startValues)
            {
                foreach (var r in map.Fields.Where(f => f.Row == item.Row && f != item).ToList())
                {
                    RemoveItem(r,item.Value);
                }
                foreach (var r in map.Fields.Where(f => f.Column == item.Column && f != item).ToList())
                {
                    RemoveItem(r, item.Value);
                }
                foreach (var r in map.Fields.Where(f => f.Box == item.Box && f != item).ToList())
                {
                    RemoveItem(r, item.Value);
                }
            }
        }

        public static void RemoveItem(Field field, int value)
        {
            field.Possibilities.Remove(value);
            if (field.Possibilities.Count == 1)
                field.Value = field.Possibilities[0];
        }
    }
}
