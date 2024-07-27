using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SnakeGame
{
    public partial class MainGame : Form
    {
        private List<Point> snake = new List<Point>();
        private Point food;
        private Direction currentDirection = Direction.Right;
        private Random random = new Random();
        private int score = 0;

        public MainGame()
        {
            InitializeComponent();
        }

        private void InitializeGame()
        {
            snake.Clear();
            snake.Add(new Point(5, 5));
            GenerateFood();
            timer1.Start();
            currentDirection = Direction.Right;
            this.KeyDown += new KeyEventHandler(OnKeyDown);
        }

        private void GenerateFood()
        {
            int maxX = this.ClientSize.Width / 20;
            int maxY = this.ClientSize.Height / 20;
            food = new Point(random.Next(0, maxX), random.Next(0, maxY));
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (currentDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;
                case Keys.Down:
                    if (currentDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
                case Keys.Left:
                    if (currentDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;
                case Keys.Right:
                    if (currentDirection != Direction.Left)
                        currentDirection = Direction.Right;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            this.Invalidate();
        }

        private void MoveSnake()
        {
            Point head = snake[0];
            Point newHead = head;

            switch (currentDirection)
            {
                case Direction.Up:
                    newHead.Y--;
                    break;
                case Direction.Down:
                    newHead.Y++;
                    break;
                case Direction.Left:
                    newHead.X--;
                    break;
                case Direction.Right:
                    newHead.X++;
                    break;
            }

            snake.Insert(0, newHead);
            if (newHead == food)
            {
                score++;
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        private void GhostSnake(char wall)
        {
            Point head = snake[0];
            Point newHead = head;

            switch (wall)
            {
                case 'U':
                    newHead.Y = this.ClientSize.Height / 20;
                    break;
                case 'D':
                    newHead.Y = 0;
                    break;
                case 'L':
                    newHead.X = this.ClientSize.Width / 20;
                    break;
                case 'R':
                    newHead.X = 0;
                    break;
            }

            snake.Insert(0, newHead);
            if (newHead == food)
            {
                score++;
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        private void CheckCollision()
        {
            Point head = snake[0];

            // Check wall collision
            if (head.X < 0 )
            {
               GhostSnake('L'); 
            }else if (head.X >= this.ClientSize.Width / 20) { GhostSnake('R'); }
            else if (head.Y < 0) { GhostSnake('U'); }
            else if (head.Y >= this.ClientSize.Height / 20) { GhostSnake('D'); }

            head = snake[0];
            // Check self collision
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[i] == head)
                {
                    GameOver();
                }
            }
        }

        private void GameOver()
        {
            timer1.Stop();
            MessageBox.Show("Game Over! Your score: " + score);
            StartButton.Visible = true;
            StartButton.Enabled = true;
        }

        private void PlayMode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Uncheck all other items
                for (int i = 0; i < PlayMode.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        PlayMode.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (PlayMode.CheckedItems.Count > 0)
            {
                Console.WriteLine(PlayMode.CheckedItems[0].ToString());
                switch (PlayMode.CheckedItems[0].ToString())
                {
                    case "Easy":
                        timer1.Interval = 200; break;
                    case "Medium":
                        timer1.Interval = 100; break;
                    case "Hard":
                        timer1.Interval = 50; break;

                }
                StartButton.Text = "Again!";
                StartButton.Visible = false;
                StartButton.Enabled = false;
                PlayMode.Enabled = false;
                PlayMode.Visible = false;
                InitializeGame();
            }
            else
            {
                MessageBox.Show("Select A Level");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw snake
            foreach (Point point in snake)
            {
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle(point.X * 20, point.Y * 20, 20, 20));
            }

            // Draw food
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(food.X * 20, food.Y * 20, 20, 20));
        }

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
