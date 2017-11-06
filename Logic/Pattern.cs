using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeConsole {
  public static class Pattern {    
    public enum PatternTy {
      TYPE_1 = 1,
    }

    public static int[,] getPattern(PatternTy patterTy) {
      int[,] pattern;
      switch (patterTy) {
        case PatternTy.TYPE_1: pattern = getPattern1(); break;
        default: pattern = getPattern1(); break;
      }

      return pattern;
    }

    #region Private Members
    private static int[,] getPattern1() {
      int[,] pattern1 = new int[10, 10] {
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

      return pattern1;
    }
    #endregion
  }
}
