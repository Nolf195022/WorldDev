﻿namespace WorldDev
{
    public class Acacia : Plant
    {
        public Acacia() :
            base("Acacia", 500, 200, 30, 40)
        {
        }
        public void Extend(Board board)
        {
            board.Add(new Acacia());
        }
    }
}