using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GameOfLifeForm {
  public partial class Form1 : Form, Observer {
    public Form1() {
      InitializeComponent();
    }
    public PictureBox[,] tableOutput;

    public static int[,] table;

    private static LifeThread lifeThread;
    private static Life life;


    private void Form1_Load(object sender, EventArgs e) {
      CreateTableBox();
      life = new Life(Pattern.PatternTy.TYPE_1);
      drawTable(life.getLife());

      lifeThread = new LifeThread(this, life, Pattern.PatternTy.TYPE_1);
      lifeThread.startThread();
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
        for (int j = 0; j < 10; j++) {
          tableOutput[i, j].BorderStyle = BorderStyle.FixedSingle;
        }
      }
    }

    private void drawTable(int[,] data) {
      for (int i = 0; i < 10; i++) {
        for (int j = 0; j < 10; j++) {
          if (data[i, j] == 1) {
            tableOutput[i, j].BackColor = Color.White;
          } else {
            tableOutput[i, j].BackColor = Color.Black;
          }
        }
      }
    }

    public void onLifeCreated(Life life) {
      drawTable(life.getLife());
      lifeThread = new LifeThread(this, life, Pattern.PatternTy.TYPE_1);
      lifeThread.startThread();
    }
  }
}
