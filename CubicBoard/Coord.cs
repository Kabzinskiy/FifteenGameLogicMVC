using System.Collections.Generic;


namespace CubicBoard
{
    struct Coord
    {
        public int x;
        public int y;

        public Coord(int x, int y)  //конструктор по координатам
        {
            this.x = x;
            this.y = y;
        }

        public Coord(int size)  //конструктор для пробела с одним параметром 
        {
            x = size - 1;
            y = size - 1;

        }

        public bool OnBoard(int size) {        //метод проверяющий на доске ли координата
            if (x < 0 || x > size - 1) return false;
            if (y < 0 || y > size - 1) return false;
            return true;
        }

        public IEnumerable<Coord> YieldCoord(int size) { //метод возвращающий подсчет 
            for (y = 0; y < size; ++y)
                for (x = 0; x < size; ++x)
                    yield return this;
        }

        internal Coord Add(int sx, int sy)
        {
            return new Coord(x + sx, y + sy);
        }
    }
}
