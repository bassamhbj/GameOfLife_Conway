using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLifeForm {
  public class LifeThread {
    private Observer obs;
    private Life life;
    private Thread lifeThread;

    /* For Console Version use this Constructor */

    //public LifeThread(Program program, Life life, Pattern.PatternTy patternTy) {
    //  this.obs = program;
    //  this.life = life;
    //  lifeThread = new Thread(doLife);
    //}

    /* For Windows Form Version use this Constructor */

    public LifeThread(Form1 form, Life life, Pattern.PatternTy patternTy) {
      this.obs = form;
      this.life = life;
      lifeThread = new Thread(doLife);
    }

    #region Thread Methods
    public void startThread() {
      lifeThread.Start();
    }

    public void joinThread() {
      lifeThread.Join();
    }

    public bool isAlive() {
      return lifeThread.IsAlive;

    }
    #endregion

    #region Private Methods
    private void doLife() {
      //int[,] lifeData = life.getLife();
      life.createLife();
      Thread.Sleep(500);
      obs.onLifeCreated(life);
    }
    #endregion
  }
}
