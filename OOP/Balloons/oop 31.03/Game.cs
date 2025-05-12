using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons
{
    public class Game
    {
        Player red = new Player();
        Player blue = new Player(); 
        Random random = new Random();
        public int probability { get; set; }
        public Game()
        {
            probability = random.Next(1, 11);
            GreateGame();
        }

        public void GreateGame() 

        {
            red.TeamName = "RedTeam";
            blue.TeamName = "BlueTeam";
            if (probability % 2 == 0)
            {
                blue.Arrows = new List<Arrow>() {
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow()
                    };

                blue.Balloons = new List<Balloon>()
                {
                    new Balloon(),
                    new Balloon(),
                    new Balloon("BlackBalloon"),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon()
                };
                red.Arrows = new List<Arrow>() {
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow()
                    };

                red.Balloons = new List<Balloon>()
                {
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon()


                };
            }
            else 
            {
                blue.Arrows = new List<Arrow>() {
                    new Arrow(),
                    new Arrow(),
                    new Arrow(10),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow()
                    };

                blue.Balloons = new List<Balloon>()
                {
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon()
                };
                red.Arrows = new List<Arrow>() {
                    new Arrow(10),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow(),
                    new Arrow()
                    };

                red.Balloons = new List<Balloon>()
                {
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon("BlackBalloon"),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon(),
                    new Balloon()
                };
            }
        }
        int countblue = 0;
        int countred = 0;
        public void StartGame()
        {
            
            int indexblue = 9;
            int indexred = 9;
            while(indexblue!=0 && indexred!=0)
            {
                if (blue.Balloons[indexblue].BalloonType == "BlackBallon")
                {
                    blue.Arrows.RemoveAt(indexblue);
                    blue.Balloons.RemoveAt(indexblue);
                    indexblue--;
                
                    if ( red.Arrows[indexred].Accuracy >= red.Balloons[indexred].BalloonSize)
                    {
                        countred++;
                        red.Score += red.Balloons[indexred].BallonPoints;
                        

                    }
                    indexred--;
                    red.Arrows.RemoveAt(indexred);
                    red.Balloons.RemoveAt(indexred);

                    if ( red.Arrows[indexred].Accuracy >= red.Balloons[indexred].BalloonSize)
                    {
                        countred++;
                        red.Score += red.Balloons[indexred].BallonPoints;
                        

                    }
                    indexred--;
                    red.Arrows.RemoveAt(indexred);
                    red.Balloons.RemoveAt(indexred);

                    blue.Arrows.RemoveAt(indexblue);
                    blue.Balloons.RemoveAt(indexblue);
                    indexblue--;
                }
               else if (red.Balloons[indexred].BalloonType == "BlackBallon")
                {
                    red.Arrows.RemoveAt(indexred);
                    red.Balloons.RemoveAt(indexred);
                    indexred--;

                    if (blue.Arrows[indexblue].Accuracy >= blue.Balloons[indexblue].BalloonSize)
                    {
                        countblue++;
                        blue.Score += blue.Balloons[indexblue].BallonPoints;
                        

                    }
                    blue.Arrows.RemoveAt(indexblue);
                    blue.Balloons.RemoveAt(indexblue);
                    indexblue--;

                    if (blue.Arrows[indexblue].Accuracy >= blue.Balloons[indexblue].BalloonSize)
                    {
                        countblue++;
                        blue.Score += blue.Balloons[indexblue].BallonPoints;


                    }
                    
                    red.Arrows.RemoveAt(indexred);
                    red.Balloons.RemoveAt(indexred);
                    indexred--;

                    blue.Arrows.RemoveAt(indexblue);
                    blue.Balloons.RemoveAt(indexblue);
                    indexblue--;
                }
                else 
                {
                    if (blue.Arrows[indexblue].Accuracy >= blue.Balloons[indexblue].BalloonSize)
                    {

                        countblue++;
                        blue.Score += blue.Balloons[indexblue].BallonPoints;
                        
  
                    }
                    indexblue--;
                    blue.Arrows.RemoveAt(indexblue);
                    blue.Balloons.RemoveAt(indexblue);

                    if ( red.Arrows[indexred].Accuracy >= red.Balloons[indexred].BalloonSize)
                    {
                        countred++;
                        red.Score += red.Balloons[indexred].BallonPoints;
                        
                        
                    }
                    indexred--;
                    red.Arrows.RemoveAt(indexred);
                    red.Balloons.RemoveAt(indexred);
                }
                
               
            }
            if (blue.Score > red.Score)
            {
                Console.WriteLine($"Blue wins:{blue.Score}");
            }
            else if (red.Score > blue.Score)
            {
                Console.WriteLine($"Red wins:{red.Score}");
            }
            else
            {
                Console.WriteLine("Blue=Red");
            }
        }
        public void Score() 
        {

            Console.WriteLine($"Red Team Pop Balloons : {countred}");
            Console.WriteLine($"Red Team Score : {red.Score}");
            Console.WriteLine($"Blue Team Pop Balloons : {countblue}");
            Console.WriteLine($"Blue Team Score : {blue.Score}");
        }
    }
    
}
