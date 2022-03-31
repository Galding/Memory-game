namespace Memory_Game
{
    internal class TimerUtils
    {
        public static void wait(int milliseconds)
        {
            var timer = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer.Interval = milliseconds;
            timer.Enabled = true;
            timer.Start();
            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
            };
            while (timer.Enabled)
            { }
        }
    }
}
