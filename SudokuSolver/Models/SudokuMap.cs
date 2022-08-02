namespace SudokuSolver.Models
{
    public class SudokuMap
    {
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
            if(i == 1 || i == 2 || i == 3)
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
