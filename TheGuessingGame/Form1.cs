using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace TheGuessingGame
{
    public partial class Form1 : Form
    {

        string theword;
        string blankword;


        string hintedword;
        int hints=5;
        int scores=0;
        Random rand = new Random();
        int randomchar;
        StringBuilder strword = new StringBuilder();
        StringBuilder strblankword = new StringBuilder();
        
        private void generateWord() {
            Random r1=new Random();
            string[] wordlist={"Infinite","Bytes","Printer","Computer","Shadow", "Four", "Electric", "Kilobytes", "Process", "Camera", "Paper", "Ink", "Properties", "Universal", "bat", "fan" };
            int wordpicker = r1.Next(wordlist.Length);
            StringBuilder selectedword=new StringBuilder(wordlist[wordpicker]);
            getWord(selectedword.ToString());
            cow.Text = theword.ToString();
        }
        private void getWord(string word) {
            theword = word;
        }

        private void getBlank(string blank) {
            blankword = blank;
        }

         public void showHint() {
            randomchar = rand.Next(theword.Length);
            strword = new StringBuilder(theword);
            strblankword = new StringBuilder(blankword);
            repeatHint();

        }

        public void repeatHint() {
            if (blankword == theword)
            {
                label1.Text = "Maximum Hints";
            }
            else
            {
                randomchar = rand.Next(theword.Length);
                if (blankword[randomchar].ToString() != "_")
                {
                    repeatHint();
                }
                strblankword[randomchar] = strword[randomchar];
                hintedword = strblankword.ToString();
                blankword = hintedword;
                label1.Text = blankword;
            }
        }
        private void validateHint()
        {
            if (hints == 0)
            {
                label3.ForeColor = Color.Red;
            }
            else
            {
                hints = hints - 1;
                label3.Text ="Hints: "+ hints.ToString();
                showHint();
            }
        }
        public void validateGuess()
        {
            if (textBox1.Text ==theword) {
                cow.Text = "Correct";
                scores = scores + 1;
                hints = hints + 5;
                score.Text = "Score: " + scores;
                label3.Text = "Hints: " + hints.ToString();
                generateWord();
                turntoblank();
                showHint();
            }
            else
            {
                cow.Text = "Wrong";
                listBox1.Items.Add(textBox1.Text);

            }
        }
        private void turntoblank() {
            string word = theword;
            string blank;
            string temp=null;
            for(int i=0; i<word.Length; i++)
            {
                blank = "_";
                temp = blank+temp;
                blank = temp;
                getBlank(blank);
                label1.Text = blankword;
            }
        }
        
        

        public Form1()
        {
            InitializeComponent();
            label3.Text = "Hints: "+hints;
            generateWord();
            turntoblank();
            showHint();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            validateGuess();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
         validateHint();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generateWord();
            turntoblank();
            showHint();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void score_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
