﻿public static GameResult GetGameResult(Mark[,] field)


{
            bool circleWin = testWin(field, Mark.Circle);
    bool crossWin = testWin(field, Mark.Cross);

    if (circleWin == crossWin) return GameResult.Draw;

    return if (circleWin) GameResult.CircleWin else GameResult.CrossWin;
}

private static void Run(string description)
@@ -49,5 + 54,61 @@ private static void Run(string description)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
return ans;
        }


        public static bool testLines(Mark[,] field, Mark mark)
{
    bool winner = false;
    for (int i = 0; i < field.GetLength(0); i++)
    {
        var a = 0;
        for (int j = 0; j < field.GetLength(1); j++)
            if (mark == field[i, j])
            {
                a = a + 1;
                if (a == 3)
                {
                    winner = true;
                    break;
                }
            }
    }
    return winner;
}

public static bool testColumn(Mark[,] field, Mark mark)
{
    bool winner = false;
    for (int nomerStroki = 0; nomerStroki < field.GetLength(0); nomerStroki++)
    {
        var a = 0;
        for (int nomerKolonki = 0; nomerKolonki < field.GetLength(1); nomerKolonki++)
            if (mark == field[nomerKolonki, nomerStroki])
            {
                a = a + 1;
                if (a == 3)
                {
                    winner = true;
                    break;
                }
            }
    }
    return winner;
}

public static bool testDiagonal(Mark[,] field, Mark mark)
{
    if ((mark == field[0, 0] && mark == field[1, 1] && mark == field[2, 2]) || (mark == field[2, 0] && mark == field[1, 1] && mark == field[0, 2]))
        return true;
    else return false;
}

public static bool testWin(Mark[,] field, Mark mark)
{
    bool diagonal = testDiagonal(field, mark);
    bool stroka = testLines(field, mark);
    bool kolonka = testColon(field, mark);
    return (diagonal || stroka || kolonka);
}
    }
}