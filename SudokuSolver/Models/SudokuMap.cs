namespace SudokuSolver.Models
{
    public class SudokuMap
    {
        public SudokuMap(bool started) : this()
        {
            Fields.Where(p => p.Row == 1 && p.Column == 1).FirstOrDefault().Value = 1;
            Fields.Where(p => p.Row == 1 && p.Column == 4).FirstOrDefault().Value = 6;
            Fields.Where(p => p.Row == 1 && p.Column == 8).FirstOrDefault().Value = 2;
            Fields.Where(p => p.Row == 2 && p.Column == 5).FirstOrDefault().Value = 2;
            Fields.Where(p => p.Row == 2 && p.Column == 9).FirstOrDefault().Value = 1;
            Fields.Where(p => p.Row == 3 && p.Column == 2).FirstOrDefault().Value = 4;
            Fields.Where(p => p.Row == 3 && p.Column == 4).FirstOrDefault().Value = 1;
            Fields.Where(p => p.Row == 3 && p.Column == 9).FirstOrDefault().Value = 5;
            Fields.Where(p => p.Row == 4 && p.Column == 1).FirstOrDefault().Value = 9;
            Fields.Where(p => p.Row == 4 && p.Column == 3).FirstOrDefault().Value = 3;
            Fields.Where(p => p.Row == 4 && p.Column == 6).FirstOrDefault().Value = 8;
            Fields.Where(p => p.Row == 4 && p.Column == 8).FirstOrDefault().Value = 6;
            Fields.Where(p => p.Row == 5 && p.Column == 3).FirstOrDefault().Value = 7;
            Fields.Where(p => p.Row == 5 && p.Column == 4).FirstOrDefault().Value = 4;
            Fields.Where(p => p.Row == 5 && p.Column == 6).FirstOrDefault().Value = 1;
            Fields.Where(p => p.Row == 5 && p.Column == 7).FirstOrDefault().Value = 3;
            Fields.Where(p => p.Row == 6 && p.Column == 2).FirstOrDefault().Value = 1;
            Fields.Where(p => p.Row == 6 && p.Column == 4).FirstOrDefault().Value = 5;
            Fields.Where(p => p.Row == 6 && p.Column == 7).FirstOrDefault().Value = 7;
            Fields.Where(p => p.Row == 6 && p.Column == 9).FirstOrDefault().Value = 9;
            Fields.Where(p => p.Row == 7 && p.Column == 1).FirstOrDefault().Value = 7;
            Fields.Where(p => p.Row == 7 && p.Column == 6).FirstOrDefault().Value = 9;
            Fields.Where(p => p.Row == 7 && p.Column == 8).FirstOrDefault().Value = 1;
            Fields.Where(p => p.Row == 8 && p.Column == 1).FirstOrDefault().Value = 5;
            Fields.Where(p => p.Row == 8 && p.Column == 5).FirstOrDefault().Value = 1;
            Fields.Where(p => p.Row == 9 && p.Column == 2).FirstOrDefault().Value = 3;
            Fields.Where(p => p.Row == 9 && p.Column == 6).FirstOrDefault().Value = 5;
            Fields.Where(p => p.Row == 9 && p.Column == 9).FirstOrDefault().Value = 8;
        }

        public SudokuMap()
        {
            Fields = new List<Field>();
            for (int i = 1; i <= 9; i++)
            {
                int rowStart = 0, rowEnd = 0, columnStart = 0, columnEnd = 0;

                CalculateRowPosition(i, out rowStart, out rowEnd);
                CalculateColumnPosition(i, out columnStart, out columnEnd);

                for (int j = rowStart; j <= rowEnd; j++)
                {
                    for (int k = columnStart; k <= columnEnd; k++)
                    {
                        Fields.Add(new Field()
                        {
                            Box = i,
                            Row = j,
                            Column = k
                        });
                    }
                }
            }

        }

        private void CalculateRowPosition(int i, out int rowStart, out int rowEnd)
        {
            if (i == 1 || i == 2 || i == 3)
            {
                rowStart = 1;
                rowEnd = 3;
            }
            else if (i == 4 || i == 5 || i == 6)
            {
                rowStart = 4;
                rowEnd = 6;
            }
            else
            {
                rowStart = 7;
                rowEnd = 9;
            }
        }

        private void CalculateColumnPosition(int i, out int columnStart, out int columnEnd)
        {
            if (i == 1 || i == 4 || i == 7)
            {
                columnStart = 1;
                columnEnd = 3;
            }
            else if (i == 2 || i == 5 || i == 8)
            {
                columnStart = 4;
                columnEnd = 6;
            }
            else
            {
                columnStart = 7;
                columnEnd = 9;
            }
        }


        public List<Field> Fields { get; set; }


    }
}
