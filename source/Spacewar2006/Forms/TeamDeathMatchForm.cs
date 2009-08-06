using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SpaceWar2006.Rules;
using SpaceWar2006.GameObjects;

namespace Spacewar2006.Forms
{
    public partial class TeamDeathMatchForm : UserControl, IRuleCreator
    {
        public TeamDeathMatchForm()
        {
            InitializeComponent();
        }

        #region IRuleCreator Members

        public GameRule CreateRule()
        {
            string[] teamnames = Array.FindAll<string>(Teams.Lines, delegate(string s1) { return s1.Length > 0; });

            if (teamnames.Length < 2)
                throw new Exception();

            Team[] teams=new Team[teamnames.Length];
            for(int i=0;i<teams.Length;++i)
            {
                teams[i]=new Team(i,teamnames[i]);
            }

            return new TeamDeathMatch(
                teams,
                (int)FragLimit.Value,
                (float)TimeLimit.Value * 60
                );
        }

        #endregion
    }
}
