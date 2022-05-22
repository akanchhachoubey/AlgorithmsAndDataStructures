using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class PathInARectangle
    {
        public static int[,] Rectangle;
        public static int M;
        public static int N;
        public static int K;
        public static int R;
        public static int[] X;
        public static int[] Y;

        public static void execute()
        {
            TakeInputs();
            Intialize();
            RunDFS(1, 1);
            if(Rectangle[M,N]==1) Console.WriteLine("Possible");
            Console.ReadLine();
        }

        public static void RunDFS(int x,int y)
        {            
            if (Rectangle[x, y] == 0)
            {
                Rectangle[x, y] = 1;
                if (x == M && y == N)
                    return;
                if (x - 1 >= 1 && Rectangle[x - 1, y] == 0)
                    RunDFS(x - 1, y);
                if (x + 1 <= M && Rectangle[x + 1, y] == 0)
                    RunDFS(x + 1, y);
                if (y - 1 >= 1 && Rectangle[x, y - 1] == 0)
                    RunDFS(x, y - 1);
                if (y + 1 <= 1 && Rectangle[x, y + 1] == 0)
                    RunDFS(x, y + 1);
                if (y - 1 >= 1 && x-1>=1 && Rectangle[x-1, y - 1] == 0)
                    RunDFS(x-1, y - 1);
                if (y - 1 >= 1 && x + 1 <= M && Rectangle[x+1, y -1] == 0)
                    RunDFS(x+1, y-1);
                if (y + 1 <=N && x +1 <=M && Rectangle[x +1, y +1] == 0)
                    RunDFS(x +1,y+1);
                if (x - 1 >= 1 && y + 1 <= N && Rectangle[x -1, y +1] == 0)
                    RunDFS(x -1, y +1);
            }
        }

        public static void TakeInputs()
        {
            string s = Console.ReadLine();
            string[] str = s.Split(' ');
            M = Convert.ToInt32(str[0]);
            N = Convert.ToInt32(str[1]);
            K = Convert.ToInt32(str[2]);
            R = Convert.ToInt32(str[3]);
            Rectangle = new int[M + 1, N + 1];
            X = new int[K];
            Y = new int[K];
            for (int i = 0; i < K; i++)
            {
                s = Console.ReadLine();
                str = s.Split(' ');
                X[i] = Convert.ToInt32(str[0]);
                Y[i] = Convert.ToInt32(str[1]);
            }
            for (int i = 0; i <= M; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    if (i > 0 && j > 0)
                        Rectangle[i, j] = 0;
                    else
                        Rectangle[i,j] = -1;
                }
            }
        }

        public static void Intialize()
        {
            for (int k = 0; k < K; k++)
            {
                int x = X[k];
                int y = Y[k];
                for (int i = 1; i <= M; i++)
                {
                    for (int j = 1; j <= N; j++)
                    {
                        if(
                            Math.Sqrt((Math.Pow((x  - i), 2) + Math.Pow((y  - j), 2))) <= R)
                        {
                            Rectangle[i, j] = 2;
                        }

                    }

                }
            }
        }
    }
}


//(i>=0  && i<=M && i>=x-R && i <=x+R)
//                            &&
//                            (j >= 0 && j <= N && j >= y - R && j <= y + R)
//                            )