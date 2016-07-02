using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_PatternCraft_State
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IUnit tank =  new Tank();
            tank.State = new SiegeState();
            Console.WriteLine(tank.State);
            Console.WriteLine(tank.CanMove);
            Console.WriteLine(tank.Damage);

        }
    }

    public interface IUnit
    {

        IUnitState State { get; set; }
        bool CanMove { get; }
        int Damage { get; }
    }

    public interface IUnitState
    {
        bool CanMove { get; set; }
        int Damage { get; set; }
    }

    public class SiegeState : IUnitState
    {
        private bool _canmove;
        private int _damage;
        Tank mytank = new Tank();

        public SiegeState()
        {          
            _canmove = false;
            _damage = 20;
         }
        private void StateChanged(object sender, EventArgs e)
        {
            mytank.State = this;
            mytank.CanMove = false;
            mytank.Damage = 20;
        }

        #region "Properties"
        public bool CanMove
        {
            get { return _canmove; }
            set { _canmove = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        #endregion
    }

    public class TankState : IUnitState
    {
        
        private bool _canmove;
        private int _damage;
     
        public TankState()
        {

            _canmove = true;
            _damage = 5;

        }

        #region "Properties"
        public bool CanMove
        {
            get { return _canmove; }
            set { _canmove = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        #endregion
    }

    public  class Tank :  IUnit
    {
   
        private static bool _canmove;
        private static int _damage;
        private static IUnitState _state;
        public Tank()
        { 
            _state = new TankState();
            _canmove = _state.CanMove;
            _damage = _state.Damage;
        }

        #region "Properties"
        public bool CanMove
        {
            get { return _state.CanMove; }
            set { _state.CanMove = value; }
        }
        public int Damage
        {
            get { return _state.Damage; }
            set { _state.Damage = value; }
        }
        public IUnitState State
        {
            get { return _state; }
            set { _state = value; }
        }

        #endregion

    }

}