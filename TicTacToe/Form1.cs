using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool player = true; // true = joueur1 | false = joueur2
        int play = 1;
        int[] Tgrid = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }

        private void checkGrid()
        {
            int dulTobr = Tgrid[0] + Tgrid[4] + Tgrid[8]; // diagonal upper left to bottom right
            int durTobl = Tgrid[2] + Tgrid[4] + Tgrid[6]; // diagonal upper right to bottom left

            for (int i = 0; i < 3; i++)
            {
                int hresult = Tgrid[i * 3] + Tgrid[i * 3 + 1] + Tgrid[i * 3 + 2]; // horizontal check
                int vresult = Tgrid[i] + Tgrid[i + 3] + Tgrid[i + 6]; // vertical check
                if (hresult == 3 || vresult == 3 || dulTobr == 3 || durTobl == 3)
                    MessageBox.Show("Joueur 2 a gagné");
                if (hresult == -3 || vresult == -3 || dulTobr == -3 || durTobl == -3)
                    MessageBox.Show("Joueur 1 a gagné");
            }

        }

        private string getCrossOrCircle()
        {
            play = -play;
            player = !player;
            if (player) return "X";
            return "O";
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            if (btn.Text == String.Empty)
                btn.Text = getCrossOrCircle();
            Tgrid[btn.TabIndex] = play;
            btn.Enabled = false;
            checkGrid();
        }

    }


    #region tree generic
    class Tree<T>
    {
        private T data;
        private LinkedList<Tree<T>> children;

        public Tree(T data)
        {
            this.data = data;
            children = new LinkedList<Tree<T>>();
        }
        public void addChild(T data)
        {
            children.AddFirst(new Tree<T>(data));
        }

        public Tree<T> getChild(int i)
        {
            foreach (Tree<T> n in children)
                if (--i == 0)
                    return n;
            return null;
        }
        public LinkedList<Tree<T>> getChildren()
        {
            return children;
        }
    }
    #endregion

}

