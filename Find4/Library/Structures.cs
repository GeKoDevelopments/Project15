using System;
using Windows.UI.Xaml.Shapes;


namespace Find4
{
    public class Block
    {
        public Ellipse[] foo { get; set; }
        public Block(Ellipse q1, Ellipse q2, Ellipse q3, Ellipse q4)
        {
            foo = new Ellipse[4];
            foo[0] = q1;
            foo[1] = q2;
            foo[2] = q3;
            foo[3] = q4;
        }

        public void randomize()
        {
            colors col = new colors();
            Random rand = new Random();
            foreach (Ellipse e in foo)
            {
                int option = rand.Next(1, 7);
                switch (option)
                {
                    case 1:
                        e.Fill = col.red;
                        break;
                    case 2:
                        e.Fill = col.orange;
                        break;
                    case 3:
                        e.Fill = col.indigo;
                        break;
                    case 4:
                        e.Fill = col.violet;
                        break;
                    case 5:
                        e.Fill = col.blue;
                        break;
                    case 6:
                        e.Fill = col.green;
                        break;
                }
            }
        }
        public void gray(int from = 0, int to = 4)
        {
            if (from < 0 || to > 4) return;
            colors col = new colors();
            for (int i = from; i < to; i++)
            {
                foo[i].Fill = col.gray;
            }
        }
    }

    public class ComboBlock
    {
        public Block ans;
        public Block que;

        public ComboBlock(Ellipse a1, Ellipse a2, Ellipse a3, Ellipse a4,
            Ellipse q1, Ellipse q2, Ellipse q3, Ellipse q4)
        {
            que = new Block(q1, q2, q3, q4);
            ans = new Block(a1, a2, a3, a4);
        }
    }

}
