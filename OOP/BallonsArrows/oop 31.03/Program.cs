using oop_31._03;

Player blue=new Player();
blue.TeamName = "BlueTeam";
Player red=new Player();
red.TeamName = "RedTeam";
int countblue = 0;
int countred = 0;
for (int i = 0; i < 10; i++) 
{
    if (blue.Arrows[i].Accuracy >= blue.Balloons[i].BalloonSize) 
    {
        countblue++;
    }
    if (red.Arrows[i].Accuracy >= red.Balloons[i].BalloonSize) 
    {
        countred++;
    }
}
if (countblue > countred)
{
    Console.WriteLine($"Blue wins:{countblue}");
}
else if (countred > countblue) 
{
    Console.WriteLine($"Red wins:{countred}");
}
else
{
    Console.WriteLine("Blue=Red");
}