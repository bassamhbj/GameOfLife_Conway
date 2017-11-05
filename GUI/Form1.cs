using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GameOfLifeWindowsForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        public PictureBox[,] tableOutput;

        public static int[,] table;


        private void Form1_Load(object sender, EventArgs e) {
            CreateTableBox();
            DrawTable();
           
            Thread myThread = new Thread(DoLife);
            myThread.Start(); 
        }

        private void CreateTableBox() {
            tableOutput = new PictureBox[10, 10] {
                {cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8, cell9, cell10},
                {cell11, cell12, cell13, cell14, cell15, cell16, cell17, cell18, cell19, cell20},
                {cell21, cell22, cell23, cell24, cell25, cell26, cell27, cell28, cell29, cell30},
                {cell31, cell32, cell33, cell34, cell35, cell36, cell37, cell38, cell39, cell40},
                {cell41, cell42, cell43, cell44, cell45, cell46, cell47, cell48, cell49, cell50},
                {cell51, cell52, cell53, cell54, cell55, cell56, cell57, cell58, cell59, cell60},
                {cell61, cell62, cell63, cell64, cell65, cell66, cell67, cell68, cell69, cell70},
                {cell71, cell72, cell73, cell74, cell75, cell76, cell77, cell78, cell79, cell80},
                {cell81, cell82, cell83, cell84, cell85, cell86, cell87, cell88, cell89, cell90},
                {cell91, cell92, cell93, cell94, cell95, cell96, cell97, cell98, cell99, cell100}
            };


            for (int i = 0; i < 10; i++) {
                for(int j = 0; j < 10; j++) {
                    tableOutput[i, j].BorderStyle = BorderStyle.FixedSingle;
                }
            }
            table = new int[10, 10] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0},
                { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
                { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
        }

        private void DrawTable() {
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    if (table[i, j] == 1) {
                        tableOutput[i, j].BackColor = Color.White;
                    }
                    else {
                        tableOutput[i, j].BackColor = Color.Black;
                    }
                }
            }
        }

        private void CreateLife() {
            var tableAux = new int[10, 10];

            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    int count = 0;
                    if (i == 0) {
                        if (j == 0) {
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
                    else if (i == 9) {
                        if (j == 0) {
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
                        if (j == 0) {
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
                            if (i == 3 && j == 5) {
                                int a = 0;
                            }
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

        private void DoLife() {
            while (true) {
                this.CreateLife();
                this.DrawTable();
                Thread.Sleep(500);
            }
        }
    }
}
