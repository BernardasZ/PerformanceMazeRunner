namespace GameRunner;

public class Game : IGame
{
    private byte _byte10 = 10;
    private byte _byte13 = 13;
    private byte _space = 32;
    private byte _wall = 49;
    private byte _start = 88;

    public int Run(string filePath)
    {
        try
        {
            int? startPoint = null;

            var byteArray = File.ReadAllBytes(filePath);

            if (byteArray.Length == 0)
                throw new Exception("No data.");

            if (byteArray.Length == 1 && byteArray[0] == _start)
                throw new Exception("Data range does not meet the default constrains.");

            int x = 0;

            while (true)
            {
                if (byteArray[x] == _byte13 || byteArray[x] == _byte10)
                    break;
                x++;
            }

            int y = (int)Math.Round((decimal)byteArray.Length / (x + 2));

            for (int i = 0; i < byteArray.Length; i++)
            {
                if (byteArray[i] == _start)
                {
                    startPoint = i;
                    break;
                }
            }

            if (!startPoint.HasValue)
                throw new Exception("No start position was found.");

            if (x < 5 || y < 5)
                throw new Exception("Data range does not meet the default constrains.");

            int counter = 0;
            int length = 0;

            if (byteArray.Length % x == 0)
                length = byteArray.Length;
            else
                length = byteArray.Length + 2;

            int yCheck = 0;
            int start = startPoint.Value;

            yCheck = start / (x + 2) * (x + 2);

            if (
                   start < x
                || length - (x + 2) < start
                || yCheck == start
                || yCheck + x - 1 == start)
            {
                return 0;
            }

            var allMoves = new int[length];

            int p = start - (x + 2);

            if (byteArray[p] == _space)
            {
                byteArray[p] = 0;
                allMoves[counter] = p;
                counter++;
            }

            p = start + (x + 2);

            if (byteArray[p] == _space)
            {
                byteArray[p] = 0;
                allMoves[counter] = p;
                counter++;
            }

            p = start - 1;

            if (byteArray[p] == _space)
            {
                byteArray[p] = 0;
                allMoves[counter] = p;
                counter++;
            }

            p = start + 1;

            if (byteArray[p] == _space)
            {
                byteArray[p] = 0;
                allMoves[counter] = p;
                counter++;
            }

            var movesCounter = counter;
            var previousMovesCounter = movesCounter;
            var isFinish = false;
            yCheck = 0;

            counter = 0;

            while (true)
            {
                if (previousMovesCounter == 0)
                {
                    counter = 0;
                    break;
                }

                var nextMovesCounter = 0;

                for (int i = movesCounter - previousMovesCounter; i < movesCounter; i++)
                {
                    start = allMoves[i];
                    yCheck = start / (x + 2) * (x + 2);

                    if (
                           start < x
                        || length - (x + 2) < start
                        || yCheck == start
                        || yCheck + x - 1 == start)
                    {
                        isFinish = true;
                        break;
                    }

                    p = start - (x + 2);

                    if (byteArray[p] == _space)
                    {
                        byteArray[p] = 0;
                        allMoves[movesCounter + nextMovesCounter] = p;
                        nextMovesCounter++;
                    }

                    p = start + x + 2;

                    if (byteArray[p] == _space)
                    {
                        byteArray[p] = 0;
                        allMoves[movesCounter + nextMovesCounter] = p;
                        nextMovesCounter++;
                    }

                    p = start - 1;

                    if (byteArray[p] == _space)
                    {
                        byteArray[p] = 0;
                        allMoves[movesCounter + nextMovesCounter] = p;
                        nextMovesCounter++;
                    }

                    p = start + 1;

                    if (byteArray[p] == _space)
                    {
                        byteArray[p] = 0;
                        allMoves[movesCounter + nextMovesCounter] = p;
                        nextMovesCounter++;
                    }
                }

                movesCounter += nextMovesCounter;
                previousMovesCounter = nextMovesCounter;

                counter++;

                if (isFinish)
                    break;
            }

            return counter;
        }
        catch
        {
            return 0;
        }
    }
}
