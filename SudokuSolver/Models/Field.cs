namespace SudokuSolver.Models
{
    public class Field
    {
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                Possibilities.Clear();
                Possibilities.Add(_value);
            }
        }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Box { get; set; }
        public List<int> Possibilities { get; set; } = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    }
}
