using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeConsole {
  public class Life {
    private static int[,] pattern;

    public Life(Pattern.PatternTy patternTy) {
      pattern = Pattern.getPattern(patternTy);
    }

    public int[,] getLife() {
      //this.createLife();
      return pattern;
    }

    #region Private Methods
    public void createLife() {
      var tableAux = new int[10, 10] {
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

      for (int i = 0; i < 10; i++) {
        for (int j = 0; j < 10; j++) {
          int count = 0;
          if (i == 0) {
            if (j == 0) {
              count = pattern[i + 1, j] == 1 ? count + 1 : count;
              count = pattern[i + 1, j + 1] == 1 ? count + 1 : count;
              count = pattern[i, j + 1] == 1 ? count + 1 : count;
            } else if (j == 9) {
              count = pattern[i + 1, j] == 1 ? count + 1 : count;
              count = pattern[i + 1, j - 1] == 1 ? count + 1 : count;
              count = pattern[i, j - 1] == 1 ? count + 1 : count;
            } else {
              count = pattern[i + 1, j] == 1 ? count + 1 : count;
              count = pattern[i + 1, j + 1] == 1 ? count + 1 : count;
              count = pattern[i + 1, j - 1] == 1 ? count + 1 : count;
              count = pattern[i, j + 1] == 1 ? count + 1 : count;
              count = pattern[i, j - 1] == 1 ? count + 1 : count;
            }
          } else if (i == 9) {
            if (j == 0) {
              count = pattern[i - 1, j] == 1 ? count + 1 : count;
              count = pattern[i - 1, j + 1] == 1 ? count + 1 : count;
              count = pattern[i, j + 1] == 1 ? count + 1 : count;
            } else if (j == 9) {
              count = pattern[i - 1, j] == 1 ? count + 1 : count;
              count = pattern[i - 1, j - 1] == 1 ? count + 1 : count;
              count = pattern[i, j - 1] == 1 ? count + 1 : count;
            } else {
              count = pattern[i - 1, j] == 1 ? count + 1 : count;
              count = pattern[i - 1, j + 1] == 1 ? count + 1 : count;
              count = pattern[i - 1, j - 1] == 1 ? count + 1 : count;
              count = pattern[i, j + 1] == 1 ? count + 1 : count;
              count = pattern[i, j - 1] == 1 ? count + 1 : count;
            }
          } else {
            if (j == 0) {
              count = pattern[i + 1, j] == 1 ? count + 1 : count;
              count = pattern[i + 1, j + 1] == 1 ? count + 1 : count;
              count = pattern[i, j + 1] == 1 ? count + 1 : count;
              count = pattern[i - 1, j] == 1 ? count + 1 : count;
              count = pattern[i - 1, j + 1] == 1 ? count + 1 : count;
            } else if (j == 9) {
              count = pattern[i + 1, j] == 1 ? count + 1 : count;
              count = pattern[i + 1, j - 1] == 1 ? count + 1 : count;
              count = pattern[i, j - 1] == 1 ? count + 1 : count;
              count = pattern[i - 1, j] == 1 ? count + 1 : count;
              count = pattern[i - 1, j - 1] == 1 ? count + 1 : count;
            } else {
              if (i == 3 && j == 5) {
                int a = 0;
              }
              count = pattern[i, j + 1] == 1 ? count + 1 : count;
              count = pattern[i, j - 1] == 1 ? count + 1 : count;
              count = pattern[i + 1, j] == 1 ? count + 1 : count;
              count = pattern[i - 1, j] == 1 ? count + 1 : count;

              count = pattern[i + 1, j + 1] == 1 ? count + 1 : count;
              count = pattern[i + 1, j - 1] == 1 ? count + 1 : count;
              count = pattern[i - 1, j + 1] == 1 ? count + 1 : count;
              count = pattern[i - 1, j - 1] == 1 ? count + 1 : count;
            }
          }

          if ((count < 2 || count > 3) && pattern[i, j] == 1) { tableAux[i, j] = 0; } 
          else if (count == 3 && pattern[i, j] == 0) { tableAux[i, j] = 1; } 
          else if ((count == 3 || count == 2) && pattern[i, j] == 1) { tableAux[i, j] = 1; }

        }
      }
      pattern = tableAux;
    }
    #endregion
  }
}
