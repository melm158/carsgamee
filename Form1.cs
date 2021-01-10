using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Size = new Size(70, 20);
        }
        // the main variables 
        enum dirctions {left ,right ,up ,down,non }
        enum dirctions2 { left, right, up, down, non }
        int score = 0;
        int score2 = 0;
        int coin = 0;
        int coin2 = 0;
        int speed= 5;
        Random move = new Random();
        dirctions dir = dirctions.non;
        dirctions2 dir2 = dirctions2.non;



        private void timer1_Tick(object sender, EventArgs e)
        {
            //coins 
            label5.Text = "   coins 1  : " + coin;
           
            // the increse of the score
            score++;
            label1.Text = "   score  :  " + score / 10;
            if (score/10 == 100)
            {
                speed = 7;
            }
            if (score/10 == 200)
            {
                speed = 10;
            }
            if (score/10 == 500)
            {
                speed = 12;
            }
            if (score/10 == 1000)
            {
                speed = 15;
            }
            // the score for the second player

            if (pirson2.Visible == true)
            {

                label4.Visible = true;
                label4.Enabled = true;
                    label4.Text = "   coins 2  : " + coin2;
                

                label3.Visible = true;
                label3.Enabled = true;
                score2 ++;
                label3.Text = "   score two  :  " + score2 / 10;
                if (score2 / 10 == 100)
                {
                    speed = 7;
                }
                if (score2 / 10 == 200)
                {
                    speed = 10;
                }
                if (score2 / 10 == 500)
                {
                    speed = 12;
                }
                if (score2 / 10 == 1000)
                {
                    speed = 15;
                }
            }
            // the imagination move 
            p1.Top += speed;
            p2.Top += speed;
            p3.Top += speed;
            p4.Top += speed;
            p5.Top += speed;
            p6.Top += speed;

            if (p1.Top > panel1.Height  )
            {
                p1.Top =-p1.Height;
            }
            if (p2.Top > panel1.Height)
            {
                p2.Top = -p2.Height;
            }
            if (p3.Top > panel1.Height)
            {
                p3.Top = -p3.Height;
            }
            if (p4.Top > panel1.Height)
            {
                p4.Top = -p4.Height;
            }
            if (p5.Top > panel1.Height)
            {
                p5.Top = -p5.Height;
            }
            if (p6.Top > panel1.Height)
            {
                p6.Top = -p6.Height;
            }

            car1.Top += speed;
            car2.Top += speed;
            //           move for enemy 1
            if(car1.Top > panel1.Height)
            {
                car1.Top = -car1.Height;
                car1.Visible = false;
                car1.Left = move.Next((panel1.Width ) / 2);
                car1.Visible = true;

            }
            // move for enemy 2
            if (car2.Top > panel1.Height)
            {
                car2.Top = -car2.Height;
                car2.Visible = false;
                car2.Left = move.Next((panel1.Width) / 2, panel1.Width );
                car2.Visible = true;

            
            }
            // coins 
            c1.Top += speed;
            c2.Top += speed;
         
            if (c1.Top > panel1.Height)
            {
                c1.Top = -c1.Height;
                c1.Visible = false;
                c1.Left = move.Next((panel1.Width) / 2, panel1.Width-10);
                c1.Visible = true;
                if (c1.Location == car1.Location || c1.Left == car2.Left)
                {
                    c1.Visible = false;
                    c1.Enabled = false;
                }

            }
            if (c2.Top > panel1.Height)
            {
                c2.Top = -c1.Height;
                c2.Visible = false;
                c2.Left = move.Next((panel1.Width) / 2, panel1.Width-10);
                
                c2.Visible = true;
                if (c2.Location == car1.Location || c2.Location == car2.Location)
                {
                    c2.Visible = false;
                    c2.Enabled = false;
                }


            }
            // increse the coins 
            if (pictureBox1.Bounds.IntersectsWith(c1.Bounds) )
            {
                coin = coin + 1;
                c1.Visible = false;
                c1.Enabled = false;
                
            }
            if (pictureBox1.Bounds.IntersectsWith(c2.Bounds))
            {
                coin = coin + 1;
                c2.Visible = false;
                c2.Enabled = false;
            }
            if (pirson2.Bounds.IntersectsWith(c1.Bounds))
            {
                coin2 = coin2 + 1;
                c1.Visible = false;
                c1.Enabled = false;

            }
            if (pirson2.Bounds.IntersectsWith(c2.Bounds))
            {
                coin2 = coin2 + 1;
                c2.Visible = false;
                c2.Enabled = false;
            }

            //lose the game 
            if (pictureBox1.Bounds.IntersectsWith(car1.Bounds) || pictureBox1.Bounds.IntersectsWith(car2.Bounds))
            {
                timer1.Enabled = false;
                label2.Visible = true;
                pirson2.Visible = false;
                pirson2.Enabled = false;
                label3.Visible = false;
                label3.Enabled = false;
                score2 = 0;
                coin2 = 0;
                label4.Visible = false;
                label4.Enabled = false;

            }
            // the lose of car 2
            if (pirson2.Bounds.IntersectsWith(car1.Bounds) || pirson2.Bounds.IntersectsWith(car2.Bounds))
            {
                pirson2.Visible = false;
                pirson2.Enabled = false;
                label3.Visible = false;
                label3.Enabled = false;
                score2 = 0;
                coin2 = 0;
                label4.Visible = false;
                label4.Enabled = false;

            }
                // the main car move 
                if (dir == dirctions.left && pictureBox1.Left >0 )
            {
                pictureBox1.Left -= speed;
            }
            if (dir == dirctions.right && pictureBox1.Left < panel1.Width -pictureBox1.Width )
            {
                pictureBox1.Left += speed;
            }
            if (dir== dirctions.up && pictureBox1.Top > 0)
            {
                pictureBox1.Top -= speed;
            }
            if (dir == dirctions.down && pictureBox1.Top < panel1.Height - pictureBox1.Height)
            {
                pictureBox1.Top += speed;
            }
            //pirson 2 the second car  move 
            if (dir2 == dirctions2.left && pirson2.Left > 0)
            {
                pirson2.Left -= speed;
            }
            if (dir2 == dirctions2.right && pirson2.Left < panel1.Width - pirson2.Width)
            {
                pirson2.Left += speed;
            }
            if (dir2 == dirctions2.up && pirson2.Top > 0)
            {
                pirson2.Top -= speed;
            }
            if (dir2 == dirctions2.down && pirson2.Top < panel1.Height - pirson2.Height)
            {
                pirson2.Top += speed;
            }




        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // the move of main car 
            if (e.KeyData == Keys.Left)
            {
                dir = dirctions.left;
            }
            else if (e.KeyData == Keys.Right)
            {

                dir = dirctions.right;

            }
            else if (e.KeyData == Keys.Up)
            {
                dir = dirctions.up;
                
            }
            else if (e.KeyData == Keys.Down)
            {
                dir = dirctions.down;
               

            }
            // the new game 
            if (label2.Visible==true)
                if(e.KeyData==Keys.Enter)
                {
                    timer1.Enabled = true;
                    label2.Visible = false;
                    car1.Left = 0;
                    car2.Left = panel1.Width - car2.Width;
                     score = 0;
                     speed = 5;
                
                }
            // the move of the second car 
           if ( e.KeyData == Keys.W)
            {
                dir2 = dirctions2.up;
            }
            if (e.KeyData == Keys.S)
            {
                dir2 = dirctions2.down;
            }
            if (e.KeyData == Keys.A)
            {
                dir2 = dirctions2.left;
            }
            if (e.KeyData == Keys.D)
            {
                dir2 = dirctions2.right;
            }
            if (e.KeyData ==Keys.Q)
            {
                pirson2.Visible = true;
                pirson2.Enabled = true;
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            dir = dirctions.non;
            dir2 = dirctions2.non;
        }

        private void c2_Click(object sender, EventArgs e)
        {

        }
    }
}
