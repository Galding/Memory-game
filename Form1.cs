using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        int numberOfCardsOnTheBoard;

        int numberOfCardsInTheHoof;

        List<int> cardsIndex;

        Boolean isReveal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dispatch_Click(object sender, EventArgs e)
        {
            numberOfCardsInTheHoof = cardList.Images.Count - 1;
            numberOfCardsOnTheBoard = tableLayoutPanel1.Controls.Count;
            cardsIndex = RandomUtils.GenerateRandomNumberList(numberOfCardsInTheHoof, numberOfCardsOnTheBoard);
            isReveal = false;
            PictureBox pb;
            for (int i = 0; i < numberOfCardsOnTheBoard; i++)
            {
                pb = (PictureBox)tableLayoutPanel1.Controls[i];
                pb.Image = cardList.Images[0];
            }
        }

        private void OnPictureBoxClick(object sender, EventArgs e)
        {
            if (!isReveal)
            {
                PictureBox currentPb = (PictureBox)sender;
                currentPb.Image = cardList.Images[Convert.ToInt32(currentPb.Tag)];
            }
        }

        private void Reveal_Click(object sender, EventArgs e)
        {
            isReveal = true;
            for (int i = 0; i < numberOfCardsOnTheBoard; i++)
            {
                var pb = (PictureBox)tableLayoutPanel1.Controls[i];
                pb.Image = cardList.Images[cardsIndex.ElementAt(i)];
            }
        }
    }
}