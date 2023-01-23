// See https://aka.ms/new-console-template for more information

int[] startPosition = new int[3];
int[] finalPosition = new int[3];
int time = int.Parse(args[6]);
double speed;
double distance;

if (args.Length != 7 || time <= 0)
{
    throw new Exception("invalid input");
}

printPositions(startPosition, finalPosition, time, args);

static void printPositions(int[] startPosition, int[] finalPosition, int time, string[] args)
{
    for (int i = 0; i < 6; i++)
    {
        int temp = int.Parse(args[i]);
        if (i < 3)
        {
            startPosition[i] = temp;
        }
        else if (i < 6)
        {
            finalPosition[i - 3] = temp;
        }
    }

    Console.WriteLine("start position: " + String.Join(" ", startPosition));
    Console.WriteLine("final position: " + String.Join(" ", finalPosition));
    Console.WriteLine("time: " + time);
}


double distanceSqr = 0;
for (int i = 0; i < 3; i++)
{
    int start = startPosition[i];
    int final = finalPosition[i];
    distanceSqr += Math.Pow((final - start), 2);
}
distance = Math.Sqrt(distanceSqr);
speed = distance / time;

Console.WriteLine("distance: " + distance);
Console.WriteLine("speed: " + speed);



double pointTime = (double)time / 10;
double[] unitVector = new double[3];
for (int i = 0; i < 3; i++)
{
    int start = startPosition[i];
    int final = finalPosition[i];
    unitVector[i] = (double)(final - start) / time;
}


double[] intervene = new double[3];
for (int i = 0; i < 3; i++)
{
    intervene[i] = startPosition[i];
}

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine("iteration: " + i);
    double currentTime = i * pointTime;

    Console.WriteLine("distance traveled : " + currentTime * speed);

    for (int m = 0; m < 3; m++)
    {
        intervene[m] = intervene[m] + unitVector[m] / 2;
    }
    Console.WriteLine("current: " + String.Join(" ", intervene));

    Console.WriteLine("time: " + currentTime);
}
