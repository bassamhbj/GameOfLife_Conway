using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLifeConsole {
  public class Program : Observer{

    private static LifeThread lifeThread;
    private static Life life;

    static void Main(string[] args) {
      initLife();
    }

    private static void initLife() {
      drawTable(Pattern.getPattern(Pattern.PatternTy.TYPE_1));
      life = new Life(Pattern.PatternTy.TYPE_1);
      lifeThread = new LifeThread(getProgramContext(), life, Pattern.PatternTy.TYPE_1);
      lifeThread.startThread();
    }

    private static void drawTable(int[,] lifeData) {
      string[,] tableOuput = new string[10, 10];
      for (int i = 0; i < 10; i++) {
        for (int j = 0; j < 10; j++) {
          if (i == 0 || i == 9) {
            tableOuput[i, j] = j == 9 ? "#" + Environment.NewLine : "#";
          } else {
            if (j == 0) {
              tableOuput[i, j] = "#";
            } else if (j == 9) {
              tableOuput[i, j] = "#" + Environment.NewLine;
            } else if (lifeData[i, j] == 1) {
              tableOuput[i, j] = "@";
            } else {
              tableOuput[i, j] = " ";
            }

          }
          Console.Write(tableOuput[i, j]);
        }
      }
    }

    private static Program getProgramContext() {
      Program p = new Program();
      return p;
    }

    public void onLifeCreated(Life life) {
      ////lifeThread.joinThread();
      Console.Clear();
      drawTable(life.getLife());
      lifeThread = new LifeThread(getProgramContext(), life, Pattern.PatternTy.TYPE_1);
      lifeThread.startThread();
    }
  }
}
