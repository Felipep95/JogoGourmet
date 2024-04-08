using Microsoft.VisualBasic;
using ObjectiveTestJogoGourmet.Model;
using System;
using System.Windows.Forms;

namespace ObjectiveTestJogoGourmet
{
    public partial class JogoGourmet : Form
    {
        BinarySearchTree knowledgeTree;
        bool infiniteLoop = true;

        public JogoGourmet()
        {
            InitializeComponent();
            knowledgeTree = new BinarySearchTree();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void SetupGame()
        {
            knowledgeTree.Insert(null, "Massa", true);
            knowledgeTree.Insert(knowledgeTree.root, "Lasanha", true);
            knowledgeTree.Insert(knowledgeTree.root, "Bolo de chocolate", false);
        }

        public void StartGame()
        {
            if (knowledgeTree.IsEmpty())
            {
                SetupGame();
            }

            while (infiniteLoop)
            {
                Guess(knowledgeTree.root);
            }
        }

        public void Guess(Node node)
        {
            var question = "O prato que você pensou é " + node.GetValue() + "?";
            var answer = MessageBox.Show($"{question}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                if (node.IsLeaf())
                {
                    Win();
                }
                else
                {
                    Guess(node.GetRightChild());
                }
            }
            else
            {
                if (node.GetRightChild() == null)
                {
                    AskInformationAboutWrongGuess(node);
                    StartGame();
                }
                else
                {
                    Guess(node.GetLeftChild());
                }
            }
        }

        private DialogResult ShowInitialDialog()
        {
            var response = MessageBox.Show("O prato que você pensou é massa ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return response;
        }

        private void Win()
        {
            var result = MessageBox.Show($"Acertei de novo!", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StartGame();
        }

        private void AskInformationAboutWrongGuess(Node node)
        {
            var playerThoughtIn = Interaction.InputBox($"Qual prato você pensou?", "Desisto", string.Empty);
            var hint = Interaction.InputBox($"{playerThoughtIn} é __________ mas {node.GetValue()} não.");

            ChangeNodeToHintValue(node, hint, playerThoughtIn);
        }

        private void ChangeNodeToHintValue(Node node, string hint, string value)
        {
            var wrongGuess = node.GetValue();
            node.SetValue(hint);
            node.SetLeftChild(new Node(wrongGuess));
            node.SetRightChild(new Node(value));
        }
    }
}
