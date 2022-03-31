using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        int numberOfCardsOnTheBoard;

        int numberOfCardsInTheHoof;

        List<int> cardsIndex;

        Boolean isReveal;

        List<int> foundedCards = new List<int>();

        int firstReturnedCardIndex = -1;
        int secondReturnedCardIndex = -1;

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
            if (timer1.Enabled) return;
            if (!isReveal)
            {
                PictureBox currentPb = (PictureBox)sender;
                int tagValue = Convert.ToInt32(currentPb.Tag) - 1;
                int item = cardsIndex.ElementAt(tagValue);
                if (foundedCards.Contains(item)) return;
                currentPb.Image = cardList.Images[item];
                if (firstReturnedCardIndex == -1)
                {
                    firstReturnedCardIndex = tagValue;
                }
                else
                {
                    VeridyCardsValidity(currentPb, tagValue);
                }
            }
        }
        /**
         * Vérifie si les deux cartes retournées sont égales ou non.
         * Affiche un message et bloque la grille en cas de victoire
         */
        private void VeridyCardsValidity(PictureBox currentPb, int tagValue)
        {
            PictureBox otherBox = (PictureBox)tableLayoutPanel1.Controls[firstReturnedCardIndex];
            otherBox.Image = cardList.Images[cardsIndex.ElementAt(firstReturnedCardIndex)];
            secondReturnedCardIndex = tagValue;
            if (firstReturnedCardIndex == secondReturnedCardIndex) return;
            if (cardsIndex.ElementAt(secondReturnedCardIndex) != cardsIndex.ElementAt(firstReturnedCardIndex))
            {
                timer1.Start();
            }
            else
            {
                currentPb.Image = cardList.Images[cardsIndex.ElementAt(secondReturnedCardIndex)];
                foundedCards.Add(cardsIndex.ElementAt(firstReturnedCardIndex));
                foundedCards.Add(cardsIndex.ElementAt(secondReturnedCardIndex));
                firstReturnedCardIndex = -1;
                if (foundedCards.Count == numberOfCardsOnTheBoard)
                {
                    MessageBox.Show("Bien joué");
                    isReveal = true;
                }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            PictureBox first = (PictureBox)tableLayoutPanel1.Controls[firstReturnedCardIndex];
            first.Image = cardList.Images[0];

            PictureBox second = (PictureBox)tableLayoutPanel1.Controls[secondReturnedCardIndex];
            second.Image = cardList.Images[0];
            firstReturnedCardIndex = -1;
            secondReturnedCardIndex = -1;
        }
    }
}