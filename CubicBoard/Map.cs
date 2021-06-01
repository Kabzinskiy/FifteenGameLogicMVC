namespace CubicBoard
{
    struct Map
    {
        int size;
        int[,] map;  //массив интов работающий с coord
        public Map(int size) {   //коснтруктор создающий новую карту по размеру
            this.size = size;
            map = new int[size, size];
            
        }

        public void Set(Coord xy, int value) {   //устанавливаем значение инт в массив по координате
            if (xy.OnBoard(size))
                map[xy.x, xy.y] = value; 
        }

        public int Get(Coord xy) {   //получаем значение инт из массива инт по координате
            if (xy.OnBoard(size))
                return map[xy.x, xy.y];
            return 0; 
        }

        public void Copy(Coord from, Coord to)  //получаем значение из from и ложим в to
        {
            Set(to, Get(from));
        }
    }
}
