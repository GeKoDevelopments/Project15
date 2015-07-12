﻿using System;
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
                for (int i = 0; i < 4; i++)
                {
                    int option = rand.Next(1, 7);
                    switch (option)
                    {
                        case 1:
                            foo[i].Fill = col.red;
                            break;
                        case 2:
                            foo[i].Fill = col.orange;
                            break;
                        case 3:
                            foo[i].Fill = col.indigo;
                            break;
                        case 4:
                            foo[i].Fill = col.yellow;
                            break;
                        case 5:
                            foo[i].Fill = col.blue;
                            break;
                        case 6:
                            foo[i].Fill = col.green;
                            break;
                    }
                }
            }
            public void gray()
            {
                colors col = new colors();
                for (int i = 0; i < 4; i++)
                {
                    foo[i].Fill = col.gray;
                }
            }
        }


        public class ComboBlock
        {
            public Block ans { get; set; }
            public Block que { get; set; }

            public ComboBlock(Ellipse a1, Ellipse a2, Ellipse a3, Ellipse a4,
                Ellipse q1, Ellipse q2, Ellipse q3, Ellipse q4)
            {
                que = new Block(q1, q2, q3, q4);
                ans = new Block(a1, a2, a3, a4);
                que.gray();
                ans.gray();
            }
        }

}
