using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace BomberMan
{
    public partial class Form1 : Form
    {
        List<Rectangle> walls = new List<Rectangle>();
        List<Rectangle> breakWalls = new List<Rectangle>();
        List<Rectangle> bombs = new List<Rectangle>();
        List<Rectangle> explosion = new List<Rectangle>();
        List<int> bombtime = new List<int>();
        List<string> bombplayer = new List<string>();
        List<string> explosionplayer = new List<string>();

        Rectangle player1 = new Rectangle(0, 0, 0, 0);
        Rectangle player2 = new Rectangle(0, 0, 0, 0);
        Rectangle sightHort = new Rectangle(0, 50, 150, 50);
        Rectangle sightVert = new Rectangle(50, 0, 50, 150);
        Rectangle sightHort2 = new Rectangle(400, 450, 150, 50);
        Rectangle sightVert2 = new Rectangle(450, 400, 50, 150);
        int playerspeed = 2;

        bool wPressed = false;
        bool sPressed = false;
        bool dPressed = false;
        bool aPressed = false;
        bool qPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool rightPressed = false;
        bool leftPressed = false;
        bool spacePressed = false;
        bool escPressed = false;
        bool pPressed = false;

        int x1;
        int y1;
        int x2;
        int y2;
        int sightx;
        int sighty;
        int sightx2;
        int sighty2;
        int breakwallsX;
        int breakwallsY;
        int check;
        int check2;
        int bombcheck;
        int bombcheck2;
        int timer;
        int endtimer;
        int deathtimer1;
        int deathtimer2;
        int player1points;
        int player2points;
        int a;

        bool arcade;
        bool playerdead1 = false;
        bool playerdead2 = false;

        Random randGen = new Random();

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush purpBrush = new SolidBrush(Color.Purple);

        SoundPlayer victory = new SoundPlayer(Properties.Resources.Victory);
        public Form1()
        {
            InitializeComponent();
            player1pointLabel.Text = "";
            player2pointLabel.Text = "";
            /*startButton.Enabled = false;
            startButton.Visible = false;
            exitButton.Enabled = false;
            exitButton.Visible = false;       
            initializeGame(); */
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            x1 = player1.X;
            y1 = player1.Y;
            x2 = player2.X;
            y2 = player2.Y;
            sightx = sightHort.X;
            sighty = sightHort.Y;
            sightx2 = sightHort2.X;
            sighty2 = sightHort2.Y;

            // breakwalls 
            if (breakWalls.Count == 0)
            {
                check = 0;
                check2 = 0;
                bombcheck = 0;
                bombcheck2 = 0;
                bombs.Clear();
                bombtime.Clear();
                bombplayer.Clear();
                explosion.Clear();
                for (int i = 0; i < 22; i++)
                {
                    breakwallsX = randGen.Next(1, 10);
                    breakwallsY = randGen.Next(1, 10);

                    Rectangle breakwalls = new Rectangle(breakwallsX * 50 + 5, breakwallsY * 50 + 5, 40, 40);
                    for (int


                        j = 0; j < breakWalls.Count; j++)
                    {
                        while (breakwalls.IntersectsWith(breakWalls[j]))
                        {
                            breakwallsX = randGen.Next(1, 10);
                            breakwallsY = randGen.Next(1, 10);

                            breakwalls = new Rectangle(breakwallsX * 50 + 5, breakwallsY * 50 + 5, 40, 40);
                            j = 0;
                        }
                    }
                    for (int j = 0; j < walls.Count; j++)
                    {
                        while (breakwalls.IntersectsWith(walls[j]) || breakwalls.IntersectsWith(player1) || breakWalls[j].IntersectsWith(sightHort) || breakWalls[j].IntersectsWith(sightVert))
                        {
                            breakwallsX = randGen.Next(1, 10);
                            breakwallsY = randGen.Next(1, 10);

                            breakwalls = new Rectangle(breakwallsX * 50 + 5, breakwallsY * 50 + 5, 40, 40);
                            j = 0;
                        }
                    }
                    breakWalls.Add(breakwalls);
                }
            }



            // controls        
            if (playerdead1 == false)
            {
                if (wPressed == true && player1.Y > 0)
            {
                player1.Y = player1.Y - playerspeed;
                sightHort.Y = sightHort.Y - playerspeed;
                sightVert.Y = sightVert.Y - playerspeed;

            }
            if (sPressed == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y = player1.Y + playerspeed;
                sightHort.Y = sightHort.Y + playerspeed;
                sightVert.Y = sightVert.Y + playerspeed;
            }
            if (aPressed == true && player1.X > 0)
            {
                player1.X = player1.X - playerspeed;
                sightHort.X = sightHort.X - playerspeed;
                sightVert.X = sightVert.X - playerspeed;

            }
            if (dPressed == true && player1.X < this.Width - player1.Width)
            {
                player1.X = player1.X + playerspeed;
                sightHort.X = sightHort.X + playerspeed;
                sightVert.X = sightVert.X + playerspeed;

            }
            if (qPressed == true && bombcheck == 0)
            {
                Rectangle bomb = new Rectangle(player1.X, player1.Y, 40, 40);
                bombs.Add(bomb);
                bombplayer.Add("p1");
                int bombtick = timer;
                bombtime.Add(bombtick);
                bombcheck++;

            }
        }
            for (int i = 0; i < walls.Count; i++)
            {
                if (player1.IntersectsWith(walls[i]))
                {
                    player1.Y = y1;
                    player1.X = x1;
                    sightHort.Y = sighty;
                    sightVert.Y = sighty - 50;
                    sightHort.X = sightx;
                    sightVert.X = sightx + 50;
                }
            }
            for (int i = 0; i < breakWalls.Count; i++)
            {
                if (player1.IntersectsWith(breakWalls[i]))
                {
                    player1.Y = y1;
                    player1.X = x1;
                    sightHort.Y = sighty;
                    sightVert.Y = sighty - 50;
                    sightHort.X = sightx;
                    sightVert.X = sightx + 50;
                }
            }
            for (int i = 0; i < bombs.Count; i++)
            {
                if (!player1.IntersectsWith(bombs[i]) && check == 0)
                {
                    if (bombplayer.Count > 0)
                    {
                        if (bombplayer[i] == "p1")
                        {
                            check++;
                        }
                    }
                }
                if (player1.IntersectsWith(bombs[i]) && check == 1)
                {
                    player1.Y = y1;
                    player1.X = x1;
                    sightHort.Y = sighty;
                    sightVert.Y = sighty - 50;
                    sightHort.X = sightx;
                    sightVert.X = sightx + 50;
                }
            }

            //player 2 controls
            if (playerdead2 == false)
            {
                if (upPressed == true && player2.Y > 0)
                {
                    player2.Y = player2.Y - playerspeed;
                    sightHort2.Y = sightHort2.Y - playerspeed;
                    sightVert2.Y = sightVert2.Y - playerspeed;

                }
                if (downPressed == true && player2.Y < this.Height - player2.Height)
                {
                    player2.Y = player2.Y + playerspeed;
                    sightHort2.Y = sightHort2.Y + playerspeed;
                    sightVert2.Y = sightVert2.Y + playerspeed;
                }
                if (leftPressed == true && player2.X > 0)
                {
                    player2.X = player2.X - playerspeed;
                    sightHort2.X = sightHort2.X - playerspeed;
                    sightVert2.X = sightVert2.X - playerspeed;

                }
                if (rightPressed == true && player2.X < this.Width - player1.Width)
                {
                    player2.X = player2.X + playerspeed;
                    sightHort2.X = sightHort2.X + playerspeed;
                    sightVert2.X = sightVert2.X + playerspeed;

                }
                if (spacePressed == true && bombcheck2 == 0)
                {
                    Rectangle bomb2 = new Rectangle(player2.X, player2.Y, 40, 40);
                    bombs.Add(bomb2);
                    bombplayer.Add("p2");
                    int bombtick = timer;
                    bombtime.Add(bombtick);
                    bombcheck2++;
                }
            }
            if (escPressed == true)
            {
                Application.Exit();
            }

            for (int i = 0; i < walls.Count; i++)
            {
                if (player2.IntersectsWith(walls[i]))
                {
                    player2.Y = y2;
                    player2.X = x2;
                    sightHort2.Y = sighty2;
                    sightVert2.Y = sighty2 - 50;
                    sightHort2.X = sightx2;
                    sightVert2.X = sightx2 + 50;
                }
            }
            for (int i = 0; i < breakWalls.Count; i++)
            {
                if (player2.IntersectsWith(breakWalls[i]))
                {
                    player2.Y = y2;
                    player2.X = x2;
                    sightHort2.Y = sighty2;
                    sightVert2.Y = sighty2 - 50;
                    sightHort2.X = sightx2;
                    sightVert2.X = sightx2 + 50;
                }
            }
            for (int i = 0; i < bombs.Count; i++)
            {
                if (!player2.IntersectsWith(bombs[i]) && check2 == 0)
                {
                    if (bombplayer.Count > 0)
                    {
                        if (bombplayer[i] == "p2")
                        {
                            check2++;
                        }
                    }
                }
                if (player2.IntersectsWith(bombs[i]) && check2 == 1)
                {
                    player2.Y = y2;
                    player2.X = x2;
                    sightHort2.Y = sighty2;
                    sightVert2.Y = sighty2 - 50;
                    sightHort2.X = sightx2;
                    sightVert2.X = sightx2 + 50;
                }
            }

            // bombs
            for (int i = 0; i < bombs.Count; i++)
            {
                if (timer - bombtime[i] == 100)
                {
                    for (int j = 0; j <= 9; j++)
                    {
                        explosionplayer.Add(bombplayer[i]);
                    }
                    Rectangle explosion1 = new Rectangle(bombs[i].X, bombs[i].Y, 40, 40);
                    explosion.Add(explosion1);
                    Rectangle explosion2 = new Rectangle(bombs[i].X, bombs[i].Y - 50, 40, 40);
                    Rectangle explosion3 = new Rectangle(bombs[i].X, bombs[i].Y - 100, 40, 40);
                    for (int j = 0; j < breakWalls.Count; j++)
                    {
                        if (explosion2.IntersectsWith(breakWalls[j]))
                        {
                            explosion3 = new Rectangle(bombs[i].X, bombs[i].Y, 0, 0);
                        }
                    }
                    for (int j = 0; j < walls.Count; j++)
                    {
                        if (explosion2.IntersectsWith(walls[j]))
                        {
                            explosion2 = new Rectangle(bombs[i].X, bombs[i].Y - 50, 0, 0);
                            explosion3 = new Rectangle(bombs[i].X, bombs[i].Y, 0, 0);
                        }
                    }
                    explosion.Add(explosion2);
                    explosion.Add(explosion3);

                    Rectangle explosion4 = new Rectangle(bombs[i].X, bombs[i].Y + 50, 40, 40);
                    Rectangle explosion5 = new Rectangle(bombs[i].X, bombs[i].Y + 100, 40, 40);
                    for (int j = 0; j < breakWalls.Count; j++)
                    {
                        if (explosion4.IntersectsWith(breakWalls[j]))
                        {
                            explosion5 = new Rectangle(bombs[i].X, bombs[i].Y, 0, 0);
                        }
                    }
                    for (int j = 0; j < walls.Count; j++)
                    {
                        if (explosion4.IntersectsWith(walls[j]))
                        {
                            explosion4 = new Rectangle(bombs[i].X, bombs[i].Y + 50, 0, 0);
                            explosion5 = new Rectangle(bombs[i].X, bombs[i].Y + 50, 0, 0);
                        }
                    }
                    explosion.Add(explosion4);
                    explosion.Add(explosion5);



                    Rectangle explosion6 = new Rectangle(bombs[i].X - 100, bombs[i].Y, 40, 40);
                    Rectangle explosion7 = new Rectangle(bombs[i].X - 50, bombs[i].Y, 40, 40);
                    for (int j = 0; j < breakWalls.Count; j++)
                    {
                        if (explosion7.IntersectsWith(breakWalls[j]))
                        {
                            explosion6 = new Rectangle(bombs[i].X, bombs[i].Y, 0, 0);
                        }
                    }
                    for (int j = 0; j < walls.Count; j++)
                    {
                        if (explosion7.IntersectsWith(walls[j]))
                        {
                            explosion7 = new Rectangle(bombs[i].X, bombs[i].Y + 50, 0, 0);
                            explosion6 = new Rectangle(bombs[i].X, bombs[i].Y + 50, 0, 0);
                        }
                    }
                    explosion.Add(explosion6);
                    explosion.Add(explosion7);
                    Rectangle explosion8 = new Rectangle(bombs[i].X + 50, bombs[i].Y, 40, 40);
                    Rectangle explosion9 = new Rectangle(bombs[i].X + 100, bombs[i].Y, 40, 40);
                    for (int j = 0; j < breakWalls.Count; j++)
                    {
                        if (explosion8.IntersectsWith(breakWalls[j]))
                        {
                            explosion9 = new Rectangle(bombs[i].X, bombs[i].Y, 0, 0);
                        }
                    }
                    for (int j = 0; j < walls.Count; j++)
                    {

                        if (explosion8.IntersectsWith(walls[j]))
                        {
                            explosion8 = new Rectangle(bombs[i].X, bombs[i].Y + 50, 0, 0);
                            explosion9 = new Rectangle(bombs[i].X, bombs[i].Y + 50, 0, 0);
                        }
                    }
                    explosion.Add(explosion9);
                    explosion.Add(explosion8);
                }


                if (timer - bombtime[i] == 150)
                {

                    explosion.RemoveRange(i, i + 9);
                    explosionplayer.RemoveRange(i, i + 9);
                    check = 0;
                    check2 = 0;
                    bombcheck = 0;
                    bombcheck2 = 0;
                    bombs.RemoveAt(i);
                    bombtime.RemoveAt(i);
                    bombplayer.RemoveAt(i);
                }
            }

                for (int i = 0; i < explosion.Count; i++)
                {
                for (int j = 0; j < walls.Count; j++)
                {
                    if (explosion[i].IntersectsWith(walls[j]))
                    {
                        explosion[i] = new Rectangle(0, 0, 0, 0);
                    }
                }
                if (arcade == false)
                {
                    for (int j = 0; j < breakWalls.Count; j++)
                    {

                        if (explosion[i].IntersectsWith(breakWalls[j]) && explosionplayer[i] == "p1")
                        {


                            player1points = player1points + 300;
                            breakWalls.RemoveAt(j);
                            explosionplayer[i] = "p3";

                        }
                        if (explosion[i].IntersectsWith(breakWalls[j]) && explosionplayer[i] == "p2")
                        {

                            player2points = player2points + 300;
                            breakWalls.RemoveAt(j);
                            explosionplayer[i] = "p3";
                        }
                        if (player1.IntersectsWith(explosion[i]))
                        {
                            i = 0;
                            while (i < 40)
                            {
                                player1 = new Rectangle(player1.X, player1.Y + 1, 40, 40 - i);
                                Refresh();
                                Thread.Sleep(10);
                                i++;
                            }
                            player2points = player2points + 1000;
                            EndGame(player1points, player2points);
                            player1points = 0;
                            player2points = 0;
                            break;                           
                         }
                        if (player2.IntersectsWith(explosion[i]))
                        {
                            i = 0;
                            while (i < 40)
                            {
                                player2 = new Rectangle(player2.X, player2.Y + 1, 40, 40 - i);
                                Refresh();
                                Thread.Sleep(10);
                                i++;
                            }
                            player1points = player1points + 1000;
                            EndGame(player1points, player2points);
                            player1points = 0;
                            player2points = 0;
                        }

                    }
                }
                else
                {
                    if (player1.IntersectsWith(explosion[i]) && playerdead1 == false)
                    {
                        a = i;
                        i = 0;
                        while (i < 40)
                        {
                            player1 = new Rectangle(player1.X, player1.Y + 1, 40, 40 - i);
                            Refresh();
                            Thread.Sleep(10);
                            i++;
                        }
                        playerdead1 = true;
                        deathtimer1 = timer;
                        endtimer = endtimer + 1000;
                        i = a;
                    }
                    if (player2.IntersectsWith(explosion[i]) && playerdead2 == false)
                    {
                        a = i;
                        i = 0;
                        while (i < 40)
                        {
                            player2 = new Rectangle(player2.X, player2.Y + 1, 40, 40 - i);
                            Refresh();
                            Thread.Sleep(10);
                            i++;
                        }
                        playerdead2 = true;
                        deathtimer2 = timer;
                        endtimer = endtimer + 1000;
                        i = a;
                    }
                    for (int j = 0; j < breakWalls.Count; j++)
                    {
                        if (explosion[i].IntersectsWith(breakWalls[j]))
                        {


                            player1points = player1points + 300;
                            breakWalls.RemoveAt(j);
                            explosionplayer[i] = "p3";

                        }
                    }
                }              
                }

                if (timer - deathtimer1 == 200 && playerdead1 == true)
                {
                    player1 = new Rectangle(player1.X, player1.Y - 40, 40, 40);
                playerdead1 = false;
                }

                if (timer - deathtimer2 == 200 && playerdead2 == true)
                {
                    player2 = new Rectangle(player2.X, player2.Y - 40, 40, 40);
                playerdead2 = false;
                }
            


            timer++;
            player1pointLabel.Text = $"{player1points}";
            if (arcade == false)
            {
                player2pointLabel.Text = $"{player2points}";
            }
            else
            {
                endtimer++;
                player2pointLabel.Text = $"{10000 - endtimer}";
                if (endtimer >= 10000)
                {
                    EndGame(player1points, player2points);
                    arcade = false;
                }
            }   
            Refresh();
        }
        public void initializeGame()
        {
            victory.Stop();
            player1points = 0;
            player2points = 0;
            player1pointLabel.Visible = true;
            player2pointLabel.Visible = true;
            player1 = new Rectangle(50, 50, 40, 40);
            player2 = new Rectangle(450, 450, 40, 40);
            sightHort = new Rectangle(0, 50, 150, 50);
            sightVert = new Rectangle(50, 0, 50, 150);
            sightHort2 = new Rectangle(400, 450, 150, 50);
            sightVert2 = new Rectangle(450, 400, 50, 150);
            Rectangle wall1 = new Rectangle(100, 100, 50, 50);
            walls.Add(wall1);
            Rectangle wall2 = new Rectangle(200, 100, 50, 50);
            walls.Add(wall2);
            Rectangle wall3 = new Rectangle(300, 100, 50, 50);
            walls.Add(wall3);
            Rectangle wall4 = new Rectangle(400, 100, 50, 50);
            walls.Add(wall4);
            Rectangle wall5 = new Rectangle(100, 200, 50, 50);
            walls.Add(wall5);
            Rectangle wall6 = new Rectangle(200, 200, 50, 50);
            walls.Add(wall6);
            Rectangle wall7 = new Rectangle(300, 200, 50, 50);
            walls.Add(wall7);
            Rectangle wall8 = new Rectangle(400, 200, 50, 50);
            walls.Add(wall8);
            Rectangle wall9 = new Rectangle(100, 300, 50, 50);
            walls.Add(wall9);
            Rectangle wall10 = new Rectangle(200, 300, 50, 50);
            walls.Add(wall10);
            Rectangle wall11 = new Rectangle(300, 300, 50, 50);
            walls.Add(wall11);
            Rectangle wall12 = new Rectangle(400, 300, 50, 50);
            walls.Add(wall12);
            Rectangle wall13 = new Rectangle(100, 400, 50, 50);
            walls.Add(wall13);
            Rectangle wall14 = new Rectangle(200, 400, 50, 50);
            walls.Add(wall14);
            Rectangle wall15 = new Rectangle(300, 400, 50, 50);
            walls.Add(wall15);
            Rectangle wall16 = new Rectangle(400, 400, 50, 50);
            walls.Add(wall16);
            Rectangle wallside1 = new Rectangle(0, 0, 600, 50);
            walls.Add(wallside1);
            Rectangle wallside2 = new Rectangle(0, 0, 50, 600);
            walls.Add(wallside2);
            Rectangle wallside3 = new Rectangle(0, 500, 550, 50);
            walls.Add(wallside3);
            Rectangle wallside4 = new Rectangle(500, 0, 50, 550);
            walls.Add(wallside4);
            for (int i = 0; i < 22; i++)
            {
                breakwallsX = randGen.Next(1, 10);
                breakwallsY = randGen.Next(1, 10);

                Rectangle breakwalls = new Rectangle(breakwallsX * 50 + 5, breakwallsY * 50 + 5, 40, 40);
                for (int j = 0; j < breakWalls.Count; j++)
                {
                    while (breakwalls.IntersectsWith(breakWalls[j]))
                    {
                        breakwallsX = randGen.Next(1, 10);
                        breakwallsY = randGen.Next(1, 10);

                        breakwalls = new Rectangle(breakwallsX * 50 + 5, breakwallsY * 50 + 5, 40, 40);
                        j = 0;
                    }
                }
                for (int j = 0; j < walls.Count; j++)
                {
                    while (breakwalls.IntersectsWith(walls[j]) || breakwalls.IntersectsWith(player1) || breakwalls.IntersectsWith(sightHort) || breakwalls.IntersectsWith(sightVert) || breakwalls.IntersectsWith(sightHort2) || breakwalls.IntersectsWith(sightVert2))
                    {
                        breakwallsX = randGen.Next(1, 10);
                        breakwallsY = randGen.Next(1, 10);

                        breakwalls = new Rectangle(breakwallsX * 50 + 5, breakwallsY * 50 + 5, 40, 40);
                        j = 0;
                    }
                }
                breakWalls.Add(breakwalls);
            }
            victoryLabel.Text = "";
            gameTimer.Start();
            startButton.Enabled = false;
            startButton.Visible = false;
            exitButton.Enabled = false;
            exitButton.Visible = false;
            arcadeButton.Enabled = false;
            arcadeButton.Visible = false;
            // check = 0;
        }
        public void EndGame(int player1points, int player2points)
        {
            victory.Play();
            walls.Clear();
            breakWalls.Clear();
            explosion.Clear();
            bombs.Clear();
            explosionplayer.Clear();
            bombtime.Clear();
            bombplayer.Clear();
            check = 0;
            check2 = 0;
            bombcheck = 0;
            bombcheck2 = 0;
            timer = 0;
            endtimer = 0;
            player1pointLabel.Visible = false;
            player2pointLabel.Visible = false;
            playerdead1 = false;
            playerdead2 = false;
            if (arcade == false)
            {
                player1 = new Rectangle(50, 50, 0, 0);
                player2 = new Rectangle(450, 450, 0, 0);
                if (player2points > player1points)
                {
                    player2 = new Rectangle(280, 280, 40, 40);
                    victoryLabel.Text = $"Player 2 Wins      {player2points} Points!";
                }
                else if (player2points < player1points)
                {
                    player1 = new Rectangle(280, 280, 40, 40);
                    victoryLabel.Text = $"Player 1 Wins     {player1points} Points!";
                }
                else
                {
                    victoryLabel.Text = "Um";
                }
            }
            else
            {
                player1 = new Rectangle(240, 280, 40, 40);
                player2 = new Rectangle(280, 280, 40, 40);
                victoryLabel.Text = $"{player1points} Points!";
            }
            gameTimer.Enabled = false;
            Refresh();
            Thread.Sleep(5000);
            startButton.Enabled = true;
            startButton.Visible = true;
            exitButton.Enabled = true;
            exitButton.Visible = true;
            arcadeButton.Enabled = true;
            arcadeButton.Visible = true;
            player1pointLabel.Text = "";
            player2pointLabel.Text = "";
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Q:
                    qPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.Space:
                    spacePressed = false;
                    break;
                case Keys.Escape:
                    escPressed = false;
                    break;
                case Keys.P:
                    pPressed = false;
                    break;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.Q:
                    qPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
                case Keys.Space:
                    spacePressed = true;
                    break;
                case Keys.Escape:
                    escPressed = true;
                    break;
                case Keys.P:
                    pPressed = true;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                e.Graphics.FillRectangle(whiteBrush, walls[i]);
            }
            for (int i = 0; i < breakWalls.Count; i++)
            {
                e.Graphics.FillRectangle(blueBrush, breakWalls[i]);
            }
            for (int i = 0; i < bombs.Count; i++)
            {
                if (timer % 2 == 0)
                {
                    e.Graphics.FillEllipse(redBrush, bombs[i]);
                }
                else
                {
                    e.Graphics.FillEllipse(whiteBrush, bombs[i]);
                }
            }
            for (int i = 0; i < explosion.Count; i++)
            {
                e.Graphics.FillEllipse(redBrush, explosion[i]);
            }
            e.Graphics.FillEllipse(blueBrush, player1);
            e.Graphics.FillEllipse(purpBrush, player2);
            if (pPressed == true)
            {
                e.Graphics.FillEllipse(blueBrush, sightHort);
                e.Graphics.FillEllipse(blueBrush, sightVert);
                e.Graphics.FillEllipse(blueBrush, sightHort2);
                e.Graphics.FillEllipse(blueBrush, sightVert2);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            initializeGame();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void arcadeButton_Click(object sender, EventArgs e)
        {
            arcade = true;
            initializeGame();
        }
    }
}
