namespace SnackGame
{
    using System.Drawing;
    using System.Windows.Forms;
    using System.Collections.Generic;

    public partial class Form1 : Form
    {
        enum Direction { Up, Down, Left, Right }

        private readonly List<Point> snake = new();
        private Point food;
        private Direction dir = Direction.Right;
        private readonly Timer gameTimer = new();
        private readonly Random rnd = new();
        private int cellSize = 20;
        private int score = 0;

        public Form1()
        {
            InitializeComponent();

            // Basic form settings
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;

            // Timer
            gameTimer.Interval = 100; // ms
            gameTimer.Tick += GameTimer_Tick;

            StartNewGame();
            gameTimer.Start();
        }

        private void StartNewGame()
        {
            snake.Clear();
            // Start snake in the middle
            var start = new Point(ClientSize.Width / (2 * cellSize), ClientSize.Height / (2 * cellSize));
            snake.Add(start);
            snake.Add(new Point(start.X - 1, start.Y));
            snake.Add(new Point(start.X - 2, start.Y));
            dir = Direction.Right;
            score = 0;
            PlaceFood();
        }

        private void PlaceFood()
        {
            int maxX = Math.Max(1, ClientSize.Width / cellSize - 1);
            int maxY = Math.Max(1, ClientSize.Height / cellSize - 1);
            Point p;
            do
            {
                p = new Point(rnd.Next(0, maxX), rnd.Next(0, maxY));
            } while (snake.Contains(p));
            food = p;
        }

        private void GameTimer_Tick(object? sender, System.EventArgs e)
        {
            MoveSnake();
            Invalidate();
        }

        private void MoveSnake()
        {
            var head = snake[0];
            Point next = head;
            switch (dir)
            {
                case Direction.Up: next = new Point(head.X, head.Y - 1); break;
                case Direction.Down: next = new Point(head.X, head.Y + 1); break;
                case Direction.Left: next = new Point(head.X - 1, head.Y); break;
                case Direction.Right: next = new Point(head.X + 1, head.Y); break;
            }

            // Wrap-around behavior
            int maxX = Math.Max(0, ClientSize.Width / cellSize);
            int maxY = Math.Max(0, ClientSize.Height / cellSize);
            if (next.X < 0) next.X = maxX - 1;
            if (next.X >= maxX) next.X = 0;
            if (next.Y < 0) next.Y = maxY - 1;
            if (next.Y >= maxY) next.Y = 0;

            // Collision with self
            if (snake.Contains(next))
            {
                gameTimer.Stop();
                var result = MessageBox.Show($"Game over! Score: {score}.\nRestart?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    StartNewGame();
                    gameTimer.Start();
                }
                return;
            }

            // Move
            snake.Insert(0, next);

            // Eat food
            if (next == food)
            {
                score += 10;
                PlaceFood();
            }
            else
            {
                // remove tail
                snake.RemoveAt(snake.Count - 1);
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    if (dir != Direction.Down) dir = Direction.Up;
                    break;
                case Keys.Down:
                case Keys.S:
                    if (dir != Direction.Up) dir = Direction.Down;
                    break;
                case Keys.Left:
                case Keys.A:
                    if (dir != Direction.Right) dir = Direction.Left;
                    break;
                case Keys.Right:
                case Keys.D:
                    if (dir != Direction.Left) dir = Direction.Right;
                    break;
                case Keys.Space:
                    if (gameTimer.Enabled) gameTimer.Stop(); else gameTimer.Start();
                    break;
                case Keys.R:
                    StartNewGame();
                    break;
            }
        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            // background
            g.Clear(Color.Black);

            // draw food
            var foodRect = new Rectangle(food.X * cellSize, food.Y * cellSize, cellSize, cellSize);
            using (var b = new SolidBrush(Color.Red)) g.FillRectangle(b, foodRect);

            // draw snake
            using (var b = new SolidBrush(Color.Lime))
            {
                foreach (var p in snake)
                {
                    var r = new Rectangle(p.X * cellSize, p.Y * cellSize, cellSize - 1, cellSize - 1);
                    g.FillRectangle(b, r);
                }
            }

            // draw score
            using (var font = new Font("Arial", 12))
            using (var brush = new SolidBrush(Color.White))
            {
                g.DrawString($"Score: {score}", font, brush, new PointF(5, 5));
            }
        }
    }
}
