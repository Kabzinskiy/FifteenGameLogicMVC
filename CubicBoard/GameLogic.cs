using System;

namespace CubicBoard
{
    public class GameLogic
    {
        int size;
        Map map;
        Coord space;

        public int moves { get; private set; }
        public GameLogic(int size) {
            this.size = size;
            map = new Map(size);
        }

        public void Start(int seed = 0) {
            int digit = 0;
            foreach (Coord xy in new Coord().YieldCoord(size))
                map.Set(xy, ++digit);
            space = new Coord(size);
            if (seed > 0)
                Shuffle(seed);
            moves = 0;
        } 

        void Shuffle(int seed) {
            Random random = new Random(seed);
            for (int j = 0; j < seed; ++j)
                PressAt(random.Next(size), random.Next(size));
        }

        public int PressAt(int x, int y) {    //фасадный метод создает новый объект coord 
            return PressAt(new Coord (x, y));  // с помещенными в него параметрами
        }

        int PressAt(Coord xy) {

            if (space.Equals(xy)) return 0;   //если нажат 0 - не ходить
            if (xy.x != space.x && xy.y != space.y) return 0;  //если  нажата по диагонали

            int steps = Math.Abs(xy.x - space.x) +
                        Math.Abs(xy.y - space.y);

            while (xy.x != space.x)
                Shift(Math.Sign(xy.x - space.x), 0);

            while (xy.y != space.y)
                Shift(0, Math.Sign(xy.y - space.y));

            moves += steps;

            return steps;
        }
         
        void Shift(int sx, int sy) {
            Coord next = space.Add(sx, sy);  //сохраняем координату куда мы сдвигаемся
            map.Copy(next, space);    //копируем значение next пробелу
            space = next;     //пробелу становится на место next
        } 

        public int GetDigitAt(int x, int y) {     //фасадный метод создающий новый объект coord
            return GetDigitAt(new Coord(x, y));    //и помещающий в него параметры
        }

        int GetDigitAt(Coord xy) {   //если пробел возвращаем ноль иначе значение и map
            if (space.Equals(xy))
                return 0;
            return map.Get(xy);
        }

        public bool Solved() {
            if (!space.Equals(new Coord(size))) //проверка пробел ли на последнем месте
                return false;
            int digit = 0;
            foreach (Coord xy in new Coord().YieldCoord(size))//перебираем координаты в перечислении
                if (map.Get(xy) != ++digit) //
                    return space.Equals(xy);
            return true; 
        }
    }
}
