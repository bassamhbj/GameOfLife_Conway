using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLifeConsole {
    class Program {
        //private static bool[,] table = new bool[8, 8] {
        //    { false, false, false, false, false, false, false, false},
        //    { false, false, false, false, false, false, false, false},
        //    { false, false, false, true, true, false, false, false},
        //    { false, false, false, false, true, true, false, false},
        //    { false, false, false, false, true, false, false, false},
        //    { false, false, false, false, false, false, false, false},
        //    { false, false, false, false, false, false, false, false},
        //    { false, false, false, false, false, false, false, false}
        //};

        private static int[,] table = new int[10, 10] {
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            { 2, 0, 0, 0, 1, 1, 0, 0, 0, 2},
            { 2, 0, 0, 0, 0, 1, 1, 0, 0, 2},
            { 2, 0, 0, 0, 0, 1, 0, 0, 0, 2},
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}
        };



        static void Main(string[] args) {
            DrawTable();
            //CreateLife();
            while (true) {
                Thread.Sleep(1000);
                Console.Clear();
                //Console.ReadKey();
                CreateLife();
                DrawTable();
                
            }
        }

        private static void DrawTable() {
            string[,] tableOuput = new string[10, 10];
            for(int i = 0; i < 10; i++) {
                for(int j = 0; j < 10; j++) {
                    if(i == 0 || i == 9) {
                        tableOuput[i, j] = j == 9 ? "#" + Environment.NewLine : "#";
                    }else {
                        if(j == 0 ) {
                            tableOuput[i, j] = "#";
                        }else if(j == 9) {
                            tableOuput[i, j] = "#" + Environment.NewLine;
                        }else if(table[i, j] == 1) {
                            tableOuput[i, j] = "・";
                        }else {
                            tableOuput[i, j] = " ";
                        }

                    }
                    Console.Write(tableOuput[i, j]);
                }
            }
        }
        
        private static void CreateLife() {
            var tableAux = new int[10, 10];

            for(int i = 0; i < 10; i++) {
                for(int j = 0; j < 10; j++) {
                    int count = 0;
                    if(i == 0)  {
                        if (j == 0)  {
                            count = table[i + 1, j] == 1 ? count + 1 : count;
                            count = table[i + 1, j + 1] == 1 ? count + 1 : count;
                            count = table[i, j + 1] == 1 ? count + 1 : count;
                        }
                        else if (j == 9) {
                            count = table[i + 1, j] == 1 ? count + 1 : count;
                            count = table[i + 1, j - 1] == 1 ? count + 1 : count;
                            count = table[i, j - 1] == 1 ? count + 1 : count;
                        }
                        else {
                            count = table[i + 1, j] == 1 ? count + 1 : count;
                            count = table[i + 1, j + 1] == 1 ? count + 1 : count;
                            count = table[i + 1, j - 1] == 1 ? count + 1 : count;
                            count = table[i, j + 1] == 1 ? count + 1 : count;
                            count = table[i, j - 1] == 1 ? count + 1 : count;
                        }
                    }
                    else if(i == 9) {
                        if (j == 0)  {
                            count = table[i - 1, j] == 1 ? count + 1 : count;
                            count = table[i - 1, j + 1] == 1 ? count + 1 : count;
                            count = table[i, j + 1] == 1 ? count + 1 : count;
                        }
                        else if (j == 9) {
                            count = table[i - 1, j] == 1 ? count + 1 : count;
                            count = table[i - 1, j - 1] == 1 ? count + 1 : count;
                            count = table[i, j - 1] == 1 ? count + 1 : count;
                        }
                        else {
                            count = table[i - 1, j] == 1 ? count + 1 : count;
                            count = table[i - 1, j + 1] == 1 ? count + 1 : count;
                            count = table[i - 1, j - 1] == 1 ? count + 1 : count;
                            count = table[i, j + 1] == 1 ? count + 1 : count;
                            count = table[i, j - 1] == 1 ? count + 1 : count;
                        }
                    }
                    else {
                        if (j == 0)  {
                            count = table[i + 1, j] == 1 ? count + 1 : count;
                            count = table[i + 1, j + 1] == 1 ? count + 1 : count;
                            count = table[i, j + 1] == 1 ? count + 1 : count;
                            count = table[i - 1, j] == 1 ? count + 1 : count;
                            count = table[i - 1, j + 1] == 1 ? count + 1 : count;
                        }
                        else if (j == 9) {
                            count = table[i + 1, j] == 1 ? count + 1 : count;
                            count = table[i + 1, j - 1] == 1 ? count + 1 : count;
                            count = table[i, j - 1] == 1 ? count + 1 : count;
                            count = table[i - 1, j] == 1 ? count + 1 : count;
                            count = table[i - 1, j - 1] == 1 ? count + 1 : count;
                        }
                        else {
                            if(i == 3 && j == 5) {
                                int a = 0; }                         
                            count = table[i, j + 1] == 1 ? count + 1 : count;
                            count = table[i, j - 1] == 1 ? count + 1 : count;
                            count = table[i + 1, j] == 1 ? count + 1 : count;
                            count = table[i - 1, j] == 1 ? count + 1 : count;

                            count = table[i + 1, j + 1] == 1 ? count + 1 : count;
                            count = table[i + 1, j - 1] == 1 ? count + 1 : count;
                            count = table[i - 1, j + 1] == 1 ? count + 1 : count;                          
                            count = table[i - 1, j - 1] == 1 ? count + 1 : count;
                        }
                    }

                    //System.Diagnostics.Debug.Print(tableAux[3, 6].ToString());
                    if ((count < 2 || count > 3) && table[i, j] == 1) { tableAux[i, j] = 0; }
                    else if (count == 3 && table[i, j] == 0) { tableAux[i, j] = 1; }
                    else if ((count == 3 || count == 2) && table[i, j] == 1) { tableAux[i, j] = 1; }
                     
                }    
            }
            table = tableAux;
        }
    }
}
