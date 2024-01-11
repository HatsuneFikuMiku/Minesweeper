using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaperV2
{
    public interface IGameEventListener
    {
        event EventHandler OnFirstTurn;
        event EventHandler OnGameWon;
    }
}
