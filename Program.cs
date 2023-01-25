// See https://aka.ms/new-console-template for more information

int[] startPosition = new int[3];
int[] finalPosition = new int[3];
int time = int.Parse(args[6]);
double speed = 0;
double distance = 0;

if (args.Length != 7 || time <= 0)
{
    throw new Exception("invalid input");
}

printPositions(startPosition, finalPosition, time, args);
printDistance(startPosition, finalPosition, time, speed, distance);
printSpeed(startPosition, finalPosition, time, speed, distance);

// Get the distance (difference of start and final) of each axis, and save it to an array
double pointTime = (double)time / 10;
double[] distanceVector = new double[3];
for (int i = 0; i < 3; i++)
{
    int start = startPosition[i];
    int final = finalPosition[i];
    distanceVector[i] = (double)(final - start) / time;
}

// Initialize an array representing the intervene point, which starts at the start point
double[] intervene = new double[3];
for (int i = 0; i < 3; i++)
{
    intervene[i] = startPosition[i];
}

// Calculate the distance of each axis during each point time by total distance/(1/point time)Iteratively print 
// Iteratively print out the distance traveled and current point
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine("iteration: " + i);
    double currentTime = i * pointTime;

    Console.WriteLine("distance traveled : " + currentTime * speed);

    for (int m = 0; m < 3; m++)
    {
        intervene[m] = intervene[m] + distanceVector[m] / (1 / 0.5);
    }
    Console.WriteLine("current: " + String.Join(" ", intervene));

    Console.WriteLine("time: " + currentTime);
}

// Initialize 2 arrays to represent the start point and final point and print out positions and time
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

// Get the distance traveled using the vector calculation
static double getDistance(int[] startPosition, int[] finalPosition, int time, double distance, double speed)
{
    double distanceSqr = 0;

    for (int i = 0; i < 3; i++)
    {
        int start = startPosition[i];
        int final = finalPosition[i];
        distanceSqr += Math.Pow((final - start), 2);
    }

    double distanceTemp = Math.Sqrt(distanceSqr);
    return distanceTemp;
}

// Get the distance and print
static void printDistance(int[] startPosition, int[] finalPosition, int time, double speed, double distance)
{
    distance = getDistance(startPosition, finalPosition, time, distance, speed);

    Console.WriteLine("distance: " + distance);
}

// get the speed and print
static void printSpeed(int[] startPosition, int[] finalPosition, int time, double speed, double distance)
{
    distance = getDistance(startPosition, finalPosition, time, distance, speed);
    speed = distance / time;

    Console.WriteLine("Speed: " + speed);
}



